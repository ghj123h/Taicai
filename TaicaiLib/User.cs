using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class User
    {
        internal List<UserLottery> list;

        public string Name { get; set; }
        public double TotalScore { get; internal set; }
        
        public IEnumerable<UserLottery> History { get => list; }

        public User(string name)
        {
            Name = name;
            TotalScore = 0.0;
            list = new List<UserLottery>();
        }
    }
}
