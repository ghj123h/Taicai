using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示台彩的题目。
    /// </summary>
    /// <remarks>若要自定义台彩的题目，必须继承此类。</remarks>
    [Serializable]
    public abstract class Problem
    {
        /// <summary>
        /// 获取或设置题目的答案。
        /// </summary>
        /// <value>题目的答案。</value>
        public string Key { get; set; }

        /// <summary>
        /// 获取题目的得分率。
        /// </summary>
        /// <value>题目的得分率。</value>
        public double ScorePercent { get => Difficulty == 0 ? 0 : Math.Exp((1 - Difficulty) * 4); }

        /// <summary>
        /// 获取题目的难度系数。
        /// </summary>
        /// <value>题目的难度系数。</value>
        /// <remarks>
        /// 即章程 7.3.3 节定义的 d_j。
        /// </remarks>
        public double Difficulty { get; internal set; }

        /// <summary>
        /// 获取或设置题目的满分。
        /// </summary>
        /// <value>题目的满分。</value>
        public double FullScore { get; set; }

        /// <summary>
        /// 根据给定的题目作答，返回相应的得分。
        /// </summary>
        /// <param name="answer">要判定得分的作答。</param>
        /// <returns>在本题目中，<paramref name="answer"/> 所能得到的分数。</returns>
        public abstract double GetScore(string answer);
    }
}
