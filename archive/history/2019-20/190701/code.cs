// 190701 Key: y/3/10/0/27.9/19.8725
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190701
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
			tmp = new DefaultProblem("3");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(10, 1.3);
			list.Add(tmp);
			// Problem 4
			tmp = new Problem4();
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(27.9);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(19.8725);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem4 : Problem
		{
			public Problem4()
			{
				Key = "00";
				FullScore = 1;
			}
			
			public override double GetScore(string answer)
			{
				int _answer;
				if (int.TryParse(answer, out _answer))
				{
					switch (_answer)
					{
						case 0:
							return FullScore;
						case 23:
						case 1:
							return FullScore / 3.0 * 2.0;
						case 22:
						case 2:
							return FullScore / 3.0;
						default:
							return 0;
					}
				}
				return 0;
			}
		}
	}
}