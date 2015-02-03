using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem72 : ProblemBase
    {
        public Problem72() : base(72)
        {
        }

        public override string Solve()
        {
            // 1: /
            // 2: 1/2
            // 3: 1/3 2/3
            // 4: 1/4 3/4
            // 5: 1/5 2/5 3/5 4/5
            // 6: 1/6 5/6
            // 7: 1/7 2/7 3/7 4/7 5/7 6/7
            // 8: 1/8 3/8 5/8 7/8
            // 9: 1/9 2/9 4/9 5/9 7/9 8/9
            // number of reduced fraction with denominator d = phi(d)


            //// Brute-force too slow
            //ulong limit = 1000000;
            //bool[] sieve = BuildSieve(limit);
            //ulong sum = 0;
            //for (ulong d = 2; d <= limit; d++)
            //    sum += Phi(sieve,d);
            //return sum;

            // Initialize phi(n) with n
            // each time we find a prime, for each multiple of this prime we'll multiply phi(prime*multiple) by (1-1/prime)
            const ulong limit = 1000000;
            bool[] sieve = new bool[limit + 1];
            for (int i = 0; i < sieve.Length; i++)
                sieve[i] = true;
            ulong[] phi = new ulong[limit + 1];
            for (int i = 0; i < phi.Length; i++)
                phi[i] = (ulong)i;
            // some values are hard-coded
            sieve[0] = false;
            sieve[1] = false;
            // Phi sieve
            for (ulong n = 2; n <= limit; n++)
                if (sieve[n])
                {
                    phi[n] = n - 1; // phi of a prime is prime-1
                    for (ulong multiple = 2; n * multiple <= limit; multiple++)
                    {
                        sieve[n * multiple] = false;
                        phi[n * multiple] = (phi[n * multiple] * (n - 1)) / n; // a*(1-1/p) = a*(p-1)/p
                    }
                }
            ulong sum = phi.Aggregate<ulong, ulong>(0, (current, p) => current + p);
            return (sum - 1).ToString(CultureInfo.InvariantCulture); // -1 because 1 doesn't give a reduced fraction
        }
    }
}
