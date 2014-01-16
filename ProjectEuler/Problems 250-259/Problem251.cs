using System;
using Primes;

namespace ProjectEuler
{
    public class Problem251
    {
        [TooSlow]
        public ulong Solve()
        {
            //http://www77.wolframalpha.com/input/?i=((a%2Bbsqrt(c))^(1/3))+%2B+((a-bsqrt(c))^(1/3))+%3D+1 
            //http://compsci.ca/v3/viewtopic.php?t=21209&postdays=0&postorder=asc&start=90
            //http://cyzhao.blogbus.com/logs/55014616.html
            // 8a^3+15a^2+6a-1 = 27cb^2
            // right part is divisible by 3 -> left part must be divisible by 3, then a = 2 (mod 3)

            // a = 3k-1 => cb^2 = k^2 * (8k-3)

            //const ulong limit = 1000;
            //Prime p = new Prime((int)limit);
            //p.GenerateAll();

            //for(ulong k = 1; k < limit/3; k++)
            //{
            //    ulong a = 3 * k - 1;
            //    // Get optimal b and c by derivation
            //    double optb = Math.Exp(Math.Log(2.0 * k * k * (8 * k - 3)) / 3);
            //    double optc = optb / 2;

            //    if (a + optb + optc > limit)
            //        break;

            //    ulong b = k; // b^2 = k^2
            //    ulong c = 8*k - 3; // c = 8k-3
            //}

            const ulong limit = 110000000;
            ulong count = 0;
            for (ulong a = 2; a < limit; a += 3)
            {
                double k = limit - a;
                double t = 1.0 - 2.0 * a;
                double s = a * a - t * t * t / 27.0;
                double bMin = 4.0 * s / (k * k) - 1;
                double bMax = Math.Sqrt(s) + 1;
                if (bMin < 1) bMin = 1;
                if (bMax > k) bMax = k;
                for (ulong b = (ulong)bMin; b <= (ulong)bMax; b++)
                {
                    ulong c = (ulong)s / (b * b);
                    if (c >= 1 && (b * b * c) == s && (b + c) <= k)
                    {
                        //cout<<"("<<a<<","<<b<<","<<c<<")"<<endl;
                        count++;
                    }
                }
            }
            return count;

            return 0;
        }
    }
}
