using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem38 : ProblemBase
    {
        public Problem38() : base(38)
        {
        }

        public override string Solve()
        {
            ulong product;
            // upper bound is 9876 . 9876*2 = 987619752 (9 digits)
            // 12345 . 12345*2 = will have 10 digits
            ulong n = 9876;
            while (true)
            {
                string s = "";
                ulong next = n;
                for (ulong multiplier = 1; multiplier <= 9; multiplier++)
                {
                    s += next.ToString(CultureInfo.InvariantCulture);
                    next = n * (multiplier + 1);
                    if (s.Length + next.ToString(CultureInfo.InvariantCulture).Length > 9)
                        break;
                }
                if (Tools.Tools.IsPandigital(s))
                {
                    product = Convert.ToUInt64(s);
                    break;
                }
                n--;
            }
            return product.ToString(CultureInfo.InvariantCulture);
        }
    }
}
