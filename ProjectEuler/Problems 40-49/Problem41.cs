using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem41 : ProblemBase
    {
        public Problem41() : base(41)
        {
        }

        public override string Solve()
        {
            // Optimisation: we can start with 7654321
            // Because if the digit-sum of number is divisible by 3 so is the number
            // and 9+8+7+6+5+4+3+2+1 = 45 (divisible by 3)
            // and 8+7+6+5+4+3+2+1 = 36 (divisible by 3)

            //ulong limit = 7654321;
            //for (ulong n = limit; n >= 2; n -= 2)
            //    if (IsPandigital(n.ToString()) && IsPrime(n))
            //        return n;
            //return 0;

            const string digits = "7654321";
            string[] permutations = Tools.Tools.Permutations(digits);
            return permutations.Select(s => Convert.ToUInt64(s)).FirstOrDefault(Primes.Check.IsPrime).ToString(CultureInfo.InvariantCulture);
        }
    }
}
