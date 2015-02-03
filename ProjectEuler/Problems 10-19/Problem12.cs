using System;
using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem12 : ProblemBase
    {
        public Problem12()
            : base(12)
        {
        }

        public override string Solve()
        {
            const uint divisorCountLimit = 500;
            uint position = 2;
            ulong triangle = 1; // First triangle number
            while (true) {
                int divisorCount = 0; // Count divisor
                int sqrtN = (int)(Math.Sqrt(triangle)+0.5);
                for (uint j = 1; j <= sqrtN; j++)
                    if (0 == (triangle % j))
                        divisorCount += 2;
                if (divisorCount > divisorCountLimit) // Stop when 500 divisors are found
                    break;
                triangle += position; // Next triangle number
                position++;
            }
            return triangle.ToString(CultureInfo.InvariantCulture);
        }
    }
}
