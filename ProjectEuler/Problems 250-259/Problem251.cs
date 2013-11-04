using System;

namespace ProjectEuler
{
    // TOO SLOW
    public class Problem251
    {
        public ulong Solve()
        {
            //http://www77.wolframalpha.com/input/?i=((a%2Bbsqrt(c))^(1/3))+%2B+((a-bsqrt(c))^(1/3))+%3D+1 
            //http://compsci.ca/v3/viewtopic.php?t=21209&postdays=0&postorder=asc&start=90
            //http://cyzhao.blogbus.com/logs/55014616.html
            // 8a^2+15a^2+6a-1 = 27cb^2
            // right part is divisible by 3 -> left part must be divisible by 3, then a = 2 (mod 3)

            const ulong limit = 110000000;
            ulong count = 0;
            for (ulong a = 2; a < limit; a += 3)
            {
                double k = limit - a;
                double t = 1.0 - 2.0 * a;
                double s = a * a - t * t * t / 27.0;
                double bMin = 4.0 * s / k / k - 1;
                double bMax = Math.Sqrt(s) + 1;
                if (bMin < 1) bMin = 1;
                if (bMax > k) bMax = k;
                for (ulong b = (ulong)bMin; b <= (ulong)bMax; b++)
                {
                    ulong c = (ulong)s / b / b;
                    if (c >= 1 && (b * b * c) == s && (b + c) <= k)
                    {
                        //cout<<"("<<a<<","<<b<<","<<c<<")"<<endl;
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
