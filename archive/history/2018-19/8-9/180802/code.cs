// 180802 Key: n/10/zj/42/wp/1817
using System;
using System.Collections.Generic;
using TaicaiLib;

namespace Taicai180802
{
	// [Serializable]
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("n");
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("10", 1.0, a => Problem.OffsetMethod("10", a, 1.0, 0.7));
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("zj");
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("42", 1.0, a => {
				Dictionary<int, double> offsets = new Dictionary<int, double>();
				offsets.Add(2, 0.75);
				offsets.Add(3, 0.75);
				return Problem.OffsetMethod("42", a, 1.0, offsets);
			});
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("wp");
			list.Add(tmp);
			// Problem 6
			tmp = new Problem("1817-18-192403", 57.0 / 53.0, Method321);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		public static double Method321(string answer)
		{
			switch(answer.Length)
			{
				case 2:
					return Problem.DefaultMethod("18", answer, 2.0);
				case 4:
					return Problem.DefaultMethod("1817", answer, 1.0);
				case 6:
					return Problem.TimeMethod("192403", answer, 3.0);
				default:
					return 0;
			}
		}
	}
}