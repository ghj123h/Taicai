using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class TimeProblem : NumberProblem
    {
        public TimeProblem(string key, double fullScore = 1.5)
            : base(Time2Number(key), fullScore)
        {
            Key = key;
            Transformation = Time2Number;
        }

        public static double Time2Number(string time)
        {
            if (time.Length < 4) return -1;
            int number = ((time[0] - '0') * 10 + time[1] - '0') * 3600 + ((time[2] - '0') * 10 + time[3] - '0') * 60;
            if (time.Length == 4)
            {
                return number;
            }
            else if (time.Length == 6)
            {
                return number + (time[4] - '0') * 10 + time[5] - '0';
            }
            else
            {
                return -1;
            }
        }

        public override double GetScore(string answer)
        {
            double _answer = Time2Number(answer);
            if (_answer == -1)
            {
                return 0;
            }
            double score = CND(-Math.Min(Math.Abs(_answer - _key), 86400 - Math.Abs(_answer - _key)) / Deviation) * 2 * FullScore;
            if (Key.Length == 6 && answer[5] == Key[5] && answer[4] == Key[4])
            {
                score += FullScore / 13;
                score = Math.Min(FullScore, score);
            }
            return score;
        }
    }
}
