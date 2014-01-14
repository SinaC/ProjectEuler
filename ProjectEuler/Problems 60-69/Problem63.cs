using System.Text;

namespace ProjectEuler
{
    public class Problem63
    {
        public ulong Solve()
        {
            // 10^n has n+1 digits
            // n must be <= 9 if we want only n digits
            //
            // length(a^b)=n
            // floor(log10(a^b))+1 = b
            // log10(a^b) < b-1
            // b*log10(a) < b-1
            // log10(a) < (b-1)/b
            // b < 1/(1-log10(a))
            // limit a = 9 -> b < 22
            //
            // 9^22 > 64bits!!!
            ulong count = 0;
            for (int a = 1; a < 10; a++)
            {
                string s = "1";
                for (int b = 1; b <= 22; b++)
                {
                    s = MulStringByDigit(s, a);
                    if (s.Length == b)
                        count++;
                }
            }
            return count;
        }

        private static string MulStringByDigit(string multiplicand, int multiplier)
        {
            StringBuilder result = new StringBuilder(multiplicand.Length + 1);
            int carry = 0;
            for (int i = multiplicand.Length - 1; i >= 0; i--)
            {
                int digitA = Tools.ToInt32(multiplicand[i]);
                int product = digitA * multiplier + carry;
                carry = product / 10;
                int digit = product % 10;
                result.Insert(0, digit);
            }
            if (carry > 0)
                result.Insert(0, carry);
            return result.ToString();
        }
    }
}
