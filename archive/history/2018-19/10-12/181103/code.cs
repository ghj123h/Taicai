// 181103 Key: 2/yy/1.10/w/0/4148
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181103
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("2");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("yy");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(1.1, 32);
			list.Add(tmp);
			// Problem 4
			tmp = new MultipleProblem("w");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(0, 1.008, 1);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(4148, NumberProblem.HHMMSS);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}