// 190604 Key: b/n/3/eb/127.2/3.495
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190604
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("b");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("3");
			list.Add(tmp);
			// Problem 4
			tmp = new Problem4();
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(127.2);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(3.495);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem4 : Problem
		{
			public Problem4()
			{
				Key = "eb";
				FullScore = 1.25;
			}
			
			public override double GetScore(string answer)
			{
				switch (answer)
				{
					case "eb":
						return FullScore;
					case "e":
					case "b":
						return FullScore / 2.0;
					default:
						return 0;
				}
			}
		}
	}
}