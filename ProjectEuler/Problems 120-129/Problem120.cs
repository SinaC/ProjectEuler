using System.Globalization;

namespace ProjectEuler
{
    public class Problem120 : ProblemBase
    {
        public Problem120() : base(120)
        {
        }

        public override string Solve()
        {
            // ((a-1)^n + (a+1)^n)/a^2
            // using binomial theorem
            // sum[ Cnk a^(n-k) (-1)^k ] + sum[ Cnk a^(n-k) (1)^k ]
            // if n == 1, (a-1 + a+1)/a^2 => 2a / a^2           remainder is 2a
            // if n is even, terms with a^(k<n) are simplified
            //      (2*a^n + 2*(1)^k)/a^2 -> 2*(a^n + 1)/a^2    remainder is 2
            // if n is odd, after simplification
            //      2a(a^(n-1) + ... + a^((n-1)/2k + .. n)/a^2
            //      a^(n-1), a^((n-1)/2k are divisible by a^2   remainder is 2a*n
            // to maximize remainder, we must maximize 2an with 2an < a^2
            // 2an < a^2 -> 2n < a -> 2n <= a-1 -> n = (a-1)/2
            // n = (a-1)/2
            const ulong limit = 1000;
            ulong sum = 0;
            for (ulong a = 3; a <= limit; a++)
            {
                ulong maxN = (a - 1) / 2;
                sum += 2 * a * maxN;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
