using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace ProjectEuler
{
    public class Problem66
    {
        public string Solve()
        {
            //http://en.wikipedia.org/wiki/Pell%27s_equation#Fundamental_solution_via_continued_fractions
            // X^2 - D*Y^2 = 1
            const ulong limit = 1000;
            BigInteger max = 0;
            ulong maxN = 0;
            for (ulong n = 2; n <= limit; n++)
            {
                ulong sqrtN = (ulong)Math.Sqrt(n);
                if (sqrtN * sqrtN == n)
                    continue; // No solution if D is a square
                // Continued fraction convergent may be injected as X and Y for diophante equation X^2 - DY^2 until result = 1 (X = numerator and Y = denominator)
                List<ulong> continuedFractions = Tools.SqrtContinuedFraction(n);
                BigInteger numerator2 = 1;
                BigInteger denominator2 = 0;
                BigInteger numerator1 = (long)continuedFractions[0];
                BigInteger denominator1 = 1;
                BigInteger numerator;
                BigInteger biN = (long)n;
                int i = 1;
                while (true)
                {
                    BigInteger continuedFraction = (long)continuedFractions[i];
                    numerator = numerator2 + numerator1 * continuedFraction;
                    BigInteger denominator = denominator2 + denominator1 * continuedFraction;
                    BigInteger result = numerator * numerator - biN * denominator * denominator;
                    if (result == 1)
                        break;
                    numerator2 = numerator1;
                    numerator1 = numerator;
                    denominator2 = denominator1;
                    denominator1 = denominator;
                    if (i >= continuedFractions.Count - 1)
                        i = 1;
                    else
                        i++;
                }
                if (numerator > max)
                {
                    maxN = n;
                    max = numerator;
                }
            }
            return maxN.ToString(CultureInfo.InvariantCulture);
        }
    }
}
