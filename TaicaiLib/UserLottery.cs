using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TaicaiLib
{
    [Serializable]
    public class UserLottery
    {
        private string rawAnswer;
        internal List<Answer> answers;
        public string RawAnswer { get => rawAnswer; }
        public IEnumerable<Answer> Answers { get => answers; }
        public User User { get; private set; }
        public Lottery Lottery { get; internal set; }
        public double RawScore { get; internal set; }
        public double AdjustedScore { get; internal set; }
        public int Rank { get; internal set; }

        public UserLottery(string answer, User user, Lottery lottery)
        {
            rawAnswer = Regex.Replace(answer, @"[^0-9a-z/\.\-]", string.Empty, RegexOptions.Compiled);
            User = user;
            Lottery = lottery;
            answers = new List<Answer>();
            var _answers = rawAnswer.Split('/');
            int i = 0;
            foreach (var problem in lottery.Problems)
            {
                answers.Add(new Answer(problem, _answers[i++]));
            }
            Lottery.Add(this);
            // user.list.Add(this);
            RawScore = AdjustedScore = 0;
        }
    }
}
