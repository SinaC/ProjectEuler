using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem130 : ProblemBase
    {
        public Problem130() : base(130)
        {
        }

        public override string Solve()
        {
            List<ulong> numbers = new List<ulong>();
            numbers.AddRange(new ulong[] { 91, 259, 451, 481, 703 });
            ulong n = numbers[numbers.Count - 1] + 2;
            while (true)
            {
                // Don't consider prime
                if (!Primes.Check.IsPrime(n) && 1 == Tools.Tools.GCD(n, 10))
                {
                    // Compute An
                    ulong an = 1;
                    ulong x = 1;
                    // Search repunit divisible by n
                    while (x != 0)
                    {
                        x = (x * 10 + 1) % n;
                        an++;
                    }
                    // n-1 is composite and divisible by A(n)
                    if (0 == ((n - 1) % an))
                        numbers.Add(n);
                    if (25 == numbers.Count)
                        break;
                }
                n += 2; // Only odd numbers
            }
            return numbers.Aggregate<ulong, ulong>(0, (current, number) => current + number).ToString(CultureInfo.InvariantCulture);
        }
    }
}
