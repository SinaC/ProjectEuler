using System.Collections.Generic;
using Primes;

namespace ProjectEuler
{
    public class Problem248
    {
        //http://mathforum.org/kb/message.jspa?messageID=6745284
        //http://en.wikipedia.org/wiki/Euler's_totient_function
        //http://www.numbertheory.org/php/carmichael.htmls
        public ulong Solve()
        {
            // phi(n) = phi(p1^k1 * p2^k2 * p3^k3 * ...) where p are prime divisor and k highest exponent of prime divisor
            //        = n*(1-1/p1)*(1-1/p2)*(1-1/p3)*...
            // phi(p) = p-1  where p is prime
            // 13! = 13 * 12 * 11 * 10 * 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1
            //     = 13^1 * 2^2*3^1 * 11^1 * 2^1*5^1 * 3^2 * 2^3 * 7^1 * 2^1*3^1 * 5^1 * 2^2 * 3^1 * 2^1
            //     = 2^10 * 3^5 * 5^2 * 7 * 11 * 13
            //     = 6227020800
            // phi(6227180929) = 6227020800
            // 6227180929 = 66529 * 93601
            // phi(66529) = 66528 = 2^5 * 3^3 * 7 * 11
            // phi(93601) = 93600 = 2^5 * 3^2 * 5^2 * 13

            // 1th:     6227180929 = 66529 * 93601
            // 10th:    6227267713 = 28513 * 218401
            // 100th:   6239393627 = 811 * 2081 * 3697
            // 1000th:  6359386477 = 79 * 163 * 631 * 661

            // split prime factorization of 13! in every combinations of factors, multiply factor+1, sort then take 150000th
            // sample: 
            //  split into 2*3*13 and 2*3^4 and 2*3^2*5*7 and 2^2*3*5*11
            //              78          162         630         660
            //  79*163*631*661

            List<ulong> res = new List<ulong>();
            List<ulong> primes = new List<ulong>();
            for (int i = 0; i <= 10; i++) // 2 max power 10
                for (int j = 0; j <= 5; j++) // 3 max power 5
                    for (int k = 0; k <= 2; k++) // 5 max power 2
                        for (int l = 0; l <= 1; l++) // 7 max power 1
                            for (int m = 0; m <= 1; m++) // 11 max power 1
                                for (int n = 0; n <= 1; n++) // 13 max power 1
                                {
                                    ulong num = Power(2, i) * Power(3, j) * Power(5, k) * Power(7, l) * Power(11, m) * Power(13, n);
                                    if (Check.IsPrime(num+1))
                                        primes.Add(num + 1);
                                }
            primes.Sort();
            Sub(primes, res, primes.Count, 1, 6227020800);
            res.Sort();
            return res[150000];
        }

        private static ulong Power(ulong a, int b)
        {
            ulong ret = 1;
            for (int i = 0; i < b; i++)
                ret *= a;
            return ret;
        }

        private static void Sub(List<ulong> primes, List<ulong> res, int top, ulong cur, ulong rem)
        {
            if (rem == 1)
                res.Add(cur);
            for (int i = top - 1; i >= 0; i--)
            {
                ulong p = primes[i];
                if (rem % (p - 1) != 0)
                    continue;
                Sub(primes, res, i, cur*p, rem/(p - 1));
                ulong trem = rem/(p - 1);
                ulong tcur = cur*p;
                while (trem % p == 0)
                {
                    trem /= p;
                    tcur *= p;
                    Sub(primes, res, i, tcur, trem);
                }
            }
        }

    }
}
