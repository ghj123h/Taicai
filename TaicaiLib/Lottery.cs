using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class Lottery : List<UserLottery>
    {
        private List<Problem> list;

        public string Number { get; set; }
        public IEnumerable<Problem> Problems { get => list; }

        public double BaseScore { get; set; }
        public double Deviation { get; set; }
        public bool HasSeasonalProblem { get; set; }
        public bool IsSeasonalLottery { get; set; }

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

        public void UpdateData()
        {
            int m = list.Count, n = Count;
            double aver = 0.0, s;
            for (int i = 0; i < m; i++)
            {
                double sum = 0.0;
                if (this[0].answers[i].Problem is NumberProblem)
                {
                    NumberProblem np = (NumberProblem)this[0].answers[i].Problem;
                    List<double> theAnswers = new List<double>();
                    for (int j = 0; j < n; j++)
                    {
                        try
                        {
                            if (np is NumberNoDotProblem)
                            {
                                if (this[j].answers[i].TheAnswer.Contains("."))
                                {
                                    throw new FormatException();
                                }
                            }
                            theAnswers.Add(np.Transformation(this[j].answers[i].TheAnswer));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    double _aver = theAnswers.Average();
                    np.Deviation = Math.Sqrt(theAnswers.Sum(x => (x - _aver) * (x - _aver)) / (theAnswers.Count - 1));
                    var selected = theAnswers.Where(x => Math.Abs(x - _aver) <= 3 * np.Deviation).ToList();
                    // Console.WriteLine(np.Deviation);
                    _aver = selected.Average();
                    np.Deviation = Math.Sqrt(selected.Sum(x => (x - _aver) * (x - _aver)) / (selected.Count - 1));
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
