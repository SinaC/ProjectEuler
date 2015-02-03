using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem197 : ProblemBase
    {
        public Problem197() : base(197)
        {
        }

        public override string Solve()
        {
            // No need to compute until n = 10^12 because Un 9 first decimals doesn't change after a few iterations
            // So, we loop until we have enough precision
            double un2 = 0;
            double un1 = 0;
            double un = -1; // U0
            //ulong n = 1;
            while (Math.Abs(un - un2) > 0.00000000001)
            { // 11 decimals to be sure
                un2 = un1;
                un1 = un;
                un = Math.Floor(Math.Pow(2, 30.403243784 - un1 * un1)) * 0.000000001;
                //Console.WriteLine(n + "->" + Un + "  " + (Un + Un_1));
                //n++;
            }
            return Math.Round(un + un1, 9).ToString(CultureInfo.InvariantCulture).Replace(',', '.');
        }
    }
}
