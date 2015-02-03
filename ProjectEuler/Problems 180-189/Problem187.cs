using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem187 : ProblemBase
    {
        public Problem187() : base(187)
        {
        }

        public override string Solve()
        {
            // Brute-force
            // TODO:
            // using prime array
            // foreach prime p1
            //   binary search in prime array to find the biggest p2 such as p1*p2 < limit
            //   count += index p2 - index p1 + 1
            const ulong limit = 100000000;
            const ulong sieveLimit = limit / 2;
            ulong sqrtLimit = (ulong)(Math.Sqrt(limit) + 0.5);
            bool[] sieve = Tools.Tools.BuildSieve(1 + sieveLimit);
            ulong count = 0;
            for (ulong i = 2; i <= sqrtLimit; i++)
            {
                if (sieve[i]) continue;
                for (ulong j = i; j <= sieveLimit; j++)
                {
                    if (sieve[j]) continue;
                    ulong product = i*j;
                    if (product >= limit)
                        break; // once the limit is reached, next product will also exceed limit
                    count++;
                }
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
