using System;
using System.Linq;

namespace ProjectEuler
{
    public class Problem16
    {
        public ulong Solve()
        {
            const int power = 1000; // Log10(2^n) = n*Log10(2)
            int limit = (int)Math.Ceiling((double)power * Math.Log10(2)) + 1; // Number of digit + 1 for sentinel
            int[] digits = new int[limit];
            for (int i = 0; i < digits.Length; i++) digits[i] = 0;
            // digits[0] is used as sentinel
            digits[1] = 1;

            for (int i = 1; i <= power; i++)
            {
                for (int j = limit - 1; j > 0; j--)
                {
                    // If previous number is higher than 5, multiply it by 2 gives a number between 10 and 18, so 1 must be added to current
                    if (digits[j - 1] >= 5)
                        digits[j] = ((2 * digits[j]) % 10) + 1;
                    else
                        digits[j] = (2 * digits[j]) % 10;
                }
            }
            return digits.Aggregate<int, ulong>(0, (current, i) => current + (ulong) i);
        }
    }
}
