// 190503 Key: y/l/35/10.86/31/914
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190503
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
			tmp = new MultipleProblem("l", false, 1);
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(35, 0.95, 5);
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(10.86, 1 / 16.0, 0.1, 15);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(31, 0.25, 1, 3);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(914, 0.8);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}