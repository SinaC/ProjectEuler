using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem9 : Problem
    {
        public Problem9() : base(9)
        {
        }

        public override string Solve()
        {
            for (ulong a = 1; a < 500; a++)
                for (ulong b = a+1; b < 500; b++)
                    // a^2 + b^2 = c^2
                    // a + b + c = 1000
                    if (a * a + b * b == (1000 - a - b) * (1000 - a - b))
                        return (a * b * (1000 - a - b)).ToString(CultureInfo.InvariantCulture);
            return "0";
        }
    }
}
