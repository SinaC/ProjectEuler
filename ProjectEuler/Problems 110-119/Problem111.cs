using System;
using System.Globalization;
using System.Text;

namespace ProjectEuler
{
    public class Problem111 : ProblemBase
    {
        public Problem111() : base(111)
        {
        }

        public override string Solve()
        {
            // For each digit
            //  Build number with repeating 10 digits
            //  modify 1 digit, if prime count == 0, modify 2 digits, ...
            //  until prime count > 0
            const ulong lowerLimit = 1000000000;
            const ulong upperLimit = 9999999999;
            const int digitCount = 10;
            ulong globalSum = 0;
            for (int digit = 0; digit < 10; digit++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < digitCount; j++)
                    sb.Append(digit); // fill number with digit
                ulong count = 0;
                ulong sum = 0;
                for (int numberOfDigitToModify = 1; numberOfDigitToModify < 10; numberOfDigitToModify++)
                {
                    Permutation(sb, digitCount, lowerLimit, upperLimit, digit, numberOfDigitToModify, 0, ref count, ref sum);
                    if (count > 0)
                        break;
                }
                globalSum += sum;
                //Console.WriteLine(digit + "->" + count + " " + sum);
            }
            return globalSum.ToString(CultureInfo.InvariantCulture);
        }

        private static void Permutation(StringBuilder sb, int digitCount, ulong lowerLimit, ulong upperLimit, int baseDigit, int numberOfDigitToModify, int position, ref ulong count, ref ulong sum)
        {
            // sb: base number
            // digitCount: number of digit in number
            // lower/upperLimit: number must be within these limits (avoid leading 0)
            // baseDigit: in the beginning sb is filled with baseDigit
            // numberOfDigitToModify: number of digits modified
            // position: position of the last modified digit
            // count: number of prime found
            // sum: sum of prime found
            for (int pos = position; pos < digitCount; pos++)
            {
                for (int digit = 0; digit < 10; digit++)
                    if (digit != baseDigit)
                    {
                        sb[pos] = Convert.ToChar(digit + 48); // change digit
                        if (numberOfDigitToModify > 1)
                        { // recursive call if more than one digit left to modify
                            Permutation(sb, digitCount, lowerLimit, upperLimit, baseDigit, numberOfDigitToModify - 1, pos + 1, ref count, ref sum);
                        }
                        else
                        {
                            // Check if in limits and prime
                            ulong n = Convert.ToUInt64(sb.ToString());
                            if (n >= lowerLimit && n <= upperLimit)
                            {
                                if (Primes.Check.IsPrime(n))
                                {
                                    //Console.WriteLine(n);
                                    count++;
                                    sum += n;
                                }
                            }
                        }
                    }
                sb[pos] = Convert.ToChar(baseDigit + 48); // reset digit
            }
        }
    }
}
