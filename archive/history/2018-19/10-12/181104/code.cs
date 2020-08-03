// 181104 Key: n/10/cd/0.03869938160781966886096150009974/0/dw
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181104
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
			tmp = new OffsetProblem(10, 0.2, 1, 4);
			list.Add(tmp);
			// Problem 3
			tmp = new MultipleProblem("cd");
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(0.485 / 10.5325, NumberProblem.ACE * 113);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(0, 0.9);
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("dw", 1.25);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}