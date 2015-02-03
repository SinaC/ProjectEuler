using System.Globalization;

namespace ProjectEuler
{
    public class Problem112 : ProblemBase
    {
        public Problem112() : base(112)
        {
        }

        public override string Solve()
        {
            ulong n = 100; // no bouncy below 100
            ulong count = 0;
            while (true)
            {
                string s = n.ToString(CultureInfo.InvariantCulture);
                // Increasing/Decreasing
                bool fIncreasing = true;
                bool fDecreasing = true;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] < s[i - 1])
                        fIncreasing = false;
                    if (s[i] > s[i - 1])
                        fDecreasing = false;
                    if (!fDecreasing && !fIncreasing)
                        break;
                }
                if (!fIncreasing && !fDecreasing)
                    count++;
                if (100 * count >= 99 * n)
                    break;
                n++;
            }
            return n.ToString(CultureInfo.InvariantCulture);
        }
    }
}
