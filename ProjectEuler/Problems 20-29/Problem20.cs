using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public sealed class Problem20 : Problem
    {
        public Problem20() : base(20)
        {
        }

        public override string Solve()
        {
            //int limit = 100;
            //BigInt number = 1;
            //for (int i = 2; i < limit; i++)
            //    number *= i;
            //return SumDigits(number.ToString());

            const ulong limit = 100;
            // n! <= e*((n+1)/e)^(n+1)
            int limitDigitsCount = (int)Math.Ceiling(Math.Log10(Math.E * Math.Pow((double)(limit + 1) / Math.E, limit + 1)));
            // or (int)Math.Ceiling((double)(limit + 1) * Math.Log10(limit + 1) - (double)limit * Math.Log10(Math.E));
            ulong[] digits = new ulong[limitDigitsCount + 1];
            for (int i = 0; i < limitDigitsCount; i++) digits[i] = 0;

            digits[0] = 1;
            ulong digitCount = 1;
            for (ulong i = 2; i <= limit; i++)
            {
                Tools.MulDigitsNumber(digits, ref digitCount, i);
                //ulong toto = 0;
                //foreach (ulong digit in digits)
                //    toto += digit;
                //Console.WriteLine(i + "->" + toto);
            }
            return digits.Aggregate<ulong, ulong>(0, (current, digit) => current + digit).ToString(CultureInfo.InvariantCulture);
        }
    }
}
