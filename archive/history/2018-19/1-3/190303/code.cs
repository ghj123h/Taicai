// 190303 Key: y/4/0/0/21/cdab(cdba)
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190303
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
			tmp = new DefaultProblem("4");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 4
			tmp = new MultipleProblem("0");
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(21, 0.2, 1, 4);
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
				Key = "cdab-cdba";
				FullScore = 1.25;
			}
			
			public override double GetScore(string answer)
			{
				switch(answer)
				{
					case "cdab":
					case "cdba":
						return FullScore;
					case "cda":
					case "cdb":
					case "cab":
					case "cba":
					case "dab":
					case "dba":
						return FullScore / 2;
					default:
						return 0;
				}
			}
		}
	}
}