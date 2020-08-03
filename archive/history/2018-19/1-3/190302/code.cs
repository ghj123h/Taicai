// 190302 Key: 1/y/3.5/11/30/17.61
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190302
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("1");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(3.5, 0.9, 0.5);
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(11, 1.0 / 3.0, 1, 2);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(30, 1.0 / 6.0, 1, 5);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(17.61, NumberProblem.ACE / 2);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}