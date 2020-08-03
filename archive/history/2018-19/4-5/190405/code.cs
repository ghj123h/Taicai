// 190405 Key: d/4p/1040/45/90.1/83.97
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190405
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("d");
			list.Add(tmp);
			// Problem 2
			tmp = new Problem2();
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(1040, 0.75, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(45, 0.85, 5);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(90.1, 1 / 16.0, 0.1, 15);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(83.97, NumberProblem.ACE * 2);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem2 : Problem
		{
			public Problem2()
			{
				Key = "4p";
				FullScore = 1.0;
			}
			
			public override double GetScore(string answer)
			{
				if (answer.Length != 2) {
					return 0;
				} else if (answer == "4p") {
					return FullScore;
				} else if (answer[0] == '4' || answer[1] == 'p') {
					return 1 / 3.0 * FullScore;
				} else {
					return 0;
				}
			}
		}
	}
}