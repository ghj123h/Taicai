// 180803 Key: yyn/92/m/85/918/a
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai180803
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("yyn", 1.0, Method1);
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("92");
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("m");
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("85", 1.0, a => {
				Dictionary<int, double> dict = new Dictionary<int, double>();
				dict.Add(5, 0.75);
				return Problem.OffsetMethod("85", a, 1.0, dict);
			});
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("918", 1.0, a => Problem.NumberMethod("918", a, 1.5, 1));
			list.Add(tmp);
			// Problem 6
			tmp = new Problem("a", 1.25);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		public static double Method1(string answer)
		{
			if (answer.Length != 3)
			{
				return 0;
			}
			int right = 0;
			string key = "yyn";
			for (int i = 0; i < 3; i++)
			{
				if (key[i] == answer[i])
				{
					right++;
				}
				else
				{
					right--;
				}
			}
			right = Math.Max(right, 0);
			return right / 3.0;
		}
	}
}