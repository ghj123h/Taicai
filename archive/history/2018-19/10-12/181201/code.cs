// 181201 Key: 4/55/0/489/y/-
using System;
using System.Linq;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181201
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("4");
			list.Add(tmp);
			// Problem 2
			tmp = new NumberProblem(55, 0.46, 1.25);
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(0, 1.008, 1);
			list.Add(tmp);
			// Problem 4
			tmp = new MultipleProblem("489");
			list.Add(tmp);
			// Problem 5
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 6
			tmp = new Problem6();
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		[Serializable]
		public class Problem6 : Problem
		{
			private Dictionary<char, List<int>> times = new Dictionary<char, List<int>>();
			
			public Problem6()
			{
				int[] p = new int []{
					1022, 1147, 1148, 2151, 2256, 1022, 1127, 2236, 2311, 1106, 1141, 2215, 2250, 2355, 1046, 1121, 1225, 2226, 2229, 2334, 1100, 1101, 1205, 2311, 2313, 2348, 1039, 1145, 2253, 2328, 1124, 1159, 2305, 2306,
					2232, 2308, 1004, 1108, 1109, 2212, 2247, 1045, 1120, 2153, 2154, 2226, 2228, 2229, 1023, 1025, 1100, 2205, 2208, 2311, 2313, 1039, 1144, 2147, 2148, 2252, 2253, 2327, 1018, 1123, 1156, 2232, 2233, 2305, 2307
				};
				int[] b = new int[] {
					348, 453, 1450, 1555, 327, 431, 1534, 1609, 306, 307, 411, 1511, 1514, 1548, 245, 350, 1453, 1528, 1632
				};
				int[] c = new int[] {
					828, 903, 2105, 2141, 843, 948, 2045, 2120
				};
				times.Add('p', p.Distinct().Select(t => t / 100 * 60 + t % 100).ToList());
				times.Add('b', b.Distinct().Select(t => t / 100 * 60 + t % 100).ToList());
				times.Add('c', c.Distinct().Select(t => t / 100 * 60 + t % 100).ToList());
				FullScore = 1.5;
				Key = "-";
			}
			
			public override double GetScore(string answer)
			{
				int time;
				char ocean = answer[0];
				answer = answer.Substring(1);
				if (!int.TryParse(answer, out time) || !times.ContainsKey(ocean))
				{
					return 0.0;
				}
				time = time / 100 * 60 + time % 100;
				int offset = times[ocean].Min(t => Math.Abs(t - time));
				double result = Math.Exp(-NumberProblem.HHMMSS * 60 * offset) * FullScore;
				return result >= 0.01 ? result : 0;
			}
		}
	}
}