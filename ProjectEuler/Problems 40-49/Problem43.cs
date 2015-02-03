using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem43 : ProblemBase
    {
        public Problem43() : base(43)
        {
        }

        public override string Solve()
        {
            // DOESNT WORK
            //// d0 <> 0
            //// d4 = {0, 2, 4, 6, 8}
            //// d6 = {5}  0 must be excluded because a sequence cannot start with 0
            //// d6d7d8 = { 506, 517, 528, 539, 561, 572, 583, 594 } multiple of 11 starting with 5
            //// d7d8d9 = { 286, 390, 728, 832 } multiple of 13 without 5
            //// d8d9d10 = { 289, 867, 901 } multiple of 17 without 5
            //// d6d7d8d9d10 = { 52867, 53901, 57289 } d6 = 5 and end of d7d8d9 must start d8d9d10
            //// d5d6d7 = { 357, 952 } multiple of 7 and ending with { 52, 53, 57 }
            //// d5d6d7d8d9d10 = { 357289, 952867 }
            //// d4 = { 0, 4, 6 } 2 and 8 are already found in d5->d10
            //// 9, 7, 8, 2, 5 not available for d1, d2, d3, d4

            bool[] digits = new bool[10];
            for (int i = 0; i < digits.Length; i++) digits[i] = false;
            ulong sum = 0;
            for (int d1 = 0; d1 < 10; d1++)
            {
                digits[d1] = true;
                for (int d2 = 0; d2 < 10; d2++)
                {
                    if (digits[d2]) continue;
                    digits[d2] = true;
                    for (int d3 = 0; d3 < 10; d3++)
                    {
                        if (digits[d3]) continue;
                        digits[d3] = true;
                        for (int d4 = 0; d4 < 10; d4++)
                        {
                            if (digits[d4]) continue;
                            if ((0 != (d4 & 1))) continue; // d2d3d4 divisible by 2
                            digits[d4] = true;
                            for (int d5 = 0; d5 < 10; d5++)
                            {
                                if (digits[d5]) continue;
                                if (((100 * d3 + 10 * d4 + d5) % 3) != 0) continue; // d3d4d5 divisible by 3
                                digits[d5] = true;
                                for (int d6 = 0; d6 < 10; d6++)
                                {
                                    if (digits[d6]) continue;
                                    if (d6 != 5 && d6 != 0) continue; // d4d5d6 divisible by 5
                                    digits[d6] = true;
                                    for (int d7 = 0; d7 < 10; d7++)
                                    {
                                        if (digits[d7]) continue;
                                        if (((100 * d5 + 10 * d6 + d7) % 7) != 0) continue;// d5d6d7 divisible by 7
                                        digits[d7] = true;
                                        for (int d8 = 0; d8 < 10; d8++)
                                        {
                                            if (digits[d8]) continue;
                                            if (((100 * d6 + 10 * d7 + d8) % 11) != 0) continue; // d6d7d8 divisible by 11
                                            digits[d8] = true;
                                            for (int d9 = 0; d9 < 10; d9++)
                                            {
                                                if (digits[d9]) continue;
                                                if (((100 * d7 + 10 * d8 + d9) % 13) != 0) continue; // d7d8d9 divisible by 13
                                                digits[d9] = true;
                                                for (int d10 = 0; d10 < 10; d10++)
                                                {
                                                    if (digits[d10]) continue;
                                                    if (((100 * d8 + 10 * d9 + d10) % 17) != 0) continue;// d8d9d10 divisible by 17
                                                    string concat = d1.ToString(CultureInfo.InvariantCulture) + d2.ToString(CultureInfo.InvariantCulture) + d3.ToString(CultureInfo.InvariantCulture) + d4.ToString(CultureInfo.InvariantCulture) + d5.ToString(CultureInfo.InvariantCulture) + d6.ToString(CultureInfo.InvariantCulture) + d7.ToString(CultureInfo.InvariantCulture) + d8.ToString(CultureInfo.InvariantCulture) + d9.ToString(CultureInfo.InvariantCulture) + d10.ToString(CultureInfo.InvariantCulture);
                                                    ulong n = Convert.ToUInt64(concat);
                                                    sum += n;
                                                }
                                                digits[d9] = false;
                                            }
                                            digits[d8] = false;
                                        }
                                        digits[d7] = false;
                                    }
                                    digits[d6] = false;
                                }
                                digits[d5] = false;
                            }
                            digits[d4] = false;
                        }
                        digits[d3] = false;
                    }
                    digits[d2] = false;
                }
                digits[d1] = false;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
