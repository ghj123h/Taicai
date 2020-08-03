// 181003 Key: 13/4/y/y/abcde/1
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181003
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new OffsetProblem(13, 0.9);
			list.Add(tmp);
			// Problem 2
			tmp = new NumberProblem(4, 10.0 / 9.0);
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 5
			tmp = new MultipleProblem("abcde");
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(1, 0.81);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}