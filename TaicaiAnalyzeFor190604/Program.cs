using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Text;
using TaicaiLib;

namespace TaicaiAnalyze190504
{
    class Program
    {
        static string number = "";
        static void Main(string[] args)
        {
            FileStream fs;
            BinaryFormatter bf = new BinaryFormatter();
            List<User> userlist = new List<User>();
            number = "190504";
            Regex rans = new Regex(@"\[(?<name>.+?),\s+(?<answer>.+?)\]");

            int answerLength = 0;
            if (File.Exists("users.dat") && File.Exists("lotteries.txt"))
            {
                fs = new FileStream("users.dat", FileMode.Open, FileAccess.Read);
                userlist = (List<User>)bf.Deserialize(fs);
                fs.Close();
            }
            Lottery lottery = GetLottery();
            if (lottery == null)
            {
                Console.ReadLine();
                return;
            }
            Directory.SetCurrentDirectory(number);
            // UserLottery uly;
            Dictionary<User, string> rawAnswers = new Dictionary<User, string>();
            answerLength = 0;
            foreach (var ans in File.ReadLines("answer.txt"))
            {
                Match match = rans.Match(ans);
                string name = match.Groups["name"].Value;
                User current = userlist.Find(u => u.Name == name);
                if (current == null)
                {
                    userlist.Add(current = new User(name));
                }
                rawAnswers.Add(current, match.Groups["answer"].Value);
                // uly = new UserLottery(match.Groups["answer"].Value, current, lottery);
                //if (answerLength < match.Groups["answer"].Value.Length)
                //{
                //    answerLength = match.Groups["answer"].Value.Length;
                //}
            }
            lottery.IsSeasonalLottery = true;
            answerLength = 0;
            string[] lotterylist = new string[] { "190401", "190402", "190403" };
            UserLottery seasonal;
            foreach (User u in userlist)
            {
                var anses = lotterylist.Select(l =>
                {
                    var tmp = u.History.SingleOrDefault(ul => ul.Lottery.Number == l);
                    if (tmp == null)
                    {
                        return "-";
                    }
                    else
                    {
                        return tmp.RawAnswer.Split("/".ToCharArray()).Last();
                    }
                });
                var seasonalAnswer = anses.Aggregate((a, b) => a + "/" + b);
                if (rawAnswers.ContainsKey(u))
                {
                    seasonalAnswer = rawAnswers[u] + "/" + seasonalAnswer;
                }
                else
                {
                    seasonalAnswer = "-/-/-/-/-/-/" + seasonalAnswer;
                }
                if (seasonalAnswer != "-/-/-/-/-/-/-/-/-")
                {
                    seasonal = new UserLottery(seasonalAnswer, u, lottery);
                    answerLength = Math.Max(answerLength, seasonalAnswer.Length);
                }
            }
            lottery.UpdateData();
            int m = lottery.Problems.Count(), n = lottery.Count;
            foreach (var p in lottery.Problems)
            {
                Console.WriteLine(p.ScorePercent);
            }
            foreach (var u in lottery.OrderByDescending(u => u.AdjustedScore))
            {
                Console.Write("{0}{1}{2,-8}", padRightEx(u.User.Name, 16), u.RawAnswer.ToString().PadRight(answerLength + 8), u.AdjustedScore.ToString("0.##"));
                foreach (var a in u.Answers)
                {
                    Console.Write("{0,-8}", a.Score.ToString("0.#####"));
                }
                Console.WriteLine("{0,-8}", u.Rank);
            }
            fs = new FileStream("..\\users.dat", FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, userlist);
            fs.Close();
            Console.ReadLine();
        }

        static Lottery GetLottery()
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters para = new CompilerParameters();
            para.ReferencedAssemblies.Add("System.dll");
            para.ReferencedAssemblies.Add("System.Core.dll");
            para.ReferencedAssemblies.Add("TaicaiLib.dll");
            para.GenerateInMemory = false;
            para.GenerateExecutable = false;
            para.OutputAssembly = "Taicai" + number + ".dll";
            CompilerResults results = provider.CompileAssemblyFromFile(para, number + "\\code.cs");
            if (results.Errors.Count > 0)
            {
                Console.WriteLine("Code Errors:");
                foreach (CompilerError e in results.Errors)
                {
                    Console.WriteLine("{0} line {1}: {2}", e.IsWarning ? "Warning" : "Error", e.Line, e.ErrorText);
                }
                if (results.Errors.HasErrors) return null;
            }
            Assembly ass = Assembly.LoadFile(Directory.GetCurrentDirectory() + "\\Taicai" + number + ".dll");
            object theClass = ass.CreateInstance("Taicai" + number + ".ProblemFactory");
            if (theClass == null)
            {
                Console.WriteLine("Taicai{0}.ProblemFactory needed", number);
                return null;
            }
            Type problemFactory = theClass.GetType();
            IEnumerable<Problem> problems = (IEnumerable<Problem>)theClass.GetType().InvokeMember("GetProblems", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, null);
            Lottery lottery = new Lottery(number, problems);
            FieldInfo fi = problemFactory.GetField("baseScore", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
            if (fi != null)
            {
                lottery.BaseScore = (double)fi.GetValue(theClass);
            }
            fi = problemFactory.GetField("deviation", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
            if (fi != null)
            {
                lottery.Deviation = (double)fi.GetValue(theClass);
            }
            fi = problemFactory.GetField("seasonal", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
            if (fi != null)
            {
                lottery.HasSeasonalProblem = (bool)fi.GetValue(theClass);
            }
            return lottery;
        }

        static string padRightEx(string str, int totalByteCount)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount);
            return w;
        }
    }
}
