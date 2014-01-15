using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primes;

namespace ProjectEuler
{
    public class Problem358
    {
        public ulong Solve()
        {
            //http://blog.cyclopsgroup.org/2011/11/cyclic-numbers-project-euler-problem.html
            // leftmost:    00000000137
            // rightmost:   56789
            // When multiplied by their generating prime, results in a sequence of 9's. 142857 × 7 = 999999
            // When split in half by its digits and added the result is a sequence of 9's. 142 + 857 = 999
            // All cyclic numbers are divisible by 9
            // 00000000137...56789
            // =>                 v-- half
            // 00000000137...43210|99999999862...56789

            // The first condition restrict the prime to numbers between 1/0.00000000137 and 1/0.00000000138.
            // The second condition means p = -1/56789 mod 10000, so p = 09891 mod 100000

            const ulong firstNumberTail = 56789;
            const ulong lastNumberTail = 43210;
            ulong lengthTail = 0;

            // Iterate through each digit in first number tail to find out each digit and length tail
            for (ulong i = 0, f = 1; i < 5; i++)
            {
                ulong f10 = f * 10;
                for (ulong j = 0; j < 10; j++)
                {
                    ulong factor = f * j + lengthTail;
                    if ((firstNumberTail * factor) % f10 == lastNumberTail % f10)
                    {
                        lengthTail = factor;
                        break;
                    }
                }
                f = f10;
            }

            // starts with 00000000137
            const ulong rangeStart = 99999999999L / 138;
            const ulong rangeEnd = 99999999999L / 137;
            const ulong mod = 100000;

            // 10^(p-1)-1 / p  maybe cyclic if p is prime
            //ulong numbers = 0;
            for (ulong i = rangeStart; i < rangeEnd; i += mod)
            {
                //numbers++;
                // Replace tail with previously calculated length tail
                ulong candidate = (i - (i%mod) + lengthTail) + 1;

                // Filter out non-prime numbers
                if (!Check.IsPrime(candidate))
                    continue;

                // sum is 9*(p-1)/2
                ulong sum = 9*(candidate - 1)/2;
                Console.WriteLine("Candidate {0}  sum {1}", candidate, sum);
            }

            return 0; // candidates have been checked manually


            ////http://en.wikipedia.org/wiki/Cyclic_number
            ////Let b be the number base (10 for decimal)
            ////Let p be a prime that does not divide b.
            ////Let t = 0.
            ////Let r = 1.
            ////Let n = 0.
            ////loop:
            ////Let t = t + 1
            ////Let x = r · b
            ////Let d = int(x / p)
            ////Let r = x mod p
            ////Let n = n · b + d
            ////If r ≠ 1 then repeat the loop.
            ////if t = p − 1 then n is a cyclic number.
            //const ulong limit = 62;
            //bool[] sieve = Tools.BuildSieve(limit);
            //const ulong b = 10;
            //for (ulong p = 7; p < limit; p++)
            //    if (!sieve[p])
            //    {
            //        ulong t = 0;
            //        ulong r = 1;
            //        ulong n = 0;
            //        while (true)
            //        {
            //            t++;
            //            ulong x = r*b; // exceeds 64 bits
            //            ulong d = x/p;
            //            r = x%p;
            //            n = n*b + d; // exceeds 64 bits
            //            if (r == 1)
            //                break;
            //        }
            //        if (t == p - 1)
            //            Console.WriteLine("{0} is cyclic", n);
            //    }
            //return 0;
        }

        //public bool CheckCyclic(ulong n)
        //{

        //}
    }
}