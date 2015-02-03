using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem88 : ProblemBase
    {
        private const ulong Limit = 12000;

        public Problem88() : base(88)
        {
        }

        public override string Solve()
        {
            List<int> mins = new List<int>();
            for (int i = 2; i <= 12000; i++)
            {
                int min = GetMin(i);
                mins.Add(min);
            }
            return mins.Distinct().Aggregate(0, (n, i) => n + i).ToString(CultureInfo.InvariantCulture);
        }

        public string Solve2()
        {
            Dictionary<ulong, ulong> dict = new Dictionary<ulong, ulong>();
            //HashSet<ulong> values = new HashSet<ulong>();

            Count(dict, 2, 0, 1, 0);
            HashSet<ulong> values = new HashSet<ulong>(dict.Where(kv => kv.Key >= 2 && kv.Key <= Limit).Select(kv => kv.Value));
            //foreach (KeyValuePair<ulong, ulong> pair in dict)
            //{
            //    if (pair.Key >= 2 && pair.Key <= Limit)
            //        values.Add(pair.Value);
            //}

            return values.Aggregate((ulong)0, (n, i) => n + i).ToString(CultureInfo.InvariantCulture);
        }

        // get minimal product=sum for a given k
        // n = the product=sum to check
        private static int GetMin(int k)
        {
            for (int n = k + 1; ; n++)
                if (Check(n, n, k)) return n;
        }

        // returns true iff wanted prod and sum is possible with
        // k factors/terms
        private static bool Check(int prod, int sum, int k)
        {
            if (sum < k)
                return false;
            if (prod == 1)
                return sum == k;
            if (k == 1)
                return prod == sum;
            for (int d = 2; d <= prod && sum - d >= k - 1; d++)
                if (prod % d == 0)
                    if (Check(prod / d, sum - d, k - 1))
                        return true;
            return false;
        }

        private static void Count(IDictionary<ulong, ulong> dict, ulong cvalue, ulong csum, ulong cproduct, ulong clength)
        {
            ulong ctmp = cproduct - csum + clength;

            /**
             * VERY IMPORTANT: without this problem will run over 1-minutes
             * for any number N=2k is a guaranteed solution. k=k:2k = 2*k*1*1*...*1=2+k+1+1+...+1
             */
            if (clength == 0 && cvalue > Math.Sqrt(Limit))
                return;
            if (cvalue * cproduct >= Limit * 2)
                return;

            while (ctmp <= Limit)
            {
                Count(dict, cvalue + 1, csum, cproduct, clength);
                cproduct *= cvalue;
                csum += cvalue;
                clength++;
                ctmp = cproduct - csum + clength;

                if (clength > 1 && (!dict.ContainsKey(ctmp) || dict[ctmp] > cproduct))
                    dict[ctmp] = cproduct;
            }
        }
    }
}
