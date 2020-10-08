using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示多选题。
    /// </summary>
    [Serializable]
    public class MultipleProblem : DefaultProblem
    {
        private bool flag;

        /// <summary>
        /// 用指定的答案、作答方式和满分初始化 <see cref="MultipleProblem"/> 的新实例。
        /// </summary>
        /// <param name="key">题目的答案。</param>
        /// <param name="flag">如果作答中选项之间以-为分隔，则为 true；如果选项均为单个字母且作答为直接组合，则为 false。</param>
        /// <param name="fullScore">题目的满分。</param>
        public MultipleProblem(string key, bool flag = false, double fullScore = 1.25)
            : base(key, fullScore)
        {
            this.flag = flag;
        }

        /// <inheritdoc />
        public override double GetScore(string answer)
        {
            if (!flag)
            {
                if (answer == "") return 0;
                var _key = Key.Distinct();
                var _answer = answer.Distinct();
                int choices = _key.Count();
                var right = _answer.Intersect(_key).Count();
                var wrong = _answer.Except(_key).Count();
                return right > wrong ? ((right - wrong) * 1.0 / choices) * FullScore : 0;
            }
            else
            {
                string[] answers = answer.Split("-".ToCharArray()), keys = Key.Split("-".ToCharArray());
                int cap, except;
                cap = answers.Intersect(keys).Count();
                except = answers.Except(keys).Count();
                if (cap < except)
                {
                    return 0;
                }
                else
                {
                    return (cap - except) * FullScore / keys.Length;
                }
            }
        }
    }
}
