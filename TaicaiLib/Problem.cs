using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public abstract class Problem
    {
        public string Key { get; set; }
        public double ScorePercent { get => Difficulty == 0 ? 0 : Math.Exp((1 - Difficulty) * 4); }
        public double Difficulty { get; internal set; }
        public double FullScore { get; set; }

        public abstract double GetScore(string answer);
    }
}
