using System;
using Primes;

namespace ProjectEuler
{
    public class Problem291
    {
        [TooSlow]
        public ulong Solve()
        {
            // use brute-force to get first values: 5, 13, 41, 61, 113, 181, 313, 421, 613, 761, 1013 -> http://oeis.org/A027862
            // n^2 + (n+1)^2
            const ulong limit = 5000000000000000;

            ulong upper = (ulong)(Math.Sqrt(limit)/2);
            Prime prime = new Prime((int)upper);
            prime.GenerateAll();

            Console.WriteLine("upper: {0}", upper);

            ulong count = 0;
            for (ulong n = 0; n <= upper; n++)
            {
                ulong p = n*n + (n + 1)*(n + 1);
                //if (n % 16384 == 0)
                //    Console.WriteLine("TICK:{0} ==> {1}", n, p);
                if (p >= limit)
                    break;
                if (Check.IsPrime(p))
                //if (prime.IsPrime((long)p))
                {
                    count++;
                    //Console.WriteLine("{0} => {1}", n, p);
                }
            }

            return count;
        }
    }
}
