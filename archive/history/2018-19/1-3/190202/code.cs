// 190202 Key: 20/y/2/10/92.33/56
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190202
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("20");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("2");
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(10, 0.9);
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(92.33, NumberProblem.ACE * 2.5, 1);
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(56, 1 / 6.0, 1, 5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}