using System;

namespace ProjectEuler
{
    public class Problem131
    {
        public ulong Solve()
        {
            //http://en.wikipedia.org/wiki/Cuban_prime
            // cuban prime: 3*x^2 - 3*x + 1 = p
            const ulong limit = 1000000;
            bool[] sieve = Tools.BuildSieve(limit);
            ulong count = 0;
            bool fStop = false;
            ulong i = 3;
            while (!fStop)
            {
                if (!sieve[i])
                {
                    // Compute x and reinject in equation, if equals to prime then it's a solution
                    ulong x = (ulong)((-3.0 + Math.Sqrt(9.0 - 12.0 * (1.0 - (double)i))) / 6.0);
                    ulong p = 3 * x * (x + 1) + 1;
                    if (p == i)
                        count++;
                }
                i += 2;
                if (i >= limit)
                    break;
                while (!fStop && sieve[i])
                {
                    i += 2;
                    if (i >= limit)
                        fStop = true;
                }
            }
            return count;
        }
    }
}
