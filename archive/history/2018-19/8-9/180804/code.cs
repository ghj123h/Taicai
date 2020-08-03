// 180804 Key: gw/29/superty/1.0/n/-
using System;
using System.Collections.Generic;

using TaicaiLib;

namespace Taicai180804
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new Problem("gw");
			list.Add(tmp);
			// Problem 2
			tmp = new Problem("29");
			list.Add(tmp);
			// Problem 3
			tmp = new Problem("superty");
			list.Add(tmp);
			// Problem 4
			tmp = new Problem("1.0");
			list.Add(tmp);
			// Problem 5
			tmp = new Problem("n");
			list.Add(tmp);
			// Problem 6
			tmp = new Problem("-", 1.25, Method6);
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
		public static double Method6(string answer)
		{
			int[] longtitude = new int [] {
				1570, 1566, 1563, 1561, 1556, 1549, 1544, 1541,
				1535, 1528, 1523, 1520, 1514, 1510, 1505, 1499,
				1491, 1487, 1481, 1474, 1469, 1461, 1454, 1448,
				1442, 1435, 1427, 1422, 1415, 1409, 1403, 1397,
				1392, 1388, 1383, 1378, 1373, 1369, 1365, 1362,
				1358, 1354, 1350, 1348, 1344, 1342, 1338, 1336
			}, latitude = new int[] {
				154,  158,  162,  163,  166,  167,        168,
				170,  171,  173,              174,        175,
				      176,  177,        178,  179,
			          181,  183,        185,  187,  191,  193,
				196,  199,  204,  207,  210,  214,  218,  222,
				225,  232,  237,  242,  245,  250,  255,  259
			}, ansarray = null;
			int ans = 0;
			foreach(char c in answer)
			{
				if (Char.IsDigit(c))
				{
					ans = ans * 10 + c - '0';
				}
				else if (c == 'n')
				{
					ansarray = latitude;
				}
				else if (c == 'e')
				{
					ansarray = longtitude;
					Array.Reverse(ansarray);
				}
			}
			if (ansarray == null) return 0.0;
			for (int i = 0; i < ansarray.Length; i++)
			{
				if (ansarray[i] > ans)
				{
					if (i == 0 || ansarray[i - 1] + ansarray[i] < ans * 2)
					{
						return Problem.NumberMethod(ansarray[i].ToString(), ans.ToString(), 1.25, 2);
					}
					else
					{
						return Problem.NumberMethod(ansarray[i - 1].ToString(), ans.ToString(), 1.25, 2);
					}
				}
			}
			return Problem.NumberMethod(ansarray[ansarray.Length - 1].ToString(), ans.ToString(), 1.25, 2);
		}
	}
}