using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaicaiLib
{
    [Serializable]
    public class MultipleProblem : DefaultProblem
    {
        private bool flag;

        public MultipleProblem(string key, bool flag = false, double fullScore = 1.25)
            : base(key, fullScore)
        {
            this.flag = flag;
        }

        public override double GetScore(string answer)
        {
            if (!flag)
            {
                if (answer == "") return 0;
                var _key = Key.Distinct();
                var _answer = answer.Distinct();
                int choices = _key.Count();
                var right = _answer.Intersect(_key).Count();
                var wrong = _answer.Except(_key).Count();
                return right > wrong ? ((right - wrong) * 1.0 / choices) * FullScore : 0;
            }
            else
            {
                string[] answers = answer.Split("-".ToCharArray()), keys = Key.Split("-".ToCharArray());
                int cap, except;
                cap = answers.Intersect(keys).Count();
                except = answers.Except(keys).Count();
                if (cap < except)
                {
                    return 0;
                }
                else
                {
                    return (cap - except) * FullScore / keys.Length;
                }
            }
        }
    }
}
