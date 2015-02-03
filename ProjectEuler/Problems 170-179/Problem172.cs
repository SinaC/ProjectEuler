using System.Globalization;

namespace ProjectEuler
{
    public class Problem172 : ProblemBase
    {
        public Problem172() : base(172)
        {
        }

        public override string Solve()
        {
            return ((Sub(10, 18) * 9) / 10).ToString(CultureInfo.InvariantCulture); // *9/10 to remove leading zeroes
        }

        private static ulong Cnk(ulong n, ulong k)
        {
            // n!/(k!(n-k)!)
            ulong result = 1;
            for (ulong i = k + 1; i <= n; i++)
                result *= i;
            for (ulong i = 1; i <= (n - k); i++)
                result /= i;
            return result;
        }
        
        private static ulong Sub(ulong d, ulong p)
        {
            if (0 == d)
                return 0;
            if (p < 4)
                return Tools.Tools.Pow(d, p);
            return Sub(d - 1, p) + p * Sub(d - 1, p - 1) + Cnk(p, 2) * Sub(d - 1, p - 2) + Cnk(p, 3) * Sub(d - 1, p - 3);
        }
    }
}
