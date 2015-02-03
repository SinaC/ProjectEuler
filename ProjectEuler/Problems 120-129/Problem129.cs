using System.Globalization;

namespace ProjectEuler
{
    public class Problem129 : ProblemBase
    {
        public Problem129() : base(129)
        {
        }

        public override string Solve()
        {
            const ulong limit = 1000000;
            ulong n = limit + 1;
            while (true)
            {
                if (1 == Tools.Tools.GCD(n, 10))
                {
                    // Compute An
                    ulong an = 1;
                    ulong x = 1;
                    // Search repunit divisible by n
                    while (x != 0)
                    {
                        x = (x * 10 + 1) % n;
                        an++;
                    }
                    if (an > limit)
                        break;
                }
                n += 2; // Only odd numbers
            }
            return n.ToString(CultureInfo.InvariantCulture);
        }
    }
}
