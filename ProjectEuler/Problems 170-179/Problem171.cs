using System;

namespace ProjectEuler
{
    public class Problem171
    {
        [UnderConstruction]
        public ulong Solve()
        {
            // min f(n) = 1 if n = 10^k
            // max f(n) = k*9^2 if n = 10^k - 1
            // limit is 10^20-1  (> 64 bits)
            // so we have to build an isSquare array with the 20*9^2 first integers

            // if f(n) is a perfect square, f(n)*10^k is also a perfect square
            // if f(n) is a perfect square, every permutation of its digits is also a perfect square and any number of 0 may be added

            // 1->9 count=9
            // 10->99 count=13
            // 100->999 count=53
            // 1000->9999 count=332
            // 10000->99999 count=3118
            // 100000->999999 count=31653
            // 1000000->9999999 count=333638
            // 10000000->99999999 count=3273646
            // count(10^k->10^(k+1)-1) = 10^k / 3   raw approximation
            // 9 + 13 + 53 + 332 + 3 118 + 31 653 + 333 638 + 3 273 646 = 3 642 462

            const ulong limit = 10000;
            bool[] isPerfectSquare = new bool[20 * 81 + 1];
            for (int i = 0; i < isPerfectSquare.Length; i++)
                isPerfectSquare[i] = Tools.IsPerfectSquare((ulong)i);

            ulong count = 0;
            for (ulong n = 1; n <= limit; n++)
            {
                ulong sumSquareDigits = SumSquareDigits(n);
                if (isPerfectSquare[sumSquareDigits])
                {
                    //Console.WriteLine(n + "->" + sumSquareDigits);
                    count++;
                }
            }
            return 0;
        }

        private ulong SumSquareDigits(ulong number)
        {
            ulong sum = 0;
            while (number >= 1)
            {
                ulong digit = number % 10;
                sum += digit * digit;
                number /= 10;
            }
            return sum;
        }
    }
}
