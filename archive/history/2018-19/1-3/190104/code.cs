// 190104 Key: n/978/3/142.0/1.5/1159
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai190104
{
	public class ProblemFactory
	{
		// public static double baseScore = 65, deviation = 25;
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 2
			tmp = new NumberProblem(978, 0.75, 1);
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("3");
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(142, NumberProblem.ACE / 1.2, 1.25);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(1.5, 0.99, 0.5);
			list.Add(tmp);
			// Problem 6
			tmp = new TimeProblem("1159");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}