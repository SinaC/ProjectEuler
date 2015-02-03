using System.Globalization;

namespace ProjectEuler
{
    public class Problem163 : ProblemBase
    {
        public Problem163() : base(163)
        {
        }

        public override string Solve()
        {
            //http://www.math.uni-bielefeld.de/~sillke/SEQUENCES/grid-triangles
            const ulong n = 36;
            const ulong a60 = n * (n + 2) * (2 * n + 1) / 8 + 2 * ((3 * n * n - 1) * n / 6);
            const ulong a90 = 6 * (n * (n + 1) * (n + 2) / 6 + (((2 * n + 5) * n + 2) * n) / 8 + (((2 * n + 3) * n - 3) * n) / 18 + ((2 * n + 3) * n - 3) * n / 10);
            const ulong a120 = 3 * (((22 * n + 45) * n - 4) * n / 48);
            return (a60 + a90 + a120).ToString(CultureInfo.InvariantCulture);
        }
    }
}
