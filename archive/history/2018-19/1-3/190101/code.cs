// 190101 Key: 2/0/1014/y/8/75.62 lYc6Qm
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190101
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
			tmp = new DefaultProblem("2");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(1014, 0.5, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(8, 0.9);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(75.62, NumberProblem.ACE * 1.5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}