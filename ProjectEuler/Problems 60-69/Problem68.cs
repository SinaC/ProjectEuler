using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem68 : ProblemBase
    {
        public Problem68() : base(68)
        {
        }

        public override string Solve()
        {
            // end of line a, b, c, d, e
            // pentagon f, g, h, i, j
            // a-f-g
            // b-g-h
            // c-h-i
            // d-i-j
            // e-j-f
            // 10 must be in the outer ring to give 16-digit
            // the highest values must be in the outer ring
            // a must be equal to 6, sequence must start with the lowest external node
            // fix a, b, c, d, e to 6, 10, 9, 8, 7
            const int limit = 5;
            const int a = 6;
            const int b = 10;
            const int c = 9;
            const int d = 8;
            const int e = 7;
            List<string> solutions = new List<string>();
            bool[] used = new bool[limit];
            string max = "0";
            for (int f = 1; f <= limit; f++)
            {
                used[f - 1] = true;
                for (int g = 1; g <= limit; g++)
                {
                    if (used[g - 1]) continue;
                    used[g - 1] = true;
                    for (int h = 1; h <= limit; h++)
                    {
                        if (used[h - 1]) continue;
                        used[h - 1] = true;
                        for (int i = 1; i <= limit; i++)
                        {
                            if (used[i - 1]) continue;
                            used[i - 1] = true;
                            int j = 0;
                            for (int t = 0; t < limit; t++)
                                if (!used[t])
                                {
                                    j = t + 1;
                                    break;
                                }
                            int sum1 = a + f + g;
                            int sum2 = b + g + h;
                            int sum3 = c + h + i;
                            int sum4 = d + i + j;
                            int sum5 = e + j + f;
                            if (sum1 == sum2 && sum1 == sum3 && sum1 == sum4 && sum1 == sum5)
                            {
                                string s =
                                    a.ToString(CultureInfo.InvariantCulture) + f.ToString(CultureInfo.InvariantCulture) + g.ToString(CultureInfo.InvariantCulture)
                                    + b.ToString(CultureInfo.InvariantCulture) + g.ToString(CultureInfo.InvariantCulture) + h.ToString(CultureInfo.InvariantCulture)
                                    + c.ToString(CultureInfo.InvariantCulture) + h.ToString(CultureInfo.InvariantCulture) + i.ToString(CultureInfo.InvariantCulture)
                                    + d.ToString(CultureInfo.InvariantCulture) + i.ToString(CultureInfo.InvariantCulture) + j.ToString(CultureInfo.InvariantCulture)
                                    + e.ToString(CultureInfo.InvariantCulture) + j.ToString(CultureInfo.InvariantCulture) + f.ToString(CultureInfo.InvariantCulture);
                                solutions.Add(s);
                                if (String.CompareOrdinal(s, max) > 0)
                                    max = s;
                            }
                            used[i - 1] = false;
                        }
                        used[h - 1] = false;
                    }
                    used[g - 1] = false;
                }
                used[f - 1] = false;
            }
            return max;
        }
    }
}
