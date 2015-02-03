using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem100 : ProblemBase
    {
        public Problem100() : base(100)
        {
        }

        public override string Solve()
        {
            // (b/t)*(b-1)/(t-1) = 1/2   b for blue discs   t for total discs
            // 2b^2 – 2b – t^2 + t = 0

            //// Brute-force
            //// b = (1+sqrt(1+2*t*t-2*t))/2
            //// must find sqrt(1+2*t*t-2*t) integral with t > 10^12
            //// first iterations gives a constant ratio, so we can get a lower bound for the next value
            //const ulong limit = 1000000000000;
            //ulong b = 0;
            //ulong previous = 120;
            //ulong t = 121;
            //while (true) {
            //    ulong n = 1 + 2 * t * t - 2 * t;
            //    ulong sqrt = (ulong)Math.Sqrt(n);
            //    if (sqrt * sqrt == n) {
            //        if (t > limit) {
            //            b = (1 + sqrt) / 2;
            //            break;
            //        }
            //        ulong tmp = t;
            //        t = t * t / previous;
            //        previous = tmp;
            //    }
            //    else
            //        t++;
            //}
            //return b;

            //http://wiki.san-ss.com.ar/project-euler-problem-100
            // diophantine quadratic equation -> http://www.alpertron.com.ar/QUAD.HTM to get the coefficient
            //X0 = 1
            //Y0 = 1
            //Xn+1 = P Xn + Q Yn + K
            //Yn+1 = R Xn + S Yn + L
            //P = 3
            //Q = 2
            //K = -2
            //R = 4
            //S = 3
            //L = -3
            // blue disks = 3b + 2t – 2
            // total disc = 4b + 3t - 3
            ulong limit = Convert.ToUInt64("1000000000000");
            ulong b = 85;
            ulong t = 120;
            while (t < limit)
            {
                ulong newB = 3 * b + 2 * t - 2;
                ulong newT = 4 * b + 3 * t - 3;
                b = newB;
                t = newT;
            }
            return b.ToString(CultureInfo.InvariantCulture);
        }
    }
}
