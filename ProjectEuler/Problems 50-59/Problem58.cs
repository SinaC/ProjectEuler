using System.Globalization;

namespace ProjectEuler
{
    public class Problem58 : ProblemBase
    {
        public Problem58() : base(58)
        {
        }

        public override string Solve()
        {
            // Corners: n^2-3n+3, n^2-2n+2, n^2-n+1, n^2
            // diagonal count = 2*(n-1)+1 with n odd
            ulong n = 3;
            ulong primeCount = 0;
            while (true)
            {
                ulong c0 = n * n - 3 * n + 3;
                ulong c1 = n * n - 2 * n + 2;
                ulong c2 = n * n - n + 1;
                //ulong c3 = n * n; // never a prime
                if (Primes.Check.IsPrime(c0))
                    primeCount++;
                if (Primes.Check.IsPrime(c1))
                    primeCount++;
                if (Primes.Check.IsPrime(c2))
                    primeCount++;
                ulong count = 2 * (n - 1) + 1;
                if (10 * primeCount <= count)
                    break;
                n += 2;
            }
            return n.ToString(CultureInfo.InvariantCulture);
        }
    }
}
