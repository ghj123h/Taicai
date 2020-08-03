// 181101 Key: n/de/91/5.5/65/a
using System;
using System.Collections.Generic;
using TaicaiLib;

namespace Taicai181101
{
	public class ProblemFactory
	{
		public static IEnumerable<Problem> GetProblems()
		{
			List<Problem> list = new List<Problem>();
			Problem tmp;
			// Problem 1
			tmp = new DefaultProblem("n");
			list.Add(tmp);
			// Problem 2
			tmp = new MultipleProblem("de");
			list.Add(tmp);
			// Problem 3
			tmp = new DefaultProblem("91");
			list.Add(tmp);
			// Problem 4
			tmp = new OffsetProblem(5.5, 0.87, 0.5);
			list.Add(tmp);
			// Problem 5
			tmp = new OffsetProblem(65, 0.87, 5);
			list.Add(tmp);
			// Problem 6
			tmp = new DefaultProblem("a");
			list.Add(tmp);
			return list;
		}
		
		// Score Methods
	}
}

/*
...HURRICANE FORCE WIND WARNING...
.LOW E OF AREA NEAR 56N30W 959 MB MOVING SE 10 KT. OVER FORECAST
WATERS FROM 52N TO 65N E OF 38W WINDS 50 TO 65 KT. SEAS 24 TO 38
FT. ELSEWHERE WITHIN 540 NM SW AND 480 NM NW QUADRANTS WINDS 40
TO 50 KT. SEAS 18 TO 30 FT. ALSO WITHIN 900 NM SW AND 720 NM NW
QUADRANTS WINDS 25 TO 40 KT. SEAS 12 TO 24 FT.
.2 4 HOUR FORECAST LOW E OF AREA NEAR 55N23W 970 MB. WITHIN 540
NM W AND BETWEEN 600 NM AND 720 NM NW QUADRANTS WINDS 25 TO 40
KT. SEAS 13 TO 26 FT.
.48 HOUR FORECAST LOW WELL E OF AREA. N OF A LINE FROM 57N43W TO
61N35W WINDS 25 TO 40 KT. SEAS 15 TO 22 FT.
*/