// 180904 Key: 29/y/11/c/no/1.5
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai180904
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("29", 1.0, a => Problem.OffsetMethod("29", a, 1.0, 0.78));
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("y");
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("11", 1.25, a => Problem.OffsetMethod("11", a, 1.25, 0.3, 3));
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("c", 1.25);
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("no", 1.5);
			list.Add(tmp);
			// Problem 6
			tmp = new Problem("1.5", 1, a => {
				Dictionary<int, double> dict = new Dictionary<int, double>();
				dict.Add(5, 0.9);
				a = a.Replace(".", string.Empty);
				return Problem.OffsetMethod("15", a, 1, dict);
			});
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}