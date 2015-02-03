using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem99 : ProblemBase
    {
        public Problem99() : base(99)
        {
        }

        public override string Solve()
        {
            // a^b > c^d  <==> b*ln(a) > d*ln(c) with a, b, c, d > 1
            int lineNumber = 1;
            double bestPower = 1;
            int bestLineNumber = 1;
            foreach(string line in Lines)
            {
                string[] tokens = line.Split(',');
                ulong b = Convert.ToUInt64(tokens[0]);
                ulong e = Convert.ToUInt64(tokens[1]);
                double power = e * Math.Log(b);
                if (power > bestPower)
                {
                    bestPower = power;
                    bestLineNumber = lineNumber;
                }
                lineNumber++;
            }
                return bestLineNumber.ToString(CultureInfo.InvariantCulture);
        }
    }
}
