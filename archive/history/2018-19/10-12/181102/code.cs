// 181102 Key: -1/ny/1/bsw/38/10.545
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181102
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Dictionary<int, double> dict = new Dictionary<int, double>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("-1");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("ny");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("1");
			list.Add(tmp);
			// Problem 4
			tmp = new MultipleProblem("bsw");
			list.Add(tmp);
			// Problem 5
			dict.Add(2, 0.9);
			dict.Add(3, 0.9);
			tmp = new OffsetsProblem(38, dict);
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(10.545, NumberProblem.ACE * 5);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}