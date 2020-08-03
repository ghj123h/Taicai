// 190402 Key: 0-1/n/99.4/964/39/2.6375
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190402
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem1();
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(99.4, NumberProblem.ACE * 2.5, 1.25);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(964, 0.6, 1.3);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(39, 1 / 7.0, 1, 6);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(2.6375, NumberProblem.ACE);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem1 : Problem
		{
			public Problem1()
			{
				Key = "0-1";
				FullScore = 1.0;
			}
			
			public override double GetScore(string answer)
			{
				if (answer == "0" || answer == "1") {
					return 1.0;
				} else {
					return 0.0;
				}
			}
		}
	}
}