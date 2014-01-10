using System;

namespace ProjectEuler
{
    public class Problem160
    {
        [UnderConstruction]
        public ulong Solve()
        {
            //http://mathcentral.uregina.ca/QQ/database/QQ.09.07/s/mukesh1.html
            //http://www.cat4mba.com/forum/number-system/last-non-zero-digit

            // Brute-force
            const ulong numDigits = 5;
            const ulong limit = 1000000000000;
            ulong lastDigits = (ulong)Math.Pow(10, numDigits);
            ulong a2 = 0, a5 = 0;
            ulong result = 1;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"..\..\..\output.txt"))
            {

                for (ulong i = 1; i <= limit; i++)
                {
                    ulong j = i;
                    //divide i by 2 and 5
                    while (j % 2 == 0)
                    {
                        j /= 2;
                        a2++;
                    }
                    while (j % 5 == 0)
                    {
                        j /= 5;
                        a5++;
                    }
                    result = (result * (j % lastDigits)) % lastDigits;
                    if (i == 9 || i == 10 || i == 20 || i == 100 /* || 0 == ( i % (limit/100))*/)
                    {
                        //9-->36288  a2=7  a5=1  result=567
                        //10-->36288  a2=8  a5=2  result=567
                        //20-->17664  a2=18  a5=4  result=55421
                        //1000000000->38144
                        //10000000000-->46112  a2=9999999989  a5=2499999997  result=64047
                        //20000000000-->67808  a2=19999999989  a5=4999999997  result=18223
                        //30000000000-->60896  a2=29999999985  a5=7499999996  result=93133
                        //40000000000-->16576  a2=39999999989  a5=9999999997  result=2831
                        //50000000000-->46112  a2=49999999985  a5=12499999997  result=15377
                        //60000000000-->59904  a2=59999999985  a5=14999999996  result=61517
                        //70000000000-->94528  a2=69999999988  a5=17499999997  result=57711
                        //80000000000-->9376  a2=79999999989  a5=19999999997  result=59631
                        //90000000000-->94208  a2=89999999987  a5=22499999996  result=87621
                        //100000000000-->67808  a2=99999999985  a5=24999999997  result=82193
                        //110000000000-->58816  a2=109999999987  a5=27499999997  result=61959
                        //120000000000-->15008  a2=119999999985  a5=29999999996  result=14509
                        //130000000000-->85664  a2=129999999987  a5=32499999997  result=91811
                        //140000000000-->9664  a2=139999999988  a5=34999999996  result=70859
                        //144112947008-->[[15776 wrong because process stopped in the middle of 2^b]]  a2=144112946992  a5=36028236745  result=65613
                        ulong dump = result;
                        ulong b = a2 - a5;
                        //for (ulong k = 1; k <= b; k++)
                        //    dump = (dump * 2) % lastDigits;
                        ulong multiplier = Tools.PowModulo(2, b, lastDigits);
                        dump = (dump * multiplier) % lastDigits;

                        sw.WriteLine(i + "-->" + dump + "  a2=" + a2 + "  a5=" + a5 + "  result=" + result);
                        sw.Flush();
                    }
                }
                // result = result * 2^a2 * 5^a5
                // number of trailing zeroes = a5
                // 2^a5 * 5^a5 = 10^number of trailing zeroes
                // so we have divided too much while removing trailing zeroes, 2^(a2-a5) gives this factor
                // result without trailing zeroes = result * 2^(a2-a5)
                ulong a = a2 - a5;
                ulong pow2 = Tools.PowModulo(2, a, lastDigits);
                result = (result * pow2) % lastDigits;
                //for (ulong i = 1; i <= a; i++)
                //    result = (result * 2) % lastDigits;
                sw.WriteLine(limit + "-->" + result);
            }
            return result;

            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"..\..\..\output.txt")) {
            //    const ulong numDigits = 1;
            //    //const ulong limit = 2000;
            //    ulong lastDigits = (ulong)Math.Pow(10, numDigits);
            //    for (ulong k = 2; k <= 2; k++) {
            //        ulong a5 = 0;
            //        ulong a2 = 0;
            //        ulong result = 1;
            //        ulong start = (k-1)*lastDigits+1;
            //        ulong end = k*lastDigits;
            //        sw.WriteLine("FROM:" + start + " TO:" + end);
            //        for (ulong i = start; i <= end; i++) {
            //            // Divide i by 2 and 5
            //            ulong j = i;
            //            while (j % 2 == 0) {
            //                j /= 2;
            //                a2++;
            //            }
            //            while (j % 5 == 0) {
            //                j /= 5;
            //                a5++;
            //            }
            //            result = (result * (j % lastDigits)) % lastDigits;
            //            sw.WriteLine(i.ToString().PadLeft(4) + ") " + j.ToString().PadLeft(4) + "  " + result);
            //        }
            //        // a5 gives the number of trailing 0
            //        ulong a = a2 - a5;
            //        for (ulong i = 1; i <= a; i++)
            //            result = (result * 2) % lastDigits;
            //        sw.WriteLine("RESULT:" + result);
            //    }
            //}
            //return 0;
        }
    }
}
