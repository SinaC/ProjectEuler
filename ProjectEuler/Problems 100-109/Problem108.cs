using System;

namespace ProjectEuler
{
    public class Problem108
    {
        public ulong Solve()
        {
            // Brute-force
            //ulong limit = 20000;
            //SortedDictionary<ulong, int> dict = new SortedDictionary<ulong, int>();
            //for ( ulong x = 2; x <= limit; x++ )
            //    for (ulong y = x; y <= limit; y++) {
            //        ulong remainderN = (x * y) % (x + y);
            //        if (0 == remainderN) {
            //            ulong n = (x * y) / (x + y);
            //            if (dict.ContainsKey(n))
            //                dict[n]++;
            //            else
            //                dict.Add(n, 1);
            //        }
            //    }
            //// dict.Count = limit/2
            //foreach (KeyValuePair<ulong, int> kv in dict) {
            //    if (kv.Value >= 1000)
            //        return kv.Key;
            //}
            //return 0;

            // 1/x + 1/y = 1/n
            // y = n + n^2/(x-n)   n < x <= 2n   y integral if x-n divide n^2
            // if d is a factor of n^2 and n < d+n <= 2n
            // if we analyse n=4, n=5 and n=6, #solution = (#factor(n^2)+1)/2
            // if n = p1^e1 * p2^e2 * p3^e3
            // #factor(n) = (e1+1)*(e2+1)*(e3+1)
            // n^2 = p1^2e1 * p2^2e2 * p3^2e3
            // #factor(n^2) = (2*e1+1)*(2*e2+1)*(2*e3+1)
            ulong bestN;
            ulong n = 1260;
            while (true)
            {
                ulong solutionCount = (FactorOfSquareCount(n) + 1) / 2;
                if (solutionCount > 1000)
                {
                    bestN = n;
                    break;
                }
                n++;
            }
            return bestN;
        }

        private ulong FactorOfSquareCount(ulong n)
        {
            ulong sqrtN = (ulong)Math.Sqrt(n);
            ulong count = 1;
            for (ulong i = 2; i <= sqrtN; i++)
            {
                if (0 == (n % i))
                {
                    ulong exponentCount = 0;
                    while ((n % i) == 0)
                    {
                        exponentCount++;
                        n /= i;
                    }
                    count *= 2 * exponentCount + 1;
                }
                if (0 == n)
                    break;
            }
            return count;
        }
    }
}
