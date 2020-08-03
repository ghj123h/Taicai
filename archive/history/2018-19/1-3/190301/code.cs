// 190301 Key: n/6/945/150.9/b-wmg/a
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190301
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("6");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(945, 0.75, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(150.9, NumberProblem.ACE * 2.5, 1.25);
			list.Add(tmp);
			// Problem 5
			tmp = new Problem5();
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("a");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem5 : Problem
		{
			public Problem5()
			{
				Key = "b-wmg";
				FullScore = 1.0;
			}
			
			public override double GetScore(string answer)
			{
				switch(answer)
				{
					case "b-wmg":
						return 1.0;
					case "b-ow":
					case "w-wmg":
					case "lg-wmg":
						return 0.13;
					default:
						return 0;
				}
			}
		}
	}
}