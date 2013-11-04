using System;
using CarlJohansen;

namespace ProjectEuler
{
    public class Problem119
    {
        public string Solve()
        {
            // Compute a^b (arbitrary limit for a and b) until we have found 40 results. Sort these results and hope the 30th will be the right one :p
            string[] results = new string[40];
            int idx = 0;
            for (uint a = 2; a <= 100; a++)
                for (uint b = 2; b <= 50; b++)
                {
                    BigInt p = BigInt.Power(a, b);
                    string s = p.ToString();
                    ulong sumDigits = Tools.SumDigits(s);
                    if (a == sumDigits)
                        results[idx++] = s;
                    if (idx == results.Length)
                        break;
                }
            Array.Sort(results, Tools.CompareNumberAsString);
            return results[29];
        }
    }
}
