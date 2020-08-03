// 181205 Key: pk-py-ma/22/58/4/2.6615384615384615384615384615385/y
using System;
using System.Linq;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181205
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
			tmp = new DefaultProblem("22");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(58, 0.5, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(4, 0.9);
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(6.055 / 2.275, NumberProblem.ACE * 5);
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
	
	[Serializable]
	public class Problem1 : Problem
	{
		private string[] keys;
		
		public Problem1()
		{
			keys = new string[] { "pk", "py", "ma" };
			Key = keys.Aggregate((a, b) => a + "-" + b);
			FullScore = 1.25;
		}
		
		public override double GetScore(string answer)
		{
			string[] answers = answer.Split("-".ToCharArray());
			int cap, except;
			cap = answers.Intersect(keys).Count();
			except = answers.Except(keys).Count();
			if (cap < except)
			{
				return 0;
			}
			else
			{
				return (cap - except) / 3.0 * FullScore;
			}
		}
	}
}