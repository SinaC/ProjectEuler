using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem45 : ProblemBase
    {
        public Problem45() : base(45)
        {
        }

        public override string Solve()
        {
            const ulong start = 40755;
            // Triangle         T(n) = n(n+1)/2
            // Pentagonal 	  	P(n) = n(3n-1)/2
            // Hexagonal 	  	H(n) = n(2n-1)
            ulong n = (ulong)(1 + Math.Sqrt(8 * start + 1)) / 4; // from Hexagonal  2*n^2 - n - H(n) = 0 --> n = ( 1 + sqrt(8*H(n)+1) ) / 4
            // No need to test Triangle because they are a subset of hexagonal
            ulong result;
            while (true)
            {
                n++;
                // Compute next hexagonal
                ulong hexagonal = Tools.Tools.Hexagonal(n);
                // Check if pentagonal  n = ( 1 + sqrt(24*P(n)+1) ) + 6
                if (Tools.Tools.IsPentagonal(hexagonal))
                {
                    result = hexagonal;
                    break;
                }
            }
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
