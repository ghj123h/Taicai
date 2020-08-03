// 190102 Key: n/21/1012/ac/35/0.606666666667
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190102
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		// public static double baseScore = 65, deviation = 25;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("21");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(1012, 0.8, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new MultipleProblem("ac");
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(35, 0.87, 5);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(0.6825 / 1.125, 2);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}