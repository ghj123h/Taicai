using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class DefaultProblem : Problem
    {
        public DefaultProblem(string key, double fullScore = 1)
        {
            Key = key;
            FullScore = fullScore;
        }

        public override double GetScore(string answer)
        {
            if (Key != answer)
            {
                return 0;
            }
            else
            {
                return FullScore;
            }
        }
    }
}
