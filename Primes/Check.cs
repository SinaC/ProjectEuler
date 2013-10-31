using System;

namespace Primes
{
    public class Check
    {
        //public static bool IsPrime(ulong number)
        //{
        //    bool returnValue = true;

        //    if (number < 2 || (number > 2 && (number % 2 == 0)) || (number > 2 && (number & (number - 1)) == 0))
        //        returnValue = false;
        //    else
        //        for (ulong i = 2; i * i <= number; i++)
        //            if (number % i == 0)
        //                returnValue = false;

        //    return returnValue;
        //}

        public static bool IsPrime(ulong n)
        {
            if (n <= 1) return false; // 0, 1
            if (n < 4) return true; // 2, 3
            if (0 == (n & 1)) return false; // even
            if (n < 9) return true; // 0, 1, 4, 6, 8 already rejected
            if (0 == (n % 3)) return false; // multiple of 3
            ulong sqrtN = (ulong)Math.Sqrt(n);
            ulong divisor = 5;
            while (divisor <= sqrtN)
            {
                if (0 == (n % divisor)) return false;
                if (0 == (n % (divisor + 2))) return false;
                divisor += 6;
            }
            return true;
        }
    }
}
