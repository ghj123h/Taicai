using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class OffsetProblem : Problem
    {
        public double Offset { get; set; }
        public double Discount { get; set; }
        public int Length { get; set; }

        private double _key;

        public OffsetProblem(double key, double discount, double offset = 1, int length = 999, double fullScore = 1.0)
        {
            Key = key.ToString();
            _key = key;
            Offset = offset;
            Discount = discount;
            Length = length;
            FullScore = fullScore;
        }

        public override double GetScore(string answer)
        {
            if (answer == "") return 0;
            double _answer;
            if (!double.TryParse(answer, out _answer))
            {
                return 0;
            }
            double os = Math.Abs(_key - _answer);
            if (os <= Length * Discount)
            {
                double score = FullScore - Discount * Math.Floor(os / Offset + 1e-6) * FullScore;
                return score > 0 ? score : 0;
            }
            return 0;
        }
    }
}
