using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using TaicaiLib;

namespace TaicaiTotal
{
    class Program
    {
        static List<User> userlist = new List<User>();
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("users.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            userlist = (List<User>)bf.Deserialize(fs);
            int used = int.Parse(Console.ReadLine());
            var tmp = userlist.Select(u => new { user = u, total = GetMaximizedTotalScore(u, used) });
            foreach (var u in tmp.OrderByDescending(x => x.total))
            {
                Console.WriteLine(new KeyValuePair<string, double>(u.user.Name, u.total));
            }
            //TaicaiLib.Problem p = new TaicaiLib.Problem("wp");
            //BinaryFormatter bg = new BinaryFormatter();
            //bg.Serialize(Console.OpenStandardOutput(), p);
            Console.ReadLine();
            if (File.Exists("total.cs"))
            {
                Console.Clear();
                GetSpecializedTotalScore();
                Console.ReadLine();
            }
        }

        static double GetMaximizedTotalScore(User u, int e)
        {
            if (u.History.Count() < e)
            {
                return u.TotalScore;
            }
            else
            {
                List<UserLottery> list = u.History.ToList();
                list.Sort((x, y) => Comparer<double>.Default.Compare(y.AdjustedScore, x.AdjustedScore));
                return list.Take(e).Sum(x => x.AdjustedScore);
            }
        }

        static void GetSpecializedTotalScore()
        {
            string label = Console.ReadLine();
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters para = new CompilerParameters();
            para.ReferencedAssemblies.Add("System.dll");
            para.ReferencedAssemblies.Add("System.Core.dll");
            para.ReferencedAssemblies.Add("TaicaiLib.dll");
            para.GenerateInMemory = true;
            para.GenerateExecutable = false;
            CompilerResults results = provider.CompileAssemblyFromFile(para, "total.cs");
            if (results.Errors.Count > 0)
            {
                Console.WriteLine("Code Errors:");
                foreach (CompilerError e in results.Errors)
                {
                    Console.WriteLine("{0} line {1}: {2}", e.IsWarning ? "Warning" : "Error", e.Line, e.ErrorText);
                }
                if (results.Errors.HasErrors) return;
            }
            Assembly ass = results.CompiledAssembly;
            object theClass = ass.CreateInstance("Taicai" + label + ".TotalGenerator");
            if (theClass == null)
            {
                Console.WriteLine("Taicai{0}.TotalGenerator needed", label);
                return;
            }
            Type totalGenerator = theClass.GetType();
            var spec = userlist.Select(u => new
            {
                user = u,
                total = (double)totalGenerator.InvokeMember("GetSpecializedTotalScore",
                BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, new object[] { u })
            });
            foreach (var s in spec.OrderByDescending(x => x.total))
            {
                Console.WriteLine(new KeyValuePair<string, double>(s.user.Name, s.total));
            }
        }
    }
}
