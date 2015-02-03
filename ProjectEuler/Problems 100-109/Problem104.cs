using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem104 : ProblemBase
    {
        public Problem104() : base(104)
        {
        }

        public override string Solve()
        {
            // Brute-force too slow
            //string fn = "1";
            //string fn_1 = "1";
            //ulong n = 2;
            //while (true) {
            //    string fn_2 = SumString(fn, fn_1);
            //    n++;
            //    if (fn_2.Length > 9 && IsPandigital(fn_2.Substring(fn_2.Length - 9)) && IsPandigital(fn_2.Substring(0,9)))
            //        break;
            //    fn = fn_1;
            //    fn_1 = fn_2;
            //}
            //return n;

            const ulong limit = 1000000; // arbitrary limit
            const ulong last9Digits = 1000000000;
            double log10Phi = Math.Log10((1.0 + Math.Sqrt(5)) / 2.0);
            double log10Multiplier = Math.Log10(1.0 / Math.Sqrt(5));
            ulong fn = 1;
            ulong fn1 = 1;
            for (ulong n = 3; n <= limit; n++)
            {
                ulong fn2 = (fn + fn1) % last9Digits; // last 9 digits
                string s = fn2.ToString(CultureInfo.InvariantCulture);
                if (s.Length >= 9 && Tools.Tools.IsPandigital(s))
                {
                    // Last 9 digits matches, check first 9 digits
                    // Compute first 9 digits of Fn for each right-pandigital
                    // if log(n) = xxxxx.yyyyy
                    // n = 10^(xxxxx.yyyyy)
                    // n = 10^(xxxxx+0.yyyyy)
                    // n = 10^xxxxx * 10^0.yyyyy
                    // first part is a power of 10 so it just gives where to put the decimal point
                    // second part contains the number itself
                    // 0.yyyyy is between 0 and 1, so 10^0.yyyyy is between 1 and 10
                    // 10^0.yyyyy gives the number z.zzzzzz
                    // we want the 9 first digits, so we have to multiply z.zzzzz by 10^(9-1)
                    // 9 first digits:
                    // 10^8 * 10^frac(log10(n))
                    // or 10^[frac(log10(n)) + 8]
                    double t = n * log10Phi + log10Multiplier; // Log10(Fn)
                    double f = t - Math.Floor(t); // frac(t)
                    ulong first9Digits = (ulong)Math.Pow(10.0, f + 9 - 1);
                    if (Tools.Tools.IsPandigital(first9Digits.ToString(CultureInfo.InvariantCulture)))
                        return n.ToString(CultureInfo.InvariantCulture);
                }
                fn = fn1;
                fn1 = fn2;
            }
            return "0";
        }
    }
}
