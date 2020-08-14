// 200801 Key: 0/d/5/38.0/yn/d-12-191554
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai200801
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("d");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(5, 0.8);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(38.0);
			list.Add(tmp);
			// Problem 5
			tmp = new DefaultProblem("yn");
			list.Add(tmp);
			// Problem 6
			tmp = new Problem6();
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem6 : TimeProblem
		{
			public Problem6()
				:base("191554", 2.5)
			{
				Key = "d-12-191554";
			}
			
			public override double GetScore(string answer)
			{
				if (answer == "d")
				{
					return 0.6;
				}
				else if (answer.Length == 6)
				{
					return base.GetScore(answer);
				}
				else
				{
					return (new OffsetProblem(12, 0.25, 1, 999, 1.2)).GetScore(answer);
				}
			}
		}
	}
}