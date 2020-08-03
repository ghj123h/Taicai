// 200704 Key: n/2/2/abcd/1005/y-41-3.5875
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai200704
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
			tmp = new DefaultProblem("2");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(2, 5.0 / 6.0);
			list.Add(tmp);
			// Problem 4
			tmp = new MultipleProblem("abcd");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(1005);
			list.Add(tmp);
			// Problem 6
			tmp = new Problem6();
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem6 : NumberNoDotProblem
		{
			public Problem6()
				: base(3.5875, 2)
			{
				Key = "y-41-3.5875";
			}
			
			public override double GetScore(string answer)
			{
				double _answer;
				if (answer == "y")
				{
					return 0.5;
				}
				else if (double.TryParse(answer, out _answer))
				{
					if (answer.Contains("."))
					{
						return base.GetScore(answer);
					}
					else
					{
						return (new OffsetProblem(41, 1.0 / 3)).GetScore(answer);
					}
				}
				else
				{
					return 0;
				}
			}
		}
	}
}