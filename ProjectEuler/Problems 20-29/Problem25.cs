using System;

namespace ProjectEuler
{
    public class Problem25
    {
        public ulong Solve()
        {
            //uint digits = 1000;
            //BigInt thousandDigits = BigInt.Power(10, digits-1);
            //BigInt Fn = 1;
            //BigInt Fn1 = 1;
            //int term = 1;
            //while (Fn < thousandDigits) {
            //    BigInt Fn2 = Fn + Fn1;
            //    Fn = Fn1;
            //    Fn1 = Fn2;
            //    term++;
            //}
            //return term;

            // phi = (1+sqrt(5))/2
            // Fn = Round( phi^n / sqrt(5) )  with n greater enough
            // 1000 digits ==> Log10(Fn) = 999
            // Log10( phi^n / sqrt(5) ) = 999
            // Log10( phi^n ) - Log10(5) = 999
            // n*Log10(phi) = 999 + Log10( sqrt(5) )
            // n = ( 999 + Log10( sqrt(5) ) ) / Log10( phi )
            return (ulong)Math.Round((999.0 + Math.Log10(Math.Sqrt(5))) / Math.Log10((1.0 + Math.Sqrt(5)) / 2.0));
        }
    }
}
