using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem75 : ProblemBase
    {
        public Problem75() : base(75)
        {
        }

        public override string Solve()
        {
            // Pythagorean triple n2 – m2, 2mn, n2 + m2  with m > 1 and 1 <= n
            const ulong limit = 1500000;
            ulong sideLimit = (ulong)Math.Sqrt(limit);
            Dictionary<ulong, int> dict = new Dictionary<ulong, int>();
            for (ulong i = 1; i <= sideLimit; i += 2)
                for (ulong j = 2; j <= sideLimit; j += 2)
                {
                    ulong pgcd = Tools.Tools.GCD(i, j);
                    if (1 == pgcd)
                    { // reduced triplet
                        //ulong a = (ulong)Math.Abs((long)(i * i) - (long)(j * j));
                        //ulong b = 2 * i * j;
                        //ulong c = i * i + j * j;
                        //ulong perimeter = a + b + c;
                        ulong perimeter = (i > j) ? (2 * i * i + 2 * i * j) : (2 * j * j + 2 * i * j);
                        for (ulong s = perimeter; s <= limit; s += perimeter) // every multiple of perimeter will be produced by this triplet
                            if (dict.ContainsKey(s))
                                dict[s]++;
                            else
                                dict.Add(s, 1);
                    }
                }
            ulong count = 0;
            foreach (KeyValuePair<ulong, int> kv in dict)
                if (kv.Value == 1)
                    count++;
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
