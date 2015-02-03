using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem49 : ProblemBase
    {
        public Problem49() : base(49)
        {
        }

        public override string Solve()
        {
            //ulong result = 0;
            //for ( ulong n = 1001; n <= 9999-2*3330; n += 2 ) {
            //    if (n != 1487 && n != 1487 + 3330 && n != 1487+2*3330 && IsPrime(n)) {
            //        ulong n1 = n + 3330;
            //        ulong n2 = n + 2 * 3330;
            //        if (IsPrime(n1) && IsPrime(n2)) {
            //            List<char> strN = new List<char>(n.ToString().ToCharArray());
            //            List<char> strN1 = new List<char>(n1.ToString().ToCharArray());
            //            List<char> strN2 = new List<char>(n2.ToString().ToCharArray());
            //            strN.Sort();
            //            strN1.Sort();
            //            strN2.Sort();
            //            bool fOk = true;
            //            for ( int i = 0; i < strN.Count; i++ )
            //                if (strN[i] != strN1[i] || strN[i] != strN2[i]) {
            //                    fOk = false;
            //                    break;
            //                }
            //            if (fOk) {
            //                result = Convert.ToUInt64(n.ToString() + n1.ToString() + n2.ToString());
            //                break;
            //            }
            //        }
            //    }
            //}
            //return result;

            const ulong limit = 10000;
            ulong result = 0;
            bool[] sieve = Tools.Tools.BuildSieve(limit);
            bool fStop = false;
            for (ulong n = 1001; n < limit && !fStop; n += 2)
            {
                if (n == 1487 || n == 4817 || n == 8147)
                    continue;
                if (sieve[n])
                    continue;
                //for (ulong n1 = n + 2; n1 <= 9999 && !fStop; n1 += 2) {
                for (ulong n1 = n + 3330; n1 <= 9999 && !fStop; n1 += 3330)
                {
                    if (sieve[n1])
                        continue;
                    ulong diff = n1 - n;
                    ulong n2 = n1 + diff;
                    if (n2 > 9999 || sieve[n2])
                        continue;
                    if (Tools.Tools.IsPermutation(n, n1) && Tools.Tools.IsPermutation(n, n2))
                    {
                        result = Convert.ToUInt64(n.ToString(CultureInfo.InvariantCulture) + n1.ToString(CultureInfo.InvariantCulture) + n2.ToString(CultureInfo.InvariantCulture));
                        fStop = true;
                    }
                }
            }
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
