using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem124 : ProblemBase
    {
        public Problem124() : base(124)
        {
        }

        public override string Solve()
        {
            // Brute-force
            //ulong limit = 100000;
            //bool[] sieve = BuildSieve(limit);
            //Radical[] radicals = new Radical[limit+1];
            //radicals[0] = new Radical(0,0);
            //radicals[1] = new Radical(1, 1);
            //for (ulong n = 2; n <= limit; n++) {
            //    ulong rad = _127_Radical(sieve, n);
            //    radicals[n] = new Radical(n,rad);
            //}
            //Array.Sort(radicals, Radical.Compare);
            //return radicals[10000].n;

            // Build radical and prime on-the-go
            const ulong limit = 100000;
            Radical[] radicals = new Radical[limit + 1];
            radicals[0] = new Radical(0, 0);
            radicals[1] = new Radical(1, 1);
            for (ulong rad = 2; rad <= limit; rad++)
            {
                if (null != radicals[rad]) continue;
                for (ulong n = rad; n <= limit; n += rad)
                {
                    if (null == radicals[n])
                        radicals[n] = new Radical(n, rad);
                    else
                        radicals[n].Rad *= rad;
                }
            }
            Array.Sort(radicals, Radical.Compare);
            return radicals[10000].N.ToString(CultureInfo.InvariantCulture);
        }

        private class Radical
        {
            public readonly ulong N;
            public ulong Rad;

            public Radical(ulong n, ulong rad)
            {
                N = n;
                Rad = rad;
            }

            public static int Compare(Radical a, Radical b)
            {
                if (a.Rad < b.Rad)
                    return -1;
                if (a.Rad > b.Rad)
                    return 1;
                if (a.N < b.N)
                    return -1;
                if (a.N > b.N)
                    return 1;
                return 0;
            }

            public override string ToString()
            {
                return N + "->" + Rad;
            }
        }
    }
}
