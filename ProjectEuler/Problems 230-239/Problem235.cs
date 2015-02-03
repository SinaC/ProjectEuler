using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem235 : ProblemBase
    {
        public Problem235() : base(235)
        {
        }

        public override string Solve()
        {
            // u(k) = (900-3k) * r^(k-1)
            // s(n) = sum(k=1->n,u(k))
            // find r for which s(5000) = -600000000000
            // s(n) is a monotonic decreasing function, so we can use a binary search to find r
            // may divide s(n) by 3
            // u(k) = (300-k) * r^(k-1)
            // s(n) = sum(k=1->n,u(k))
            // find r for which s(5000) = -200000000000
            const double target = -200000000000;
            const int count = 5000;
            double r = 1;
            double delta = 0.125;
            double sum = 0;
            while (Math.Abs(sum - target) > 1)
            {
                sum = 0;
                for (int i = 1; i <= count; i++)
                    sum += (300 - (double)i) * Math.Pow(r, i - 1);
                if (sum > target)
                    r = (r + delta);
                else
                    r = (r - delta);
                delta *= 0.5;
            }
            return Math.Round(r, 12).ToString(CultureInfo.InvariantCulture).Replace(',', '.');
        }
    }
}
