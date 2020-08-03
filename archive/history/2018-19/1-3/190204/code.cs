// 190204 Key: y/-/1/cab(bac)/678/113.02
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190204
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("abcdefg");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(1, 0.87);
			list.Add(tmp);
			// Problem 4
			tmp = new Problem4();
			list.Add(tmp);
			// Problem 5
			tmp = new MultipleProblem("678");
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(113.02, NumberProblem.ACE * 2.5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem4 : Problem
		{
			public Problem4()
			{
				Key = "cab(bac)";
				FullScore = 1.0;
			}
			
			public override double GetScore(string answer)
			{
				if (answer == "cab" || answer == "bac")
				{
					return FullScore;
				}
				return 0;
			}
		}
	}
}