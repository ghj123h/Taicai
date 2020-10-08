using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示答案中含有多个数字的数字题。
    /// </summary>
    public class NumbersProblem : NumberProblem
    {
        protected double[] _keys;

        /// <summary>
        /// 用指定的满分和答案初始化 <see cref="NumbersProblem"/> 的新实例。
        /// </summary>
        /// <param name="fullScore">题目的满分。</param>
        /// <param name="keys">题目的答案。</param>
        public NumbersProblem(double fullScore, params double[] keys)
            : base("0.0", fullScore) // _key is dummy.
        {
            Transformation = x => 0.0; // Transformation is also dummy.
            _keys = keys.ToArray();
        }

        /// <summary>
        /// 将包含有多个数字的作答转换成等效的双精度浮点数组。
        /// </summary>
        /// <param name="answer">包含有多个数字的作答字符串。</param>
        /// <returns>与 <paramref name="answer"/> 等效的双精度浮点数组。</returns>
        /// <exception cref="FormatException"><paramref name="answer"/> 不是有效的多数字答案。</exception>
        /// <exception cref="ArgumentException"><paramref name="answer"/> 包含的数字个数与当前 <see cref="NumbersProblem"/> 实例的答案不符。</exception>
        public double[] FromAnswer(string answer)
        {
            string[] elems = answer.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            double[] answers;
            try
            {
                answers = elems.Select(x => double.Parse(x)).ToArray();
            }
            catch (Exception)
            {
                throw new FormatException();
            }
            if (answer.Length != _keys.Length)
            {
                throw new ArgumentException("作答数字数目与题目不符。", "answer");
            }
            return answers;
        }

        private double GetSquaredDistance(double[] x, double[] y)
        {
            return x.Zip(y, (a, b) => Math.Pow(a - b, 2)).Sum();
        }

        internal override double GetDeviation(IEnumerable<string> answers)
        {
            List<double[]> theAnswers = new List<double[]>();
            foreach (var answer in answers)
            {
                theAnswers.Add(FromAnswer(answer));
            }
            if (theAnswers.Count <= 1)
            {
                return 1.0;
            }
            double[] aver = theAnswers.Aggregate((x, y) => x.Zip(y, (a, b) => (a + b) / theAnswers.Count).ToArray());
            double var = theAnswers.Sum(x => GetSquaredDistance(x, aver)) / (theAnswers.Count - 1);
            return Math.Sqrt(var);
        }

        /// <inheritdoc />
        public override double GetScore(string answer)
        {
            try
            {
                double[] _answer = FromAnswer(answer);
                return 2 * FullScore * CND(-Math.Sqrt(GetSquaredDistance(_answer, _keys)) / Deviation);
            }
            catch (Exception)
            {
                return 0.0;
            }
        }
    }
}
