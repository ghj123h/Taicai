// Seasonal Key: y/ra-mt/02-15/ya-ko-yu/04-10/55.0275
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai19S01
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
			tmp = new Problem2();
			list.Add(tmp);
			// Problem 3
			tmp = new Problem3();
			list.Add(tmp);
			// Problem 4
			tmp = new MultipleProblem("ya-ko-yu", true);
			list.Add(tmp);
			// Problem 5
			tmp = new DefaultProblem("04-10");
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(55.0275, NumberProblem.ACE / 5);
			list.Add(tmp);
			return list;
		}
		
		[Serializable]
		public class Problem2 : Problem
		{
			public Problem2()
			{
				Key = "ra-mt";
				FullScore = 1;
			}
			
			public override double GetScore(string answer)
			{
				switch(answer)
				{
					case "ra":
					case "mt":
						return FullScore / 2;
					case "ra-mt":
						return FullScore;
					default:
						return 0;
				}
			}
		}
		
		[Serializable]
		public class Problem3 : Problem
		{
			private DateTime _key = DateTime.Parse("02-15");
			public Problem3()
			{
				Key = "02-15";
				FullScore = 1;
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