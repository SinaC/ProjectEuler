using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem141
    {
        public ulong Solve()
        {
            //long limit = 1000000; // sqrt(10^12)
            //ulong sum = 0;
            //for (long i = 3; i <= limit; i++) {
            //    long n = i * i;
            //    for (long d = 2; d <= i; d++) {
            //        long q, r;
            //        q = Math.DivRem(n, d, out r);
            //        // d/r = q/d -> d^2 = q*r
            //        // consecutive ==> q/r = (q/d)^2 -> d^2 = q*r
            //        if (d * d == q * r) {
            //            sum += (ulong)n;
            //            // interesting property
            //            // d^2 = q*r   with r = n-q*d
            //            // d^2 = q*(n-q*d)
            //            // d*q^2 - n*q + d^2 = 0
            //            // delta = n^2 - 4*d*d^2 = n^2 - 4*d^3   from already found results we see
            //            // n - sqrt( delta ) = 2*r
            //            // with delta a perfect square
            //            Console.WriteLine(i + "^2 = " + d + "*" + q + "+" + r + " = " + n + "   sum=" + sum);
            //            break;
            //        }
            //    }
            //}
            //return sum;

            // n = d * q + r
            // q/d = d/r  and  q/r = (d/r)^2
            // { r, d, q } = { r, r*a/b, r*a^2/b^2 } with GCD(a,b) == 1
            // q is integral if r is a multiple of b^2
            // r = b^2 * c
            // { r, d, q } = { b^2, a*b*c, a^2*c }
            // n = b*c*(b+a^3*c)  n must be a perfect square and lower than 10^21
            Dictionary<ulong, int> dict = new Dictionary<ulong, int>();
            const ulong limit = 1000000000000;
            for (ulong a = 2; a < 200/*trial-error*/; a++)
                for (ulong b = 1; b < a; b++)
                {
                    ulong pgcd = Tools.GCD(a, b);
                    if (pgcd > 1)
                        continue;
                    for (ulong c = 1; ; c++)
                    {
                        ulong m2 = b * c * (b + c * a * a * a);
                        if (m2 >= limit)
                            break;
                        if (Tools.IsPerfectSquare(m2))
                        {
                            if (dict.ContainsKey(m2))
                                dict[m2]++;
                            else
                                dict.Add(m2, 1);
                        }
                    }
                }
            return dict.Aggregate<KeyValuePair<ulong, int>, ulong>(0, (current, kv) => current + kv.Key);
        }
    }
}
