using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示对一道题目的作答。
    /// </summary>
    [Serializable]
    public class Answer
    {
        /// <summary>
        /// 获取或设置当前 <see cref="Answer"/> 实例对应的题目。
        /// </summary>
        /// <value>当前 <see cref="Answer"/> 实例对应的题目。</value>
        public Problem Problem { get; set; }

        /// <summary>
        /// 获取或设置对 <see cref="Problem"/> 的作答。
        /// </summary>
        /// <value>与 <see cref="Problem"/> 对应的作答。</value>
        public string TheAnswer { get; set; }

        /// <summary>
        /// 获取 <see cref="TheAnswer"/> 能得到的分数。
        /// </summary>
        /// <value>得到的分数。</value>
        public double Score { get => Problem.GetScore(TheAnswer); }

        /// <summary>
        /// 用指定的题目和作答初始化 <see cref="Answer"/> 的新实例。
        /// </summary>
        /// <param name="problem">题目。</param>
        /// <param name="answer">与 <paramref name="problem"/> 对应的作答。</param>
        public Answer(Problem problem, string answer)
        {
            Problem = problem;
            TheAnswer = answer;
        }
    }
}
