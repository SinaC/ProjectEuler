using System;
using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem24 : ProblemBase
    {
        public Problem24():base(24)
        {
        }

        public override string Solve()
        {
            //string[] permutations = Permutations("0123456789");
            //return Convert.ToUInt64(permutations[999999]);

            //999999 = 2*9! + 274239 -> 2nd digit
            //274239 = 6*8! + 32319  -> 6th digit
            //...
            string digits = "0123456789"; // permutation 0
            string result = "";
            ulong n = 999999;
            for (ulong i = 9; i >= 1; i--)
            {
                ulong fact = Tools.Tools.Factorial(i);
                ulong quotient = n / fact;
                n = n % fact;
                result += digits[(int)quotient];
                digits = digits.Substring(0, (int)quotient) + digits.Substring((int)quotient + 1);
            }
            return Convert.ToUInt64(result + digits).ToString(CultureInfo.InvariantCulture);
        }
    }
}
