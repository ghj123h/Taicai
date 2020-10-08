using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TaicaiLib
{
    /// <summary>
    /// 表示一期台彩中一名玩家的信息。
    /// </summary>
    [Serializable]
    public class UserLottery
    {
        private string rawAnswer;
        internal List<Answer> answers;

        /// <summary>
        /// 获取当前玩家对当期台彩的作答。
        /// </summary>
        /// <value>当前玩家对当期台彩的作答。</value>
        public string RawAnswer { get => rawAnswer; }

        /// <summary>
        /// 获取当前玩家对当期台彩每一题作答的可枚举集合。
        /// </summary>
        /// <value>当前玩家对当期台彩每一题的作答。</value>
        public IEnumerable<Answer> Answers { get => answers; }

        /// <summary>
        /// 获取本实例表示的玩家。
        /// </summary>
        /// <value>本实例表示的玩家。</value>
        public User User { get; private set; }

        /// <summary>
        /// 获取本实例表示的台彩。
        /// </summary>
        /// <value>本实例表示的台彩。</value>
        public Lottery Lottery { get; internal set; }

        /// <summary>
        /// 获取当前玩家在当期台彩的原始得分。
        /// </summary>
        /// <value>当前玩家在当期台彩的原始得分。</value>
        public double RawScore { get; internal set; }

        /// <summary>
        /// 获取当前玩家在当期台彩的得分。
        /// </summary>
        /// <value>当前玩家在当期台彩的得分。</value>
        public double AdjustedScore { get; internal set; }

        /// <summary>
        /// 获取当前玩家在当期台彩的排名。
        /// </summary>
        /// <value>当前玩家在当期台彩的排名。</value>
        public int Rank { get; internal set; }

        /// <summary>
        /// 用指定的作答、玩家和台彩初始化 <see cref="UserLottery"/> 的新实例。
        /// </summary>
        /// <param name="answer"><paramref name="user"/> 对 <paramref name="lottery"/> 的作答。</param>
        /// <param name="user">玩家。</param>
        /// <param name="lottery">台彩。</param>
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
