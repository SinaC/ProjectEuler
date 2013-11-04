using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem151
    {
        public string Solve()
        {
            double result = Cut(1, 1, 1, 1);
            return Math.Round(result, 6).ToString(CultureInfo.InvariantCulture).Replace(',', '.');
        }

        private double Cut(ulong a2, ulong a3, ulong a4, ulong a5)
        {
            ulong sheets = a2 + a3 + a4 + a5;
            if (0 == sheets)
                return 0;
            double singles = (1 == sheets && a5 == 0) ? 1 : 0;
            if (a2 > 0)
                singles += (double)a2 * Cut(a2 - 1, a3 + 1, a4 + 1, a5 + 1);
            if (a3 > 0)
                singles += (double)a3 * Cut(a2, a3 - 1, a4 + 1, a5 + 1);
            if (a4 > 0)
                singles += (double)a4 * Cut(a2, a3, a4 - 1, a5 + 1);
            if (a5 > 0)
                singles += (double)a5 * Cut(a2, a3, a4, a5 - 1);
            return singles / (double)sheets;

        }
    }
}
