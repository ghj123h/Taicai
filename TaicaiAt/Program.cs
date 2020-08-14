using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace TaicaiAt
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex rans = new Regex(@"\[(?<name>.+?),\s+(?<answer>.+?)\]");
            string raw = File.ReadAllText("atlist.txt");
            List<string> atlist = raw.Split("@ \r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList(), anslist = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                var children = new DirectoryInfo(Console.ReadLine());
                foreach (var file in children.EnumerateFiles())
                {
                    if (file.Name == "answer.txt")
                    {
                        var answers = File.ReadAllLines(file.FullName);
                        foreach (var ans in answers)
                        {
                            var name = rans.Match(ans).Groups["name"].Value;
                            if (!anslist.Contains(name))
                            {
                                anslist.Add(name);
                            }
                        }
                    }
                }
            }
            atlist = atlist.Intersect(anslist).ToList();
            for (int i = 0; i < atlist.Count; i++)
            {
                Console.Write("@{0} ", atlist[i]);
                if (i % 5 == 4)
                {
                    Console.WriteLine();
                }
            }
        }
    }

    class DirComparer : IComparer<DirectoryInfo>
    {
        public int Compare(DirectoryInfo x, DirectoryInfo y)
        {
            return (int)(y.CreationTime - x.CreationTime).TotalSeconds;
        }
    }
}
