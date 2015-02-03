using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem183 : ProblemBase
    {
        public Problem183() : base(183)
        {
        }

        public override string Solve()
        {
            // f(k) = (N/k)^k
            // f'(k) = ((N/k)^k)(ln(N/k)-1)
            // max when f'(k) = 0, so when ln(N/k)-1 = 0 => ln(N/k) = 1 => N/k = e => k = N/e
            const ulong limit = 10000;
            long sum = 0;
            for (ulong i = 5; i <= limit; i++) {
                // Compute kMax
                ulong kMax = (ulong)(0.5 + i / Math.E);
                // Check if terminating decimal or not
                // simplify denominator of fraction i/k
                // if the simplified denominator is divisible only by 2s or 5s the number is a terminating decimal
                ulong pgcd = Tools.Tools.GCD(i, kMax);
                kMax /= pgcd; // simplify denominator
                while (0 == (kMax & 1)) // divides by 2 as much as possible
                    kMax /= 2;
                while (0 == (kMax % 5)) // divides by 5 as much as possible
                    kMax /= 5;
                if (1 == kMax) // terminating
                    sum -= (long)i;
                else
                    sum += (long)i;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
