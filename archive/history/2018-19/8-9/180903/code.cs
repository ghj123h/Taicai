// 180903 Key: y/no/b/25/7/1-09-0900
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai180903
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("y");
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("no");
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("b", 1.25);
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("25", 1.25, a => Problem.NumberMethod("25", a, 1.25, 0.75));
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("7", 1.0, a => Problem.OffsetMethod("7", a, 1.0, 0.9));
			list.Add(tmp);
			// Problem 6
			tmp = new Problem("1-09-0900", 21.0 / 31.0, Method321);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		public static double Method321(string answer)
		{
			int date = 0;
			switch(answer.Length)
			{
				case 1:
					return Problem.DefaultMethod("1", answer, 0.5);
				case 2:
					return Problem.OffsetMethod("9", answer, 1.0, 8.0 / 9.0);
				case 4:
					if(!int.TryParse(answer, out date))
					{
						return 0.0;
					}
					date = (date / 100) * 60 + date % 100;
					return Problem.NumberMethod("540", date.ToString(), 2.0, 0.07);
				default:
					return 0.0;
			}
		}
	}
}