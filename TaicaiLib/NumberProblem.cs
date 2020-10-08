using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示数字题或答案可以转换为数字的题目。
    /// </summary>
    [Serializable]
    public class NumberProblem : Problem
    {
        /// <summary>
        /// 获取当前题目作答的标准差。
        /// </summary>
        /// <value>当前题目作答的标准差。</value>
        /// <remarks>
        /// 即章程 7.3.2.2 定义的 {\sigma}_j。
        /// </remarks>
        public double Deviation { get; internal set; }

        /// <summary>
        /// 获取或设置当前题目作答转化为数字的方法。
        /// </summary>
        /// <value>当前题目作答转化为数字的方法。</value>
        /// <remarks>
        /// 默认值是 <see cref="double.Parse(string)"/>
        /// </remarks>
        public Func<string,double> Transformation { get; set; }

        protected double _key;
        [Obsolete]
        public static readonly double ACE = Math.Log(0.13) * (-0.2);
        [Obsolete]
        public static readonly double HHMMSS = Math.Log(10) / 600;

        /// <summary>
        /// 用指定的答案和满分初始化 <see cref="NumberProblem"/> 的新实例。
        /// </summary>
        /// <param name="key">题目的答案。</param>
        /// <param name="fullScore">题目的满分。</param>
        public NumberProblem(string key, double fullScore = 1.5)
        {
            Key = key;
            _key = Transformation(Key);
            Deviation = 1;
            FullScore = fullScore;
            Transformation = double.Parse;
        }

        /// <summary>
        /// 返回指定数字的标准正态分布 p 值（即大phi函数）。
        /// </summary>
        /// <param name="x">要求 p 值的数字</param>
        /// <returns>与 <paramref name="x"/> 对应的标准正态分布 p 值</returns>
        public static double CND(double x)
        {
            const double A1 = 0.31938153;
            const double A2 = -0.356563782;
            const double A3 = 1.781477937;
            const double A4 = -1.821255978;
            const double A5 = 1.330274429;
            double K = 1.0 / (1.0 + 0.2316419 * Math.Abs(x));
            double w = 1.0 - 1.0 / Math.Sqrt(Math.PI * 2) * Math.Exp(-x * x / 2)
                * (A1 * K + A2 * K * K + A3 * Math.Pow(K, 3) + A4 * Math.Pow(K, 4) + A5 * Math.Pow(K, 5));
            return x < 0 ? 1 - w : w;
        }

        internal virtual double GetDeviation(IEnumerable<string> answers) // refer to Lottery.UpdateData();
        {
            List<double> theAnswers = new List<double>();
            foreach (var answer in answers)
            {
                try
                {
                    theAnswers.Add(Transformation(answer));
                }
                catch (Exception)
                {
                }
            }
            if (theAnswers.Count <= 1)
            {
                return 1.0;
            }
            double aver = theAnswers.Average();
            double dev = Math.Sqrt(theAnswers.Sum(x => (x - aver) * (x - aver)) / (theAnswers.Count - 1));
            var selected = theAnswers.Where(x => Math.Abs(x - aver) <= 3 * dev).ToList();
            aver = selected.Average();
            dev = Math.Sqrt(selected.Sum(x => (x - aver) * (x - aver)) / (selected.Count - 1));
            return dev;
        }

        /// <inheritdoc />
        public override double GetScore(string answer)
        {
            double _answer;
            if (answer == "" || !double.TryParse(answer, out _answer))
            {
                return 0;
            }
            return 2 * FullScore * CND(-Math.Abs(_answer - _key) / Deviation);
        }
    }
}
