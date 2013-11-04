using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem125
    {
        public ulong Solve()
        {
            // Sum square of every consecutive number from a to b and store the result if it's palindromic
            const ulong limit = 100000000;
            ulong sqrtLimit = (ulong)Math.Sqrt(limit);
            Dictionary<ulong, ulong> dict = new Dictionary<ulong, ulong>();
            for (ulong i = 1; i <= sqrtLimit; i++)
            {
                ulong sumSquare = i * i;
                for (ulong j = i + 1; j <= sqrtLimit; j++)
                { // sum consecutive number from i to limit
                    sumSquare += j * j;
                    if (sumSquare >= limit)
                        break; // No need to continue, further addition will also exceed limit
                    if (Tools.IsPalindromic(sumSquare, 10))
                        if (!dict.ContainsKey(sumSquare))
                            dict.Add(sumSquare, i);
                }
            }
            return dict.Aggregate<KeyValuePair<ulong, ulong>, ulong>(0, (current, kv) => current + kv.Key);
        }
    }
}
