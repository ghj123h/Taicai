// 181203 Key: 1032/yn/89/1.825/ll-ml-hl/2
using System;
using System.Linq;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181203
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new NumberProblem(1032, 1.008, 1.0);
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("yn");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(89, 0.1, 1, 9, 1.25);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(1.825, NumberProblem.ACE * 5);
			list.Add(tmp);
			// Problem 5
			tmp = new Problem5();
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("2");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem5 : Problem
		{
			private List<string> answers;
			private int maxLength;
			
			public Problem5()
			{
				answers = new string []{
					"ll", "ml", "hl"
				}.ToList();
				Key = answers.Aggregate((current, next) => current + "-" + next);
				FullScore = 1.0;
				maxLength = answers.Max(ans => ans.Length);
			}
			
			public override double GetScore(string answer)
			{
				if (answers.Where(a => a.Contains(answer)).Count() > 0)
				{
					return FullScore * answer.Length / maxLength;
				}
				else
				{
					return 0;
				}
			}
		}
	}
}