using System;
using System.Collections.Generic;
using System.Linq;

using TaicaiLib;

namespace Taicai19S01
{
	public class TotalGenerator
	{
		public static double GetSpecializedTotalScore(User u)
		{
			return u.History.Sum(ul => {
				int wind = (int)((ul.AdjustedScore - ul.Lottery.BaseScore) / ul.Lottery.Deviation * 25 + 67.5) / 5 * 5;
				return wind > 30 ? wind * wind / 10000.0 : 0;
			});
		}
	}
}