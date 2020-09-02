using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class NumberProblem : Problem
    {
        public double Deviation { get; internal set; }
        public Func<string,double> Transformation { get; set; }

        protected double _key;
        public static readonly double ACE = Math.Log(0.13) * (-0.2);
        public static readonly double HHMMSS = Math.Log(10) / 600;

        public NumberProblem(double key, double fullScore = 1.5)
        {
            Key = key.ToString();
            _key = key;
            Deviation = 1;
            FullScore = fullScore;
            Transformation = double.Parse;
        }

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

    [Serializable]
    public class NumberNoDotProblem : NumberProblem
    {
        public double FullScoreWithoutDot { get; set; }
        public NumberNoDotProblem(double key, double fullScore = 1.5)
               : base(key, fullScore)
        {
            Transformation = s =>
            {
                if (s.Contains("."))
                {
                    return double.Parse(s);
                }
                else
                {
                    throw new FormatException();
                }
            };
            FullScoreWithoutDot = fullScore;
        }

        public virtual double GetScoreWithoutDot(string answer)
        {
            return 0;
        }

        public override double GetScore(string answer)
        {
            if (answer.Contains("."))
            {
                return base.GetScore(answer);
            }
            else
            {
                return GetScoreWithoutDot(answer);
            }
        }
    }
}
