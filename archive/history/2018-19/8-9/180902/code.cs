// 180902 Key: 2.0/2/2/orange/3.0270373/0100-0900
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai180902
{
	public class ProblemFactory
	{
		public static Dictionary<string, double> table6 = new Dictionary<string, double>();
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("2.0", 1.0, a => {
				a = a.Replace(".", string.Empty);
				Dictionary<int, double> dict = new Dictionary<int, double>();
				dict.Add(5, 0.75);
				return Problem.OffsetMethod("20", a, 1.0, dict);
			});
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("2", 1.0, a => Problem.OffsetMethod("2", a, 1.0, 0.87));
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("2");
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("orange");
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("3.0270373", 1.5, a => Problem.NumberMethod("3.0270373", a, 1.5, 9.0812942));
			list.Add(tmp);
			// Problem 6
			table6.Add("0100", 1.25); table6.Add("0900", 1.25);
			table6.Add("0030", 1.25 * 0.75); table6.Add("0130", 1.25 * 0.75); table6.Add("0830", 1.25 * 0.75); table6.Add("0930", 1.25 * 0.75);
			table6.Add("0000", 1.25 * 0.50); table6.Add("0200", 1.25 * 0.50); table6.Add("0800", 1.25 * 0.50); table6.Add("1000", 1.25 * 0.50);
			table6.Add("2330", 1.25 * 0.25); table6.Add("0230", 1.25 * 0.25); table6.Add("0730", 1.25 * 0.25); table6.Add("1030", 1.25 * 0.25);
			tmp = new Problem("0100-0900", 1.25, a => {
				if (table6.ContainsKey(a)) {
					return table6[a];
				} else {
					return 0.0;
				}
			});
			list.Add(tmp);
			return list;
		}
	}
}