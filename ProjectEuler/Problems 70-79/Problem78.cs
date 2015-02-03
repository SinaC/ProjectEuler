using System.Globalization;

namespace ProjectEuler
{
    public class Problem78 : ProblemBase
    {
        public Problem78() : base(78)
        {
        }

        public override string Solve()
        {
            //http://www.math.temple.edu/~melkamu/html/partition.pdf
            // Euler's formula:
            // P(n) = sum{k=1}^{n}(-1)^{k+1}[P(n-frac(k(3k-1)))+P(n-frac(k(3k+1)))]
            // P(0) = 1
            const long lastDigits = 1000000;
            const long limit = 100000; // should be enough
            long[] p = new long[limit];
            p[0] = 1;
            long n = 0;
            while (p[n] != 0 && n < limit)
            {
                n++;
                long sum = 0;
                for (long k = 1; k <= n; k++)
                {
                    long mul = ((k & 1) == 0) ? (-1) : (1);
                    long pos1 = n - ((3 * k * k - k) / 2); // pentagonal(k)
                    long pos2 = n - ((3 * k * k + k) / 2); // pentagonal(k)
                    if (pos1 < 0) break;
                    sum += (pos1 >= 0) ? (mul * p[pos1]) : (0);
                    sum += (pos2 >= 0) ? (mul * p[pos2]) : (0);
                }
                while (sum < 0)
                    sum += lastDigits;
                p[n] = (sum % lastDigits); // divisible by 1000000
            }
            return n.ToString(CultureInfo.InvariantCulture);
        }
    }
}
