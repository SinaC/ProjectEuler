using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem56 : ProblemBase
    {
        public Problem56() : base(56)
        {
        }

        public override string Solve()
        {
            //ulong bestDigitSum = 0;
            //for ( uint i = 90; i <= 99; i++ ) {
            //    for (uint j = 90; j <= 99; j++) {
            //        BigInt power = BigInt.Power(i, j);
            //        ulong sum = SumDigits(power.ToString());
            //        if (sum > bestDigitSum)
            //            bestDigitSum = sum;
            //    }
            //return bestDigitSum;

            // biggest number = 99^99
            // number of digits = floor(99*log10(99))+1
            const ulong limit = 99;
            ulong limitDigitsCount = (ulong)((double)limit * Math.Log10(limit)) + 1;
            ulong[] digits = new ulong[limitDigitsCount];
            ulong bestDigitSum = 0;
            //ulong bestBase = 0;
            //ulong bestExponent = 0;
            for (uint b = 90; b <= limit; b++)
            { // 90->99
                for (int i = 0; i < digits.Length; i++) digits[i] = 0;
                digits[0] = 1; // starts with 1
                ulong digitCount = 1;
                for (ulong e = 1; e <= limit; e++)
                { // compute each power of base
                    Tools.Tools.MulDigitsNumber(digits, ref digitCount, b);
                    ulong sum = digits.Aggregate<ulong, ulong>(0, (current, digit) => current + digit);
                    if (sum > bestDigitSum)
                    {
                        //bestBase = b;
                        //bestExponent = e;
                        bestDigitSum = sum;
                    }
                }
            }
            return bestDigitSum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
