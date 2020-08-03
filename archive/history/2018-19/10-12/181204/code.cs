// 181204 Key: y/6/-31.95/988/sppwspp/11.02252594279929131865350544166
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai181204
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("y");
			list.Add(tmp);
			// Problem 2
			tmp = new DefaultProblem("6");
			list.Add(tmp);
			// Problem 3
			tmp = new NumberProblem(-31.95, NumberProblem.ACE * 2);
			list.Add(tmp);
			// Problem 4
			tmp = new NumberProblem(988, 0.504, 1);
			list.Add(tmp);
			// Problem 5
			tmp = new Problem5();
			list.Add(tmp);
			// Problem 6
			tmp = new NumberProblem(2.1775 / 19.755 * 100, NumberProblem.ACE);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		
	}
	
	[Serializable]
	public class Problem5 : Problem
	{
		public Problem5()
		{
			Key = "sppwspp";
			FullScore = 1.25;
		}
		
		public override double GetScore(string answer)
		{
			if (Key.Contains(answer))
			{
				return FullScore * answer.Length / Key.Length;
			}
			return 0;
		}
	}
}