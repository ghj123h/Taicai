using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示以一定偏差值计算得分的题目。
    /// </summary>
    [Serializable]
    public class OffsetProblem : Problem
    {
        /// <summary>
        /// 获取或设置题目中的偏差单位。
        /// </summary>
        /// <value>题目中的偏差单位。</value>
        public double Offset { get; set; }

        /// <summary>
        /// 获取或设置作答与答案每偏差 <see cref="Offset"/> 得分所减少的比例。
        /// </summary>
        /// <value>作答与答案每偏差 <see cref="Offset"/> 得分所减少的比例。</value>
        public double Discount { get; set; }

        /// <summary>
        /// 获取或设置作答最多可以偏离答案 <see cref="Offset"/> 的数量。
        /// </summary>
        /// <value>作答最多可以偏离答案 <see cref="Offset"/> 的数量。</value>
        public int Length { get; set; }

        private double _key;

        /// <summary>
        /// 用指定的答案、计分方式和满分初始化 <see cref="OffsetProblem"/> 的新实例。
        /// </summary>
        /// <param name="key">题目的答案。</param>
        /// <param name="discount">作答与答案每偏差 <paramref name="offset"/> 所减少的比例。</param>
        /// <param name="offset">题目的偏差单位。</param>
        /// <param name="length">作答最多可以偏离答案 <paramref name="offset"/> 的数量。</param>
        /// <param name="fullScore">题目的满分。</param>
        public OffsetProblem(double key, double discount, double offset = 1, int length = 999, double fullScore = 1.0)
        {
            Key = key.ToString();
            _key = key;
            Offset = offset;
            Discount = discount;
            Length = length;
            FullScore = fullScore;
        }

        /// <inheritdoc />
        public override double GetScore(string answer)
        {
            if (answer == "") return 0;
            double _answer;
            if (!double.TryParse(answer, out _answer))
            {
                return 0;
            }
            double os = Math.Abs(_key - _answer);
            if (os <= Length * Offset)
            {
                double score = FullScore - Discount * Math.Ceiling(os / Offset - 1e-6) * FullScore;
                return score > 0 ? score : 0;
            }
            return 0;
        }
    }
}
