using System.Globalization;
using System.Numerics;
using Primes;

namespace ProjectEuler
{
    public class Problem216 : ProblemBase
    {
        public Problem216() : base(216)
        {
        }

        //TODO: https://oeis.org/A056220
        [TooSlow]
        public override string Solve()
        {
            const int limit = 50000000;

            ulong count = 0;
            ulong n = 1;
            while(true)
            {
                BigInteger tn = 2*n*n - 1;
                bool isPrime = Check.IsPrimeMillerRabin(tn);
                if (isPrime)
                    count++;
                if (n >= limit)
                    break;
                n++;
            }

            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
