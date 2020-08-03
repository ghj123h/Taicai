// 190501 Key: -/0/d/3/0.8/127.1
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190501
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("-");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("0");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("d");
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(3, 0.87);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(0.8, 0.9, 0.1);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(127.1, NumberProblem.ACE * 2);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}