using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class Answer
    {
        public Problem Problem { get; set; }
        public string TheAnswer { get; set; }
        public double Score { get => Problem.GetScore(TheAnswer); }

        public Answer(Problem problem, string answer)
        {
            Problem = problem;
            TheAnswer = answer;
        }
    }
}
