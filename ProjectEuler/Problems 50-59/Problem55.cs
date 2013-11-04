using System.Globalization;
using System.Text;

namespace ProjectEuler
{
    public class Problem55
    {
        public ulong Solve()
        {
            const ulong limit = 10000;
            ulong count = 0;
            for (ulong i = 11; i <= limit; i++)
            {
                bool fOk = false;
                string n = i.ToString(CultureInfo.InvariantCulture);
                for (int t = 0; t < 50; t++)
                {
                    string reverse = ReverseString(n);
                    string sum = Tools.SumString(n, reverse);
                    if (IsPalindromic(sum))
                    {
                        fOk = true;
                        break;
                    }
                    n = sum;
                }
                if (!fOk)
                    count++;
            }
            return count;
        }

        private string ReverseString(string s)
        {
            StringBuilder result = new StringBuilder(s.Length);
            int len = s.Length - 1;
            for (int i = 0; i <= len; i++)
                result.Append(s[len - i]);
            return result.ToString();
        }
        private bool IsPalindromic(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - i - 1])
                    return false;
            return true;
        }
    }
}
