using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem4
    {
        public ulong Solve()
        {
            bool found = false;
            ulong firstHalf = 998;
            ulong[] factors = new ulong[2];
            ulong palindrome = 0;
            while (!found)
            {
                firstHalf--;
                palindrome = MakePalindrome(firstHalf);
                for (ulong i = 999; i > 99; i--)
                {
                    if (palindrome / i > 999 || i * i < palindrome)
                        break;

                    if (palindrome % i == 0)
                    {
                        found = true;
                        factors[0] = palindrome / i;
                        factors[1] = i;
                        break;
                    }
                }
            }
            return palindrome;
        }

        private ulong MakePalindrome(ulong firstHalf)
        {
            char[] reversed = firstHalf.ToString(CultureInfo.InvariantCulture).Reverse().ToArray();
            return Convert.ToUInt32(firstHalf + new string(reversed));
        }
        //public ulong Problem4()
        //{
        //    // product of the 3-digits number is a 6-digits number
        //    // must be a palindrom, so digits will be: abccba
        //    // a*10^5+b*10^4+c+10^3+c*10^2+b*10^1+a*10^0
        //    // a*100001 + b*10010 + c*1100
        //    // 11*(a*9091 + b*910 + c*100) = m*n    so m or n must be divisible by 11
        //    // a cannot be 0
        //    ulong result = 0;
        //    for (ulong m = 999; m >= 100; m--)
        //        for (ulong n = 990; n >= 100; n -= 11)
        //        {
        //            ulong product = m * n;
        //            if (IsPalindromic(product, 10))
        //                if (product > result)
        //                    result = product;
        //        }
        //    return result;
        //}
    }
}
