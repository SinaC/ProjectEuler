using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem230 : ProblemBase
    {
        public Problem230() : base(230)
        {
        }

        public override string Solve()
        {
            const string a = "1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";
            const string b = "8214808651328230664709384460955058223172535940812848111745028410270193852110555964462294895493038196";
            ulong length = (ulong)a.Length; // A and B has the same length
            double phi = (1.0 + Math.Sqrt(5)) / 2.0;
            ulong pow10 = 1;
            ulong pow7 = 1;
            ulong sum = 0;
            for (ulong n = 0; n <= 17; n++)
            {
                ulong digitIndex = (127 + 19 * n) * pow7;
                int stringIndex = (int)((digitIndex - 1) % length);
                ulong whichString = (digitIndex - 1) / length;
                double d = phi * (double)(((ulong)((double)whichString / phi)));
                ulong digit = 0;
                int k = 0;
                if ((double)(whichString - 1) <= d && d < (double)whichString)
                {
                    digit = Tools.Tools.ToUInt64(b[stringIndex]);
                    k = 1;
                }
                else
                {
                    digit = Tools.Tools.ToUInt64(a[stringIndex]);
                    k = 0;
                }
                //Console.WriteLine(digitIndex + "  " + d + "  " + stringIndex + "  " + k + "  " + digit);
                sum += digit * pow10;
                pow10 *= 10;
                pow7 *= 7;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
