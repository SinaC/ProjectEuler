using System.Globalization;

namespace ProjectEuler
{
    public class Problem52 : ProblemBase
    {
        public Problem52():base(52)
        {
        }

        public override string Solve()
        {
            ulong n = 1;
            ulong result;
            while (true)
            {
                ulong hash = Hash(n);
                if (
                    hash == Hash(n * 2)
                    && hash == Hash(n * 3)
                    && hash == Hash(n * 4)
                    && hash == Hash(n * 5)
                    && hash == Hash(n * 6)
                    )
                {
                    result = n;
                    break;
                }

                n++;
            }
            return result.ToString(CultureInfo.InvariantCulture);
        }

        private static ulong Hash(ulong n)
        {
            ulong r = 1;
            while (n > 0)
            {
                r *= Tools.Tools.Primes10[n % 10];
                n /= 10;
            }
            return r;
        }
    }
}
