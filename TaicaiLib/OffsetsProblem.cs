using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class OffsetsProblem : Problem
    {
        public Dictionary<int, double> Offsets { get; set; }

        public OffsetsProblem(double key, Dictionary<int, double> offsets, double fullScore = 1.0)
        {
            Key = key.ToString();
            Offsets = new Dictionary<int, double>(offsets);
            FullScore = fullScore;
        }

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
