using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem30 : ProblemBase
    {
        public Problem30() : base(30)
        {
        }

        public override string Solve()
        {
            // UpperBound: 6*9^5  any six-digit larger than 6*9^5 cannot have a digit-power-sum larger than this
            ulong sum = 0;
            for (ulong i = 2; i <= 6 * 9 * 9 * 9 * 9 * 9; i++)
            {
                string s = i.ToString(CultureInfo.InvariantCulture);
                ulong digitPowerSum = s.Select(Tools.Tools.ToUInt64).Aggregate<ulong, ulong>(0, (current, digit) => current + digit*digit*digit*digit*digit);
                if (digitPowerSum == i)
                    sum += i;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
