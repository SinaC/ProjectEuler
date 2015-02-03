using System.Globalization;

namespace ProjectEuler
{
    public class Problem70 : ProblemBase
    {
        public Problem70() : base(70)
        {
        }

        public override string Solve()
        {
            //// Brute-force too slow
            //ulong limit = 10000000;
            //bool[] sieve = BuildSieve(limit);
            //double minRatio = 9999999999;
            //ulong minN = 0;
            //for (ulong n = 4; n < limit; n++) {
            //    if (sieve[n]) { // no need to test prime number
            //        ulong phiN = Phi(sieve, n);
            //        if (IsPermutation(n, phiN)) {
            //            double ratio = (double)n / (double)phiN;
            //            //if (ratio < minRatio) {
            //            Console.WriteLine("n" + n + "->" + phiN + "|" + ratio);
            //            minRatio = ratio;
            //            minN = n;
            //            //}
            //        }
            //    }
            //}
            //return minN;

            // phi(prime) = prime-1   ==> prime and prime-1 cannot be a permutation of each other
            // to minimize n/phi(n) we have to maximize phi(n)
            // phi(n) = n * (1-1/p1) * (1-1/p2) ... * (1-1/pk) where pk are prime factor of n
            // phi(n) decreases with the number of prime factor
            // we have to minimize the number of factor to maximize phi(n)
            // primes are rejected, so n must be the product of 2 primes
            // n = p1*p2
            // phi(n) = n * (1-1/p1) * (1-1/p2) = n * (p1-1)/p1 * (p2-1)/p2 = (p1-1)*(p2-1)
            const ulong limit = 10000000;
            bool[] sieve = Tools.Tools.BuildSieve(10000); // 2.5*sqrt(limit) to be sure
            double minRatio = double.MaxValue;
            ulong minN = 0;
            for (ulong p1 = 3; p1 < (ulong)sieve.Length; p1 += 2)
            {
                if (sieve[p1]) continue;
                for (ulong p2 = p1 + 2; p2 < (ulong)sieve.Length; p2 += 2)
                {
                    if (sieve[p2]) continue;
                    ulong n = p1 * p2;
                    if (n < limit)
                    {
                        ulong phiN = (p1 - 1) * (p2 - 1);
                        if (Tools.Tools.IsPermutation(n, phiN))
                        {
                            double ratio = (double)n / (double)phiN;
                            if (ratio < minRatio)
                            {
                                //Console.WriteLine("n:" + n + "->" + phiN + "|" + ratio + "|" + p1 + "*" + p2);
                                minRatio = ratio;
                                minN = n;
                            }
                        }
                    }
                }
            }
            return minN.ToString(CultureInfo.InvariantCulture);
        }
    }
}
