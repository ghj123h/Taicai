using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace TaicaiGet
{
    class Program
    {
        static string page;
        static ulong tid = 0;
        static int pages = 0;
        static int minl = 0, maxl = 0;
        static string fmt = "http://tieba.baidu.com/p/{0}?pn={1}";
        static Dictionary<string, string> answers = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            tid = ulong.Parse(Console.ReadLine());
            pages = int.Parse(Console.ReadLine());
            minl = int.Parse(Console.ReadLine());
            maxl = int.Parse(Console.ReadLine());
            for (int i = pages; i >= 1; i--)
            {
                if (!GetPosts(i))
                {
                    break;
                }
            }
            foreach (var ans in answers.Reverse())
            {
                Console.WriteLine(ans);
            }
            Console.ReadLine();
        }

        static bool GetPosts(int p)
        {
            string url = string.Format(fmt, tid, p);
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            page = wc.DownloadString(url);
            // var doc = new HtmlDocument();
            // doc.LoadHtml(page);
            // HtmlNodeCollection postList = doc.DocumentNode.SelectNodes("//div[@class='l_post l_post_bright j_l_post clearfix  ']");
            Regex run = new Regex("<img.+username=\"(?<name>.+?)\".+?>"),
                rpc = new Regex("<div\\s+id=\"post_content_\\d+\"\\s+class=\"d_post_content j_d_post_content \".+?>(?<content>.+?)</div>"),
                rls = new Regex("<span\\s+class=\"tail-info\">(?<floor>\\d+).+</span>"),
                rbb = new Regex("<div\\s+class=\"post_bubble_middle_inner\">(?<content>.+?)</div>");
            //Console.WriteLine(rls.Match(html).Groups["floor"].Value);
            string[] posts = page.Split(new string[] { "\"l_post l_post_bright j_l_post clearfix  \"" }, StringSplitOptions.None);
            for (int i = posts.Length - 1; i >= 1; i--)
            {
                string html = posts[i];
                // Console.WriteLine(new KeyValuePair<int, int>(p, i));
                int floor = int.Parse(rls.Match(html).Groups["floor"].Value);
                if (floor > maxl)
                {
                    continue;
                }
                if (floor < minl)
                {
                    return false;
                }
                string name = run.Match(html).Groups["name"].Value.Trim();
                string answer = rpc.Match(html).Groups["content"].Value.Trim();
                // Console.WriteLine(rpc.Match(html).Value);
                if (answer.Contains("post_bubble_top"))
                {
                    answer = rbb.Match(html).Groups["content"].Value.Trim();
                }
                if (!answers.ContainsKey(name))
                {
                    answers.Add(name, answer);
                }
            }
            return true;
        }
    }
}
