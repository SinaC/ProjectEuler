using System;
using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem27 : Problem
    {
        public Problem27() : base(27)
        {
        }

        public override string Solve()
        {
            bool[] sieve = Tools.BuildSieve(1000 * 1000 + 1000 * 1000 + 1000);
            int bestCount = 0;
            long bestA = 0;
            long bestB = 0;
            for (long a = -1000; a <= 1000; a++)
            {
                if (a == 0)
                    continue;
                for (long b = -1000; b <= 1000; b++)
                {
                    if (b == 0)
                        continue;
                    int count = 0;
                    for (long n = 0; n < Math.Abs(a); n++)
                    { // !! should test if primes are consecutive
                        long number = n * n + a * n + b;
                        if (number > 0 && !sieve[number])
                            count++;
                        else
                            break;
                    }
                    if (count > bestCount)
                    {
                        bestA = a;
                        bestB = b;
                        bestCount = count;
                    }
                }
            }
            long result = bestA*bestB;
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
