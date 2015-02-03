using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem35 : ProblemBase
    {
        public Problem35() : base(35)
        {
        }

        public override string Solve()
        {
            const ulong limit = 1000000;
            // Optimisation, consider number with 1, 3, 7, 9 as digit -> number ending with 2, 4, 5, 6, 8 are not prime (except 2 and 5)
            ulong count = 4; // 2, 3, 5, 7 are circular prime
            for (ulong i = 10; i < limit; i++)
            {
                // circular prime: 197 -> 971 -> 719 are all primes
                string s = Convert.ToString(i);
                bool fOk = true;
                for (int j = 0; j < s.Length; j++)
                {
                    // If digit is not 1, 3, 7, 9 reject number
                    if (s[0] != '1' && s[0] != '3' && s[0] != '7' && s[0] != '9')
                    {
                        fOk = false;
                        break;
                    }
                    ulong n = Convert.ToUInt64(s);
                    if (!Primes.Check.IsPrime(n))
                    {
                        fOk = false;
                        break;
                    }
                    s = s.Substring(1) + s[0];
                }
                if (fOk)
                    count++;
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
