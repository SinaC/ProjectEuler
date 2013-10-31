using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem51
    {
        public ulong Solve()
        {
            // last digit doesnt count because we can't replace it by 0, 2, 5, 4, 6, 8
            const ulong limit = 1000000;
            bool[] sieve = Tools.BuildSieve(limit);
            int[] digits = new int[10];
            for (ulong n = 10001; n < limit; n += 2)
            {
                if (sieve[n]) continue;
                // Check if the number has more than 2 repeating digits excluding last digit
                // Count digits
                string s = n.ToString(CultureInfo.InvariantCulture);
                for (int i = 0; i < 10; i++) digits[i] = 0;
                for (int i = 0; i < s.Length - 1; i++)
                    digits[Tools.ToInt32(s[i])]++;
                // 2 digits
                for (int i = 0; i < digits.Length; i++)
                {
                    if (digits[i] >= 2)
                    {
                        int count = 0;
                        for (int j = 0; j <= 9; j++)
                        {
                            string t = s.Replace((char)(i + 48), (char)(j + 48));
                            int n2 = Convert.ToInt32(t);
                            if (!sieve[n2] && n2.ToString(CultureInfo.InvariantCulture).Length == s.Length) // prime and no leading 0
                                count++;
                        }
                        if (count == 8)
                            return n;
                    }
                }
            }
            return 0;
        }
    }
}
