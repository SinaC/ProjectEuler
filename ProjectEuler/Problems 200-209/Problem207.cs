using System;

namespace ProjectEuler
{
    public class Problem207
    {
        // 4^t = 2^t + k
        // 2^(2*t) = 2^t + k
        // 2^(2*t) - 2^t = k
        // 2^t(2^t-1) = k
        // if 2^p is integer, there will exist a corresponding k that will be integer
        // function is increasing: t1 < t2 ==> k1 < k2
        public ulong Solve()
        {
            double cantPerf = 1;
            double cantTot = 1;
            const double limit = 1.0/12345.0;
            ulong i = 3;
            while(cantPerf / cantTot >= limit)
            {
                ulong log2 = (ulong)Math.Log(i, 2);
                if (Math.Pow(2, log2) == i)
                    cantPerf += 1.0;
                cantTot += 1.0;
                i += 1;
            }
            i -= 1;
            return i*(i - 1);
        }
    }
}
