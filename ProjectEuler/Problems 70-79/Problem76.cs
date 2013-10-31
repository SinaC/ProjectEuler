namespace ProjectEuler
{
    public class Problem76
    {
        public ulong Solve()
        {
            //http://www.math.temple.edu/~melkamu/html/partition.pdf
            // Euler's formula:
            // P(n) = sum{k=1}^{n}(-1)^{k+1}[P(n-frac(k(3k-1)))+P(n-frac(k(3k+1)))]
            // P(0) = 1
            const long limit = 100;
            long[] p = new long[limit + 1];
            p[0] = 1;
            for (long i = 1; i <= limit; i++)
            {
                //long sign = +1;
                //p[i] = 0;
                //for (long k = 1; k <= limit; k++) {
                //    long f;
                //    f = k * (3 * k - 1) / 2; // pentagonal(k)
                //    if (f > i)
                //        break;
                //    p[i] += sign * p[i - f];
                //    f = k * (3 * k + 1) / 2;
                //    if (f > i)
                //        break;
                //    p[i] += sign * p[i - f];
                //    sign = -sign;
                //}
                long sum = 0;
                for (long k = 1; k <= i; k++)
                {
                    long mul = ((k & 1) == 0) ? (-1) : (1);
                    long pos1 = i - ((3 * k * k - k) / 2); // pentagonal(k)
                    long pos2 = i - ((3 * k * k + k) / 2); // pentagonal(k)
                    if (pos1 < 0) break;
                    sum += (pos1 >= 0) ? (mul * p[pos1]) : (0);
                    sum += (pos2 >= 0) ? (mul * p[pos2]) : (0);
                }
                p[i] = sum;
            }
            return (ulong)(p[100] - 1); // -1 because we want at least two integers

            //ulong target = 100;
            //ulong[] ways = new ulong[target + 1];
            //for (ulong i = 0; i < target + 1; i++) ways[i] = 0;
            //ways[0] = 1;
            //for (ulong n = 1; n < 100; n++)
            //    for (ulong i = n; i < target + 1; i++)
            //        ways[i] += ways[i - n];
            //return ways[target];
        }
    }
}
