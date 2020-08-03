// 190404 Key: n/3/e/7/6.5/18
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190404
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("3");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("e");
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(7, 0.87);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(6.5, 0.87, 0.5);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(18, NumberProblem.ACE);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}