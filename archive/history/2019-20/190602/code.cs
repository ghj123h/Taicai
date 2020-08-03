// 190602 Key: n/0/6.0/1/0/14.0725
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190602
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
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(6.0, 0.87, 0.5);
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(1, 1 / 3.0);
			list.Add(tmp);
			// Problem 5
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(14.0725);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}