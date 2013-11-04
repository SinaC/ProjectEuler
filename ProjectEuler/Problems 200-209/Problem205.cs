using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem205
    {
        public string Solve()
        {
            // Spent many hours to figure out why my answer was not correct
            // Answer must include 0.   so it's the probability rounded at 7 decimals
            ulong ppCount = 0;
            ulong[] pp = new ulong[36];
            for (int i = 0; i < pp.Length; i++) pp[i] = 0;
            for (ulong i = 1; i <= 4; i++)
                for (ulong j = 1; j <= 4; j++)
                    for (ulong k = 1; k <= 4; k++)
                        for (ulong l = 1; l <= 4; l++)
                            for (ulong m = 1; m <= 4; m++)
                                for (ulong n = 1; n <= 4; n++)
                                    for (ulong o = 1; o <= 4; o++)
                                        for (ulong p = 1; p <= 4; p++)
                                            for (ulong q = 1; q <= 4; q++)
                                            {
                                                ppCount++;
                                                ulong sum = i + j + k + l + m + n + o + p + q;
                                                pp[sum - 1]++;
                                            }
            ulong ccCount = 0;
            ulong[] cc = new ulong[36];
            for (int i = 0; i < cc.Length; i++) cc[i] = 0;
            for (ulong i = 1; i <= 6; i++)
                for (ulong j = 1; j <= 6; j++)
                    for (ulong k = 1; k <= 6; k++)
                        for (ulong l = 1; l <= 6; l++)
                            for (ulong m = 1; m <= 6; m++)
                                for (ulong n = 1; n <= 6; n++)
                                {
                                    ccCount++;
                                    ulong sum = i + j + k + l + m + n;
                                    cc[sum - 1]++;
                                }
            double prob = 0;
            for (ulong i = 0; i < 36; i++)
                for (ulong j = 0; j < i; j++)
                    prob += ((double)pp[i] * (double)cc[j]);// / (double)(ppCount * ccCount);
            prob = prob / ((double)ppCount * (double)ccCount);
            return Math.Round(prob, 7).ToString(CultureInfo.InvariantCulture).Replace(',', '.');
        }
    }
}
