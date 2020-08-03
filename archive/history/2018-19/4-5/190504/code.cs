// 190504 Key: n/no/ael/0.0/86.9/13/04-01/nn/21.01
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190504
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
			tmp = new DefaultProblem("no");
			list.Add(tmp);
			// Problem 3
			tmp = new MultipleProblem("ael");
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(0.0, 0.5, 0.87);
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(86.9, NumberProblem.ACE * 2);
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(13, 1 / 6.0, 1, 5);
			list.Add(tmp);
			// Problem 7
			tmp = new Problem7();
			list.Add(tmp);
			// Problem 8
			tmp = new DefaultProblem("nn");
			list.Add(tmp);
			// Problem 9
			tmp = new NumberProblem(21.01, NumberProblem.ACE);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem7 : Problem
		{
			private DateTime _key = DateTime.Parse("04-01");
			public Problem7()
			{
				Key = "04-01";
				FullScore = 1.0;
			}
			
			public override double GetScore(string answer)
			{
				DateTime _answer;
				if (!DateTime.TryParse(answer, out _answer)) return 0;
				var span = Math.Abs((_key - _answer).Days);
				if (span < 10) return (10 - span) / 10.0;
				else return 0;
			}
		}
	}
}