// 190201 Key: 0/n/2.5/08/fi-ga-nl/8.93
using System;
using System.Collections.Generic;
using System.Linq;

using TaicaiLib;

namespace Taicai190201
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(2.5, 0.99, 0.5);
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(8, 0.9);
			list.Add(tmp);
			// Problem 5
			tmp = new Problem5();
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(8.93, NumberProblem.ACE);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem5 : Problem
		{
			public string[] keys = new string[] { "fi", "ga", "nl" };
			
			public Problem5()
			{
				FullScore = 1.6;
				Key = keys.Aggregate((x, y) => x + "-" + y);
			}
			
			public override double GetScore(string answer)
			{
				string[] answers = answer.Split("-".ToCharArray());
				int same = keys.Intersect(answers).Count(), diff = answers.Except(keys).Count();
				double score = same > diff ? (same - diff) * 1.25 / 3.0 : 0;
				if (diff == 0)
				{
					int i, j;
					i = j = 0;
					while (i < keys.Length && j < answers.Length)
					{
						if (keys[i] == answers[j])
						{
							++j;
						}
						++i;
					}
					if (j == answers.Length)
					{
						score *= 1.28;
					}
				}
				return score;
			}
		}
	}
}