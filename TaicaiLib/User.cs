using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    /// <summary>
    /// 表示台彩的玩家。
    /// </summary>
    [Serializable]
    public class User
    {
        internal List<UserLottery> list;

        /// <summary>
        /// 获取或设置玩家的用户名。
        /// </summary>
        /// <value>玩家的用户名。</value>
        public string Name { get; set; }

        /// <summary>
        /// 获取玩家的总分。
        /// </summary>
        /// <value>玩家的总分。</value>
        public double TotalScore { get; internal set; }

        /// <summary>
        /// 获取玩家参与所有台彩的可枚举集合。
        /// </summary>
        /// <value>玩家参与所有台彩的可枚举集合。</value>
        public IEnumerable<UserLottery> History { get => list; }

        /// <summary>
        /// 用指定的用户名初始化 <see cref="User"/> 的新实例。
        /// </summary>
        /// <param name="name">指定的用户名。</param>
        public User(string name)
        {
            Name = name;
            TotalScore = 0.0;
            list = new List<UserLottery>();
        }
    }
}
