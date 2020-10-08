using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示必须回答完全正确的题目。
    /// </summary>
    [Serializable]
    public class DefaultProblem : Problem
    {
        /// <summary>
        /// 用指定的答案和满分初始化 <see cref="DefaultProblem"/> 的新实例。
        /// </summary>
        /// <param name="key">题目的答案。</param>
        /// <param name="fullScore">题目的满分。</param>
        public DefaultProblem(string key, double fullScore = 1)
        {
            Key = key;
            FullScore = fullScore;
        }

        /// <inheritdoc />
        public override double GetScore(string answer)
        {
            if (Key != answer)
            {
                return 0;
            }
            else
            {
                return FullScore;
            }
        }
    }
}
