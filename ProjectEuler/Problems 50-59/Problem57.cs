using System.Globalization;

namespace ProjectEuler
{
    public class Problem57 : ProblemBase
    {
        public Problem57() : base(57)
        {
        }

        public override string Solve()
        {
            // sqrt(2) = 1 + 1/(2+1/(2+1/(2+...)))
            // 1 + 1/2
            // 1 + 1/(2+1/2)
            // 1 + 1/(2+1/(2+1/2))
            // 1 + 1/(2+1/(2+1/(2+1/2)))
            // a(0) = 0
            // a(1) = 1+1/(2+a(0))            N(1)/D(1) = 3/2
            // a(2) = 1+1/(2+a(1))            N(2)/D(2) = (2*D(1)+N(1)) / (D(1)+N(1))
            // a(n) = 1+1/(2+a(n-1))          N(n)/D(n) = (2*D(n-1)+N(n-1)) / (D(n-1)+N(n-1))
            ulong count = 0;
            string previousNumerator = "1";
            string previousDenominator = "1";
            for (int i = 1; i <= 1000; i++)
            {
                string denominator = Tools.Tools.SumString(previousNumerator, previousDenominator);
                string numerator = Tools.Tools.SumString(denominator, previousDenominator);
                previousNumerator = numerator;
                previousDenominator = denominator;
                if (numerator.Length > denominator.Length)
                    count++;
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
