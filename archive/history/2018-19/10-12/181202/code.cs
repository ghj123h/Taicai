// 181202 Key: 0/960/abce/3/-20/14
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181202
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 2
			tmp = new NumberProblem(960, 1.008, 1);
			list.Add(tmp);
			// Problem 3
			tmp = new MultipleProblem("abce");
			list.Add(tmp);
			// Problem 4
			tmp = new DefaultProblem("3");
			list.Add(tmp);
			// Problem 5
			tmp = new NumberProblem(-20, NumberProblem.ACE);
			list.Add(tmp);
			// Problem 6
			tmp = new OffsetProblem(14, 0.88);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}