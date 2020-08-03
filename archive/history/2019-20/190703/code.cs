// 190703 Key: 14/y/a/19/39.4/wels
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190703
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new OffsetProblem(14, 0.9);
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("a");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("19");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(39.4);
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("wels");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}