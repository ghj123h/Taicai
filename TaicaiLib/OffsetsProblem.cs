using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示以不同偏差值计算得分的题目。
    /// </summary>
    [Serializable]
    public class OffsetsProblem : Problem
    {
        /// <summary>
        /// 获取或设置偏差值与得分减少比例的关系。
        /// </summary>
        /// <value>偏差值与得分减少比例的关系。</value>
        public Dictionary<int, double> Offsets { get; set; }

        /// <summary>
        /// 用指定的答案、计分方式和满分初始化 <see cref="OffsetsProblem"/> 的新实例。
        /// </summary>
        /// <param name="key">题目的答案。</param>
        /// <param name="offsets">偏差值与得分减少比例的关系。</param>
        /// <param name="fullScore">题目的得分。</param>
        public OffsetsProblem(double key, Dictionary<int, double> offsets, double fullScore = 1.0)
        {
            Key = key.ToString();
            Offsets = new Dictionary<int, double>(offsets);
            FullScore = fullScore;
        }

        /// <inheritdoc />
        public override double GetScore(string answer)
        {
            if (answer == "") return 0;
            int _key = int.Parse(Key), _answer;
            if (!int.TryParse(answer, out _answer))
            {
                return 0;
            }
            if (Key == answer) return FullScore;
            int os = Math.Abs(_key - _answer);
            if (Offsets.ContainsKey(os))
            {
                return (1 - Offsets[os]) * FullScore;
            }
            return 0;
        }
    }
}
