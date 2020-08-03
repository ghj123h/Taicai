// 181005 Key: 90-85-48/3/medium/n/65/y-3-5933258127
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181005
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem1();
			list.Add(tmp);
			// Problem 2
			tmp = new OffsetProblem(3, 0.86);
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("medium");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(65, 0.08);
			list.Add(tmp);
			// Problem 6
			tmp = new Problem6();
			list.Add(tmp);
			return list;
		}
		
		[Serializable]
		public class Problem1 : Problem
		{
			public Problem1()
			{
				Key = "90-85-48";
				FullScore = 1;
			}
			
			public override double GetScore(string answer)
			{
				string[] keys = answer.Split("-".ToCharArray());
				if (keys.Length < 3)
				{
					return 0;
				}
				return (Convert.ToInt32(keys[0] == "90") + Convert.ToInt32(keys[1] == "85") + Convert.ToInt32(keys[2] == "48")) / 3.0;
			}
		}
		
		[Serializable]
		public class Problem6 : Problem
		{
			public Problem6()
			{
				Key = "y-3-5933258127";
				FullScore = 67.0 / 34.0;
			}
			
			public override double GetScore(string answer)
			{
				double _answer = 0;
				if (!double.TryParse(answer, out _answer))
				{
					return Convert.ToInt32(answer == "y");
				}
				if (answer.Length < 10)
				{
					return (new OffsetProblem(3, 1.0 / 8.0, 1, 10086, 2)).GetScore(answer);
				}
				else
				{
					return (new NumberProblem(5933258127, 1 / 20000.0, 3)).GetScore(answer);
				}
			}
		}
	}
}