﻿using System.Globalization;

namespace ProjectEuler
{
    public class Problem34 : ProblemBase
    {
        public Problem34() : base(34)
        {
        }

        public override string Solve()
        {
            // n*9! = max sum of digit factorial
            // (10^n)-1 = max number with n digits
            // n*9! >= (10^n)-1
            // n    n*9!        (10^n)-1
            // 5    1814400     99999       OK
            // 6    2177288     999999      OK
            // 7    2540160     9999999     KO
            ulong limit = 7 * Tools.Tools.Factorials10[9];
            ulong sum = 0;
            for (ulong n = 3; n <= limit; n++)
            {
                ulong sumFactorialDigits = Tools.Tools.SumFactorialDigits(n);
                if (n == sumFactorialDigits)
                    sum += n;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
