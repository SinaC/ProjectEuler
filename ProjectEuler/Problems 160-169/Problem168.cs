using System;
using CarlJohansen;

namespace ProjectEuler
{
    public class Problem168
    {
        public ulong Solve()
        {
            // Brute-force
            //ulong sum = 0;
            //ulong pow10 = 1;
            //for (ulong digitsCount = 2; digitsCount <= 8; digitsCount++) {
            //    pow10 *= 10;
            //    ulong nextPow10 = pow10 * 10;
            //    for (ulong n = pow10; n < nextPow10; n++) {
            //        ulong lastDigit = n % 10;
            //        ulong firstDigits = n / 10;
            //        ulong firstDigit = firstDigits % 10;
            //        if (0 == lastDigit) continue;
            //        if (lastDigit < firstDigit) continue;
            //        ulong m = firstDigits + (lastDigit * pow10);
            //        ulong remainder = m % n;
            //        if (0 == remainder) {
            //            ulong quotient = m / n;
            //            sum = (sum + n) % 100000;
            //            Console.WriteLine(n + "*" + quotient + " = " + m + "   --> "+sum);
            //        }
            //    }
            //}

            //let n = AB  with B the last digit and A the first digits of number
            //let m and k be such as   
            //     m * ( 10*A + B ) = B * 10^k + A  with k = number of digits of A and m in [1,9]
            //A = B * ( 10^k - m ) / ( 10*m - 1 )
            //N = A * 10 + B
            // If  B * ( 10^k - m ) % ( 10*m - 1 ) == 0  and  N > 10^k  then  we have found a solution
            BigInt sum = 0;
            for (long m = 1; m <= 9; m++)
            {
                BigInt biPower10K = 10;
                BigInt biM = m;
                for (long k = 2; k <= 100; k++)
                {
                    for (long b = 1; b <= 9; b++)
                    {
                        BigInt biB = b;
                        BigInt biRemainder;
                        BigInt biA; // = A
                        BigInt.DivAndMod((biB * (biPower10K - biM)), (10 * biM - 1), out biRemainder, out biA);
                        if (0 == biRemainder)
                        {
                            BigInt biN = biA * 10 + biB;
                            if (biN > biPower10K)
                            {
                                //Console.WriteLine(m + "-->" + k + "  " + biN.NumDigits + "  " + biQuotient.ToString() + " " + b);
                                sum = (sum + biN) % 100000;
                            }
                        }
                    }
                    biPower10K *= 10;
                }
            }
            return Convert.ToUInt64(sum.ToString());
        }
    }
}
