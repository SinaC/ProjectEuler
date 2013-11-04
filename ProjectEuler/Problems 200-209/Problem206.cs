using System;
using System.Linq;
using CarlJohansen;

namespace ProjectEuler
{
    public class Problem206
    {
        public ulong Solve()
        {
            // 1_2_3_4_5_6_7_8_9_0
            // must end with 00
            // use 1_2_3_4_5_6_7_8_9 and multiply result by 10
            // must end with an odd number
            string pattern = "1_2_3_4_5_6_7_8_9";
            BigInt n = 138902663; // sqrt(19293949596979899) which is the highest number possible
            while (true)
            {
                BigInt square = n * n;
                string s = square.ToString();
                if (s.Length < pattern.Length)
                    break; // no answer
                char[] arr = s.ToCharArray();
                //bool fOk = true;
                //for (int i = 0; i < arr.Length; i++)
                //    if ((i & 1) == 0 && arr[i] != pattern[i])
                //    {
                //        fOk = false;
                //        break;
                //    }
                bool fOk = !arr.Where((t, i) => (i & 1) == 0 && t != pattern[i]).Any();
                if (fOk)
                    break; // found
                n -= 2; // odd number
            }
            n *= 10;
            return Convert.ToUInt64(n.ToString());
        }
    }
}
