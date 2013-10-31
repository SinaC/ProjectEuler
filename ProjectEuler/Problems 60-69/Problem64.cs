using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem64
    {
        public ulong Solve()
        {
            const ulong limit = 10000;
            ulong count = 0;
            for (ulong n = 2; n <= limit; n++)
            {
                ulong sqrtN = (ulong)Math.Sqrt(n);
                if (sqrtN * sqrtN == n)
                    continue;
                List<ulong> continuedFraction = Tools.SqrtContinuedFraction(n);
                if (0 == (continuedFraction.Count & 1)) // odd period <- even list item count
                    count++;
            }
            return count;
        }
    }
}
