using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示答案为 HHMM 或 HHMMSS 格式时间的题目。
    /// </summary>
    [Serializable]
    public class TimeProblem : NumberProblem
    {
        /// <summary>
        /// 用指定的答案和满分初始化 <see cref="TimeProblem"/> 的新实例。
        /// </summary>
        /// <param name="key">题目的答案。</param>
        /// <param name="fullScore">题目的得分。</param>
        public TimeProblem(string key, double fullScore = 1.5)
            : base(Time2Number(key), fullScore)
        {
            Key = key;
            Transformation = Time2Number;
        }

        /// <summary>
        /// 将一个 HHMM 或 HHMMSS 格式的时间转化为一天中的秒数。
        /// </summary>
        /// <param name="time">要转换的 HHMM 或 HHMMSS 格式时间。</param>
        /// <returns>与 <paramref name="time"/> 对应的秒数。若 <paramref name="time"/> 不是一个有效的时间，返回 -1。</returns>
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

        /// <inheritdoc />
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
