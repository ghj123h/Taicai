// 190103 Key: a/1006/y/1/125.04/5.0
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190103
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("a");
			list.Add(tmp);
			// Problem 2
			tmp = new NumberProblem(1006, 0.8, 1);
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("1");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(125.04, NumberProblem.ACE * 2.5); 
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(5.0, 0.87, 0.5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}