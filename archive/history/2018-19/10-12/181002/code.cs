// 181002 Key: vscs/9/3/19.73/28.5/abc
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181002
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("vscs");
			list.Add(tmp);
			// Problem 2
			tmp = new NumberProblem(9, 1, 1);
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(3, 0.86);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(19.73, 0.4);
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(28.5, 4.0 / 9.0);
			list.Add(tmp);
			// Problem 6
			tmp = new MultipleProblem("abc");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}