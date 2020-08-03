// 190502 Key: 3/50/d/50/988/0
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190502
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new OffsetProblem(3, 0.9);
			list.Add(tmp);
			// Problem 2
			tmp = new OffsetProblem(50, 0.87, 5);
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("d");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("50");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(988, 0.75, 1);
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(0, 1 / 6.0, 1, 5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}