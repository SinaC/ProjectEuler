using System.Globalization;

namespace ProjectEuler
{
    public class Problem306 : ProblemBase
    {
        public Problem306() : base(306)
        {
        }

        public override string Solve()
        {
            //http://huangyun.wikispaces.com/Project+Euler+Solution+306
            //http://arxiv.org/pdf/quant-ph/0311018
            ulong n = 1000000;
            ulong q = n / 34;
            ulong r = n % 34;
            // winning positions - losing positions
            ulong result = n - (Sub(n, 1) + Sub(n, 15) + Sub(n, 35) + 5 * q + Sub(r, 5) + Sub(r, 9) + Sub(r, 21) + Sub(r, 25) + Sub(r, 29));
            return result.ToString(CultureInfo.InvariantCulture);
        }

        private static ulong Sub(ulong a, ulong b)
        {
            return (a >= b) ? (ulong)1 : (ulong)0;
        }

    }
}
