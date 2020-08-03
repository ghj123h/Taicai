// 190403 Key: 25/c/3/0/dw-qdltq-by/20
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190403
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("25");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("c");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("3");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 5
			tmp = new MultipleProblem("dw-qdltq-by", true);
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(20, 1 / 6.0, 1, 5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}