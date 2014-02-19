using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem23 : Problem
    {
        public Problem23() : base(23)
        {
        }

        public override string Solve()
        {
            const ulong limit = 28123;
            // Get list of abundants
            List<ulong> abundants = new List<ulong>();
            for (ulong i = 12; i <= limit; i++)
            {
                ulong sum = Tools.SumOfDivisors(i);
                if (sum > 2 * i)
                    abundants.Add(i);
            }
            // Compute every combination of sum of 2 abundants
            bool[] check = new bool[limit + 1];
            for (ulong i = 0; i <= limit; i++) check[i] = false;
            foreach (ulong i in abundants)
                foreach (ulong j in abundants)
                {
                    ulong sum = i + j;
                    if (sum <= limit)
                        check[sum] = true;
                }
            // Sum numbers not equal to sum of 2 abundants
            ulong uncheckedSum = 0;
            for (int i = (int)limit; i >= 0; i--)
                if (!check[i])
                    uncheckedSum += (ulong)i;
            return uncheckedSum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
