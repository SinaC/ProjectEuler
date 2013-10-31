using System;

namespace ProjectEuler
{
    public class Problem12
    {
        public ulong Solve()
        {
            const uint divisorCountLimit = 500;
            uint position = 2;
            ulong triangle = 1; // First triangle number
            while (true) {
                int divisorCount = 0; // Count divisor
                int sqrtN = (int)Math.Sqrt(triangle);
                for (uint j = 1; j <= sqrtN; j++)
                    if (0 == (triangle % j))
                        divisorCount += 2;
                if (divisorCount > divisorCountLimit) // Stop when 500 divisors are found
                    break;
                triangle += position; // Next triangle number
                position++;
            }
            return triangle;
        }
    }
}
