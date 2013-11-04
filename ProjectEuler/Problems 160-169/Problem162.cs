using System;

namespace ProjectEuler
{
    public class Problem162
    {
        public string Solve()
        {
            // Since the first digit is non zero the total possibilities without consideration for the constraints is 15 x 16(n-1).
            // Then remove those with no {0, 1, A}. But we need to add back in those that have no 1 or 0, no 1 or A, no 0 or A.
            // Then remove the duplicates that, again, have no {0, 1, A}
            // 15*16^(n-1) - 2*14*15^(n-1) - 15*15^(n-1) + 13*14^(k-1) + 2*14*14^(k-1) - 13*13^(k-1)
            ulong sum = 0;
            for (ulong i = 3; i <= 16; i++)
                sum += 15 * Tools.Pow(16, i - 1) - (2 * 14 + 15) * Tools.Pow(15, i - 1) + (13 + 2 * 14) * Tools.Pow(14, i - 1) - 13 * Tools.Pow(13, i - 1);
            return String.Format("{0:X}", sum);
        }
    }
}
