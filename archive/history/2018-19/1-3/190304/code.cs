// 190304 Key: y/a/40/983/39/22.9
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190304
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
			tmp = new DefaultProblem("a");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(40, 0.87, 5);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(983, 0.75, 1);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(39, 1 / 6.0, 1, 5);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(22.9, NumberProblem.ACE * 3);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}