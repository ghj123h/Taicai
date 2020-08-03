// 190203 Key: c/3/superty/2.0/19.2375/7
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190203
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("c");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("3");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("superty");
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(2.0, 0.87, 0.5);
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(19.2375, NumberProblem.ACE);
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(7, 1 / 6.0, 1, 5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}