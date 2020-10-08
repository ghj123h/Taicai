using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示一期台彩
    /// </summary>
    /// <remarks>
    /// <para>虽然 <see cref="Lottery"/> 类继承自 <see cref="List{UserLottery}"/>，但是不能像使用 <see cref="List{UserLottery}"/> 一般使用 <see cref="Lottery"/> 类。</para>
    /// <para>例如，不能使用 <see cref="List{UserLottery}.Add(UserLottery)"/> 方法来添加一个 <see cref="UserLottery"/>，因为 <see cref="UserLottery"/> 在初始化的时候就已经添加进了 <see cref="Lottery" />。</para>
    /// </remarks>
    [Serializable]
    public class Lottery : List<UserLottery>
    {
        private List<Problem> list; // problems

        /// <summary>
        /// 获取或设置当前台彩的编号。
        /// </summary>
        /// <value>当前台彩的编号。</value>
        /// <remarks>
        /// <para>ghj 一般将台彩编号命名为 YYMMWW，其中 YY 代表年份，MM 代表月份，WW 代表周数。例如，180802 代表 2018 年 8 月第 2 周。</para>
        /// <para>在 TaicaiAnalyze 的实现中，<see cref="Number"/> 的值与子文件夹的名称、生成的 TaicaiXXXXXX.dll 程序集及其 TaicaiXXXXXX 名称空间一致。</para>
        /// <para>另外，如果 <see cref="Number"/> 不能转换一个 <see cref="int"/>，则 TaicaiAnalyze 将会把当前台彩视作长期台彩。</para>
        /// </remarks>
        public string Number { get; set; }

        /// <summary>
        /// 获取当前台彩问题的可枚举集合。
        /// </summary>
        /// <value>当前台彩问题的可枚举集合。</value>
        public IEnumerable<Problem> Problems { get => list; }

        /// <summary>
        /// 获取或设置当前台彩的中央值。
        /// </summary>
        /// <value>当前台彩的中央值。</value>
        /// <remarks>
        /// <para>即章程 7.3.6 一节提到的 \bar{P}，默认值为 50。</para>
        /// <para>在 TaicaiAnalyze 的实现中，如需手动指定 <see cref="BaseScore"/> 属性的值，请在 code.cs 中的 ProblemFactory 内定义公有静态字段 baseScore。</para>
        /// </remarks>
        public double BaseScore { get; set; }

        /// <summary>
        /// 获取或设置当前台彩的标准差。
        /// </summary>
        /// <value>当前台彩的标准差。</value>
        /// <remarks>
        /// <para>即章程 7.3.6 一节提到的 \sigma，默认值为 10。</para>
        /// <para>在 TaicaiAnalyze 的实现中，如需手动指定 <see cref="Deviation"/> 属性的值，请在 code.cs 中的 ProblemFactory 内定义公有静态字段 deviation。</para>
        /// </remarks>
        public double Deviation { get; set; }

        /// <summary>
        /// 获取或设置指示当前台彩是否存在长期题的值。
        /// </summary>
        /// <value>如果当前台彩存在长期题，则为 true；否则为 false。</value>
        /// <remarks>
        /// <para>目前，TaicaiAnalyze 通过根目录下的 lotteries.txt 判定台彩中是否存在长期题，而非使用 <see cref="HasSeasonalProblem"/> 属性。未来 TaicaiAnalyze 的更新可能会修复这一点。</para>
        /// <para>如需手动指定 <see cref="HasSeasonalProblem"/> 属性的值，请在 code.cs 中的 ProblemFactory 内定义公有静态字段 seasonal。</para>
        /// </remarks>
        public bool HasSeasonalProblem { get; set; }

        /// <summary>
        /// 获取或设置指示当前台彩是否为长期台彩的值。
        /// </summary>
        /// <value>如果当前台彩是长期台彩，则为 true；否则为 false。</value>
        /// <remarks>
        /// 在 TaicaiAnalyze 的实现中，<see cref="IsSeasonalLottery"/> 属性的值由 <see cref="Number"/> 决定。
        /// </remarks>
        public bool IsSeasonalLottery { get; set; }

        /// <summary>
        /// 使用指定的编号和问题集合来初始化 <see cref="Lottery"/> 的新实例。
        /// </summary>
        /// <param name="number">台彩的编号。</param>
        /// <param name="problems">台彩的问题可枚举集合。</param>
        /// <exception cref="ArgumentNullException"><paramref name="problems"/> 为 null。</exception>
        public Lottery(string number, IEnumerable<Problem> problems)
            : base()
        {
            if (problems == null)
            {
                throw new ArgumentNullException();
            }
            list = new List<Problem>(problems);
            Number = number;
            BaseScore = 50;
            Deviation = 10;
            HasSeasonalProblem = false;
            IsSeasonalLottery = false;
        }

        /// <summary>
        /// 结算当前台彩的得分情况。
        /// </summary>
        /// <remarks>
        /// 一期 <see cref="Lottery"/> 只能执行一次 <see cref="UpdateData"/>，这是由于 <see cref="UpdateData"/> 方法亦会更新 <see cref="User.TotalScore"/> 属性。
        /// </remarks>
        public void UpdateData()
        {
            int m = list.Count, n = Count;
            double aver = 0.0, s;
            for (int i = 0; i < m; i++)
            {
                double sum = 0.0;
                if (this[0].answers[i].Problem is NumberProblem) // For NumberProblem, we need to find out the Deviation property manually.
                {
                    NumberProblem np = (NumberProblem)this[0].answers[i].Problem;
                    np.Deviation = np.GetDeviation(this.Select(x => x.answers[i].TheAnswer));
                }
                for (int j = 0; j < n; j++)
                {
                    sum += this[j].answers[i].Score;
                }
                if (Math.Abs(sum) > 1e-6)
                {
                    list[i].Difficulty = 1 + Math.Log(n * list[i].FullScore / sum) / 4;
                }
                else
                {
                    list[i].Difficulty = 0;
                }
            }
            for (int j = 0; j < n; j++)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                this[j].Rank = j + 1;
                this[j].RawScore = 0;
                for (int i = 0; i < m; i++)
                {
                    this[j].RawScore += this[j].answers[i].Score * list[i].Difficulty;
                }
                if (!IsSeasonalLottery)
                {
                    this[j].RawScore *= 1 + 0.075 * (1 - j * 1.0 / n);
                }
                if (dict.ContainsKey(this[j].RawAnswer))
                {
                    this[j].RawScore *= 1 - Math.Exp(dict[this[j].RawAnswer]++);
                    this[j].RawScore = Math.Max(this[j].RawScore, 0);
                }
                else
                {
                    dict.Add(this[j].RawAnswer, 1);
                }
                aver += this[j].RawScore;
            }
            aver = this.Average(a => a.RawScore);
            s = this.Average(a => Math.Pow(Math.Abs(aver - a.RawScore), 2));
            s = Math.Sqrt(s);
            for (int j = 0; j < n; j++)
            {
                this[j].AdjustedScore = BaseScore + Deviation * (this[j].RawScore - aver) / s;
                this[j].User.TotalScore += this[j].AdjustedScore;
                this[j].User.list.Add(this[j]);
            }
        }
    }
}
