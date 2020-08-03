// 190603 Key: n/18/we/40/21.9/71.5
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190603
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
			tmp = new OffsetProblem(18, 0.9);
			list.Add(tmp);
			// Problem 3
			tmp = new MultipleProblem("we");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("40");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(21.9);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(71.5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}