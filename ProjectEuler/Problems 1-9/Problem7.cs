using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem7 : ProblemBase
    {
        public Problem7() : base(7)
        {
        }

        public override string Solve()
        {
            const ulong limit = 10001;
            ulong count = 1;
            ulong prime = 1;

            while (count < limit)
            {
                prime += 2;
                if (Primes.Check.IsPrime(prime))
                    count++;
            }
            return prime.ToString(CultureInfo.InvariantCulture);
        }

        /*
         public ulong Solve() {
            const ulong count = 10001;
            ulong n = 3;
            ulong primeCount = 1; // 2 is a prime
            while (true) {
                if (IsPrime(n)) {
                    primeCount++;
                    if (primeCount == count)
                        return n;
                }
                n += 2; // odd
            }
        }
         */
    }
}
