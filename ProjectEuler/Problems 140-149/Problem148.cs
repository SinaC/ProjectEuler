using System.Globalization;
using System.Text;

namespace ProjectEuler
{
    public class Problem148 : ProblemBase
    {
        public Problem148() : base(148)
        {
        }

        public override string Solve()
        {
            // 8th line: 1, 7, 21, 35, 35, 21, 7, 1 -> every numbers except 1 is divisible by 7
            // 9th line: 1, 8, 28, 56, 70, 56, 28, 8, 1 -> 28, 56 and 70 are divisible by 7
            // 10th line: 1, 9, 36, 84, 126, 126, 84, 36, 9, 1 -> 84 and 126 are divisible by 7
            // 11th line: 1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1 -> 210 and 252 are divisible by 7
            // 12th line: 1, 11, 55, 165, 330, 462, 462, 330, 165, 55, 11, 1 -> 462 is divisible by 7
            // 13th line: 1, 12, 66, 220, 495, 792, 924, 798, 495, 220, 66, 12, 1 -> 792 is divisible by 7
            // this pattern is a reverse triangle with a base of 6 -> 21 elements are divisible by 7 [6*(6+1)/2]
            // pattern is a Serpinski triangle

            // It is possible to show that if p is prime, choose(m, n) is not divisible by p if and only if the addition n + (m-n) when written in base p has no carries. This means that the number of entries in the mth row of Pascal's triangle that are not divisible by p is equal to the product over all digits d of m written in base p of 1+d.
            // For example...
            // 10 base 2 is 1001, which means that the number of odd entries in the 10th row of pascal triangle is 2*1*1*2=4.
            // 10 base 5 is 20 --> number of entries in 10th row not divisible by 5 is 3*1=3. 

            // for row n (starting with 0), if we write n in base p
            // n = sum(i=0->k, a(i) * p^i )   k number of digits of n in base p, a(i) = i-th digit of n in base p
            // then, the number of entries in that row is (a(0)+1) * (a(1)+1) * (a(2)+1) ...  * (a(k)+1)
            ulong limit = Tools.Tools.Pow(10, 9);
            ulong p = 7;
            string digits = ConvertToBase(limit - 1, p);
            ulong result = SumUpTo(digits, p);
            return result.ToString(CultureInfo.InvariantCulture);
        }

        private static string ConvertToBase(ulong number, ulong b)
        {
            StringBuilder sb = new StringBuilder();
            while (number > 0)
            {
                ulong digit = number % b;
                char c = (char)(digit + 48);
                sb.Insert(0, c);
                number /= b;
            }
            return sb.ToString();
        }

        private static ulong SumUpTo(string digits, ulong p)
        {
            if (0 == digits.Length)
                return 1;
            ulong k = (ulong)(digits.Length - 1);
            ulong n = (ulong)(digits[0] - 48);
            ulong subResult = SumUpTo(digits.Substring(1, digits.Length - 1), p);
            ulong result = ((n * (n + 1)) / 2) * Tools.Tools.Pow((p * (p + 1)) / 2, k) + (n + 1) * subResult;
            return result;
        }
    }
}
