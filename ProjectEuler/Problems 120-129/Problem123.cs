using System.Globalization;

namespace ProjectEuler
{
    public class Problem123 : ProblemBase
    {
        public Problem123() : base(123)
        {
        }

        public override string Solve()
        {
            // Same as 120 except a are prime numbers
            const ulong limit = 10000000000;
            const ulong sieveLimit = 1000000; // sqrt limit
            bool[] sieve = Tools.Tools.BuildSieve(sieveLimit);
            ulong pn = 3;
            ulong n = 2;
            while (true)
            {
                // If n = 1, remainder = 2*p1 = 2*2 which doesn't break the limit
                // If n is even, remainder = 2 which doesn't break the limit
                // So, we are looking for odd n
                if (0 != (n & 1))
                { // remainder = 2an only if odd
                    ulong remainder = 2 * pn * n;
                    if (remainder >= limit)
                        return n.ToString(CultureInfo.InvariantCulture);
                }
                // Next prime
                pn += 2;
                while (sieve[pn])
                    pn += 2;
                n++;
            }
            //return 0;
        }
    }
}
