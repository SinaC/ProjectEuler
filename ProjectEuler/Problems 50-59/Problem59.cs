using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem59 : ProblemBase
    {
        public Problem59() : base(59)
        {
        }

        public override string Solve()
        {
            string[] numbers = Data.Split(',');
            char[] encrypted = new char[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                encrypted[i] = (char) (Convert.ToInt32(numbers[i]));
            char[] key = new char[3];
            char[] bestDecoded = null;
            int bestCount = 0;
            bool fStop = false;
            for (char k1 = 'a'; k1 <= 'z' && !fStop; k1++)
            {
                key[0] = k1;
                for (char k2 = 'a'; k2 <= 'z' && !fStop; k2++)
                {
                    key[1] = k2;
                    for (char k3 = 'a'; k3 <= 'z' && !fStop; k3++)
                    {
                        char[] decoded = new char[encrypted.Length];
                        key[2] = k3;
                        for (int i = 0; i < encrypted.Length; i++)
                            decoded[i] = (char) (encrypted[i] ^ key[i%3]);
                        string s = new string(decoded);
                        // Method 1: Look for " the "
                        //if (s.Contains(" the ")) {
                        //  bestDecoded = decoded;
                        //  fStop = true;
                        //}
                        // Method 2: Frequencies count
                        string sToLower = s.ToLower();
                        int count = sToLower.Count(c => c == 'e' || c == 'a' || c == 't' || c == 'i' || c == 'n' || c == ' ');
                        if (count > bestCount)
                        {
                            bestDecoded = decoded;
                            bestCount = count;
                        }
                    }
                }
            }
            if (null != bestDecoded)
                return bestDecoded.Aggregate<char, ulong>(0, (current, c) => current + c).ToString(CultureInfo.InvariantCulture);
            return "0";
        }
    }
}
