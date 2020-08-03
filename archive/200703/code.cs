// 200703 Key: y/b/7/19.3/sl/0
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai200703
{
	public class ProblemFactory
	{
		public static bool seasonal = true;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("b");
			list.Add(tmp);
			// Problem 3
			tmp = new OffsetProblem(7, 0.25);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(19.3);
			list.Add(tmp);
			// Problem 5
			tmp = new MultipleProblem("sl");
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("-", 1.5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}