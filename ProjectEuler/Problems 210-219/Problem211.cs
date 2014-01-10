using System;

namespace ProjectEuler
{
    //https://oeis.org/A046655
    // sum of square divisors = sigma2
    public class Problem211
    {
        [TooSlow]
        public ulong Solve()
        {
            const ulong limit = 64000000;

            ulong[] sigma2 = Sigma2(limit - 1);
            ulong sum = 0;
            for (ulong i = 1; i < limit; i++)
            {
                if (Tools.IsPerfectSquare(sigma2[i]))
                    sum += i;
            }
            return sum;
        }

        private static ulong[] Sigma2(ulong n)
        {
            // If i has a prime factor p <= sqrt, then quasiPrimeFactor[i] = p.
            // Otherwise i > sqrt must be prime, and quasiPrimeFactor[i] = 0 because i may overflow an int16.
            ulong sqrt = (ulong)Math.Sqrt(n + 0.5);
            ulong[] quasiPrimeFactor = new ulong[n + 1];

            // Richer version of the sieve of Eratosthenes
            for (ulong i = 2; i <= sqrt; i++)
            {
                if (quasiPrimeFactor[i] == 0)
                {
                    quasiPrimeFactor[i] = i;
                    if (i*i <= n)
                    {
                        for (ulong j = i*i; j <= n; j += i)
                        {
                            if (quasiPrimeFactor[j] == 0)
                                quasiPrimeFactor[j] = i;
                        }
                    }
                }
            }

            ulong[] sigma2 = new ulong[n + 1];
            sigma2[1] = 1;
            for (ulong i = 2; i < (ulong)sigma2.Length; i++)
            {
                ulong p = quasiPrimeFactor[i];
                if (p == 0)
                    p = i;
                ulong sum = 1;
                ulong j = i;
                ulong p2 = p * p;
                for (ulong k = p2; j % p == 0; j /= p, k *= p2)
                    sum += k;
                sigma2[i] = sum * sigma2[j];
            }
            return sigma2;
        }
    }
}
