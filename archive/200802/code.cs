// 200802 Key: fj/ce/40/70/142.5/ac
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai200802
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("fj");
			list.Add(tmp);
			// Problem 2
			tmp = new MultipleProblem("ce");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("40");
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(70, 0.87, 5);
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(142.5);
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("ac", 1.25);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}