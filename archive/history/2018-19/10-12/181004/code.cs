// 181004 Key: ep/905/1.0/430/6/n
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181004
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("ep");
			list.Add(tmp);
			// Problem 2
			tmp = new NumberProblem(905, 1);
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(1.0, 10.09, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(430, 0.141);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(6, 0.82);
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}