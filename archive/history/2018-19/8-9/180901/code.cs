// 180901 Key: 2/y/34/acd/989/0.6
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai180901
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("2");
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("y");
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("34", 1.0, a => Problem.NumberMethod("34", a, 1.0, 1.0));
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("acd", 1.25, a => Problem.MultipleChoiceMethod("acd", a, 1.25));
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("989", 1.25, a => Problem.NumberMethod("989", a, 1.25, 0.75));
			list.Add(tmp);
			// Problem 6
			tmp = new Problem("0.6", 1.0, a => {
				a = a.Replace(".", string.Empty);
				return Problem.OffsetMethod("6", a, 1.0, 0.87);
			});
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}