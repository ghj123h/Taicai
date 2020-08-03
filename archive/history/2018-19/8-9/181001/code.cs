// 181001 Key: 6.5/y/4/100/af/143.8/270
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181001
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("6.5", 1.0, a => {
				Dictionary<int, double> dict = new Dictionary<int, double>();
				a = a.Replace(".", string.Empty);
				dict.Add(5, 0.87);
				return Problem.OffsetMethod("65", a, 1.0, dict);
			});
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("y");
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("4");
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("100");
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("af", 1.25, a => Problem.MultipleChoiceMethod("af", a, 1.25));
			list.Add(tmp);
			// Problem 6
			tmp = new Problem("143.8", 1.5, a => Problem.NumberMethod("143.8", a, 1.5, 0.980665));
			list.Add(tmp);
			tmp = new Problem("270", 1.5, a => Problem.NumberMethod("270", a, 1.5, (Math.E - 2) / 10));
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}