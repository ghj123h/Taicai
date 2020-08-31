// 200804 Key: n/f/2/-/4/137
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai200804
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
			tmp = new DefaultProblem("f");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("2");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("-", 1.5);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(4, 0.87);
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(137, 1.0 / 6.0);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}