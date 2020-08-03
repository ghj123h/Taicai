// 190401 Key: 7/yn/45/0/a/6086299289
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190401
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("7");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("yn");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(45, 0.87, 5);
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 5
			tmp = new DefaultProblem("a");
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(6086299289, 1 / 20000.0);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}