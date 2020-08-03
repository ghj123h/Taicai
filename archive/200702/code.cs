// 200702 Key: n/1/133.3/7/bc/n-0.160
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai200702
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("1");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(133.3);
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(7, 0.75);
			list.Add(tmp);
			// Problem 5
			tmp = new Problem5();
			list.Add(tmp);
			// Problem 6
			tmp = new Problem6();
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem5 : Problem
		{
			public Problem5()
			{
				Key = "bc";
				FullScore = 1.0;
			}
			public override double GetScore(string answer)
			{
				if (answer.Length == 2)
				{
					if (answer == Key)
					{
						return FullScore;
					}
					else if (answer[0] == 'b' || answer[1] == 'c')
					{
						return FullScore / 5;
					}
				}
				return 0;
			}
		}
		
		[Serializable]
		public class Problem6 : NumberProblem
		{
			public Problem6()
				: base(0.160, 2.0)
			{
				Key = "n-0.160";
			}
			
			public override double GetScore(string answer)
			{
				if (answer == "n")
				{
					return 0.75;
				}
				else
				{
					return base.GetScore(answer);
				}
			}
		}
	}
}