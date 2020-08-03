// 190702 Key: y/5/by/11/152.6/abedc
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190702
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
			tmp = new OffsetProblem(5, 0.87);
			list.Add(tmp);
			// Problem 3
			tmp = new MultipleProblem("by", false, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(11);
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(152.6);
			list.Add(tmp);
			// Problem 6
			tmp = new Problem6();
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem6 : Problem
		{
			public Problem6()
			{
				Key = "abedc";
				FullScore = 1.25;
			}
			
			public override double GetScore(string answer)
			{
				if (answer.Length == 5)
				{
					int[, ] d = new int[6, 6] {
						{0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0}
					};
					for (int i = 0; i < 5; i++)
					{
						for (int j = 0; j < 5; j++)
						{
							if (Key[i] != answer[j])
							{
								d[i + 1, j + 1] = Math.Max(d[i, j + 1], d[i + 1, j]);
							}
							else
							{
								d[i + 1, j + 1] = d[i, j] + 1;
							}
						}
					}
					switch(d[5, 5])
					{
						case 5:
							return FullScore;
						case 4:
							return FullScore * 0.4;
						default:
							return 0;
					}
				}
				return 0;
			}
		}
	}
}