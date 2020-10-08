using System;

namespace TaicaiLib
{
    /// <summary>
    /// 表示答案为小数时才按数字题方法计分的题目。
    /// </summary>
    /// <remarks>本类主要作为接口使用。例如，可以用于选做题中，某小题必须写作小数的题目。</remarks>
    [Serializable]
    public class DecimalProblem : NumberProblem
    {
        /// <summary>
        /// 获取或设置答案为小数时题目的满分。
        /// </summary>
        /// <value>答案为小数时题目的满分。</value>
        public double DecimalFullScore { get; set; }

        /// <summary>
        /// 用指定的答案和满分初始化 <see cref="DecimalProblem"/> 的新实例。
        /// </summary>
        /// <param name="key">题目的答案。</param>
        /// <param name="fullScore">题目的满分。</param>
        public DecimalProblem(double key, double fullScore = 1.5)
               : base(key.ToString(), fullScore)
        {
            Transformation = s => {
                if (s.Contains("."))
                {
                    return double.Parse(s);
                }
                else
                {
                    throw new FormatException();
                }
            };
            DecimalFullScore = fullScore;
            FullScore = Math.Max(FullScore, DecimalFullScore);
        }

        /// <summary>
        /// 作答不为小数时，返回相应的得分。
        /// </summary>
        /// <param name="answer">要判定得分的非小数作答。</param>
        /// <returns>在本题目中，<paramref name="answer"/> 所能得到的分数。</returns>
        public virtual double GetIntegerScore(string answer)
        {
            return 0;
        }

        /// <inheritdoc />
        public override double GetScore(string answer)
        {
            if (answer.Contains("."))
            {
                return base.GetScore(answer) / FullScore * DecimalFullScore;
            }
            else
            {
                return GetIntegerScore(answer);
            }
        }
    }
}
