using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem36 : ProblemBase
    {
        public Problem36() : base(36)
        {
        }

        public override string Solve()
        {
            //ulong sum = 0;
            //for (int n = 1; n <= 1000000; n+=2) { // no ending 0 in base 2
            //    if (0 != (n % 10)) { // no ending 0 in base 10
            //        bool fIsPalindromicBase10 = IsPalindromic(n, 10);
            //        bool fIsPalindromicBase2 = IsPalindromic(n, 2);
            //        if (fIsPalindromicBase10 && fIsPalindromicBase2)
            //            sum += (ulong)n;
            //    }
            //}
            //return sum;

            const int limit = 1000000;
            ulong sum = 0;
            for (int nBase10 = 1; nBase10 < limit; nBase10 += 2)
            { // no ending 0 in base 2
                if (0 != (nBase10 % 10))
                { // no ending 0 in base 10
                    bool fOk = true;
                    string sBase10 = Convert.ToString(nBase10);
                    for (int i = 0; i < sBase10.Length / 2; i++)
                        if (sBase10[i] != sBase10[sBase10.Length - i - 1])
                        {
                            fOk = false;
                            break;
                        }
                    if (fOk)
                    {
                        string sBase2 = Convert.ToString(nBase10, 2);
                        for (int i = 0; i < sBase2.Length / 2; i++)
                            if (sBase2[i] != sBase2[sBase2.Length - i - 1])
                            {
                                fOk = false;
                                break;
                            }
                    }
                    if (fOk)
                        sum += (ulong)nBase10;
                }
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
