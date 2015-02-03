using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem105 : ProblemBase
    {
        public Problem105()
            : base(105)
        {
        }

        public override string Solve()
        {
            ulong total = 0;
            foreach (string line in Lines)
            {
                string[] numbers = line.Split(',');
                ulong[] set = new ulong[numbers.Length];
                int idx = 0;
                foreach (string number in numbers)
                    set[idx++] = Convert.ToUInt64(number);
                if (Tools.Tools.IsSpecialSet(set))
                    total = set.Aggregate(total, (current, val) => current + val);
            }
            return total.ToString(CultureInfo.InvariantCulture);
        }
    }
}
