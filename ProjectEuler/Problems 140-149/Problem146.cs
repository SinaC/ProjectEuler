using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem146 : ProblemBase
    {
        public Problem146() : base(146)
        {
        }

        [TooSlow]
        public override string Solve()
        {
            //// 2 hours to complete
            //// 10, 315410, 927070, 2525870, 8146100, 16755190, 39313460, 97387280, 119571820, 121288430, 130116970, 139985660
            //// n^2+1, n^2+3, n^2+7, n^2+9, n^2+13, n^2+27 consecutive primes
            //const ulong limit = 150000000;
            //ulong sum = 0;
            //for (ulong i = 10; j <= limit; j+=10) {
            //    if (0 == (i % 3))
            //        continue;
            //    if ((i + 4) % 7 > 1) // n % 7 must be 3 or 4
            //        continue;
            //    ulong n = (i * i);
            //    if (0 == (n % 3) || 0 == (n % 7) || 0 == (n % 13))
            //        continue;
            //    if (IsPrime(n + 13) && IsPrime(n + 3) && IsPrime(n + 7) && IsPrime(n + 9) && IsPrime(n + 1) && IsPrime(n + 27)
            //        && !IsPrime(n + 19) && !IsPrime(n + 21)) {
            //        Console.WriteLine(i+"-->"+n);
            //        sum += i;
            //    }
            //}
            //return 0;

            const ulong limit = 150000000;
            List<ulong> list = new List<ulong>();
            //
            for (ulong n = 10; n <= limit; n += 10)
            {
                if (0 == (n % 3)) continue;
                if ((n + 4) % 7 > 1) continue; // n % 7 must be 3 or 4
                ulong n2 = n * n;
                if (0 == (n2 % 3) || 0 == (n2 % 7) || 0 == (n2 % 13)) continue;
                // Prime test
                ulong p = 11;
                while (true)
                {
                    // Check prime conditions
                    if ((n2 + 27) % p <= 27)
                    {
                        if (0 == (n2 + 1) % p) break;
                        if (0 == (n2 + 3) % p) break;
                        if (0 == (n2 + 7) % p) break;
                        if (0 == (n2 + 9) % p) break;
                        if (0 == (n2 + 13) % p) break;
                        if (0 == (n2 + 27) % p) break;
                    }
                    // Next prime
                    p += 2;
                    if (0 == (p % 3)) p += 2;
                    if (p > n + 1)
                    { // every prime under sqrt(n2) has been checked
                        // Found a candidate
                        // Check 'consecutivness'
                        if (Primes.Check.IsPrime(n2 + 19)) break;
                        if (Primes.Check.IsPrime(n2 + 21)) break;
                        list.Add(n);
                        break;
                    }
                }
            }
            //
            return list.Aggregate<ulong, ulong>(0, (current, item) => current + item).ToString(CultureInfo.InvariantCulture);
        }
    }
}
