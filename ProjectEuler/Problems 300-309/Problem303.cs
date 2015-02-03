using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem303 : ProblemBase
    {
        public Problem303() : base(303)
        {
        }

        public override string Solve()
        {
            // TODO:
            //ull solve(int x)
            //{
            //    static int found[10010];
            //    memset(found, 0, sizeof(found));
            //    if (x < 3) return 1;
            //    queue<pair<ull, int> > q;
            //    q.push(make_pair(ull(1), 1));
            //    q.push(make_pair(ull(2), 2));
            //    found[1] = found[2] = 1;
            //    while (1) {
            //        ull n = q.front().first;
            //        int m = q.front().second;
            //        q.pop();
            //        if (m == 0) return n/x;
            //        for (int i = 0; i <= 2; i++) {
            //            int nm = (m * 10 + i) % x;
            //            if (!found[nm]) {
            //                found[nm] = 1;
            //                q.push(make_pair(n * 10 + (ull) i, nm));
            //            }
            //        }
            //    }
            //}

            //int main(void)
            //{
            //    int bases[2] = { 100, 10000 };
            //    for (int ti = 0; ti < 2; ti++) {
            //        ull r = 0;
            //        for (int i = 1; i <= bases[ti]; i++) r += solve(i);
            //        cout << "Up to " << bases[ti] << ": " << r << endl;
            //    }
            //    return 0;
            //}


            //// Brute-force
            //ulong limit = 10000;
            //ulong sum = 0;
            //for (ulong n = 1; n <= limit; n++) {
            //    ulong multiplier = 0;
            //    switch (n) {
            //        case 9: multiplier = 1358; break; // fn = 12222
            //        case 99: multiplier = 11335578; break; // fn = 1122222222
            //        case 495: multiplier = 22671156; break; // fn = 11222222220
            //        case 990: multiplier = 11335578; break; // fn = 11222222220
            //        case 999: multiplier = 1113335555778; break; // fn = 1112222220222222
            //        case 4995: multiplier = 2226671111556; break; // fn = 11122222202222220
            //        case 9990: multiplier = 1113335555778; break; // fn = 11122222202222220
            //        case 9999: multiplier = 1111333355555557778; break; // fn = 11112222222200022222222
            //        default: multiplier = 0; break;
            //    }
            //    if ( 0 == multiplier ) {
            //        // Compute f(n)
            //        multiplier = 1;
            //        ulong fn = n * multiplier;
            //        while (true) {
            //            bool fOk = true;
            //            ulong test = fn;
            //            while (test > 0) {
            //                ulong digit = test % 10;
            //                if (digit > 2) {
            //                    fOk = false;
            //                    break;
            //                }
            //                test /= 10;
            //            }
            //            if (fOk)
            //                break;
            //            fn += n; // next multiplier
            //            multiplier++;
            //        }
            //    }
            //    sum += multiplier;
            //    list.Add(multiplier);
            //}

            // 2^64-1 -> 10^19
            // Optimisation 1
            //  n * multiplier = fn
            //  n * 10 * multiplier = fn * 10  (fn * 10 will be written with only of 0, 1, 2)
            //  result[n*10] = multiplier
            // Optimisation 2 only if 2*n < limit
            //  for each divisor d of multiplier
            //      n * d * multiplier / d = fn
            //      result[n*d] = multiplier/d

            const ulong limit = 10000;
            ulong[] multiplierList = new ulong[limit + 1];
            // Generate numbers in base-3 (sorted)
            const ulong digitCount = 15;
            List<ulong> base3List = new List<ulong>();
            GenerateBase3Numbers(digitCount, 0, base3List); // Arbitrary limit
            base3List.RemoveAt(0); // Remove 0
            bool[] sieve = Tools.Tools.BuildSieve(limit); // Arbitrary limit
            //ulong count = 0;
            multiplierList[0] = 0;
            // Compute Fn
            for (ulong n = 1; n <= limit; n++)
            {
                if (0 != multiplierList[n])
                    continue;
                //count++;
                ulong multiplier;
                switch (n)
                {
                    case 9: multiplier = 1358; break; // fn = 12222
                    case 99: multiplier = 11335578; break; // fn = 1122222222
                    case 495: multiplier = 22671156; break; // fn = 11222222220
                    //case 990: multiplier = 11335578; break; // fn = 11222222220
                    case 999: multiplier = 111333555778; break; // fn = 111222222222222
                    case 4995: multiplier = 222667111556; break; // fn = 1112222222222220
                    //case 9990: multiplier = 111333555778; break; // fn = 1112222222222220
                    case 9999: multiplier = 1111333355557778; break; // fn = 11112222222222222222
                    default: multiplier = 0; break;
                }
                // Search if n is a divisor of an item in base-3 list
                foreach (ulong fn in base3List)
                {
                    if (fn >= n)
                    {
                        ulong mod = fn % n;
                        if (0 == mod)
                        {
                            multiplier = fn / n;
                            break;
                        }
                    }
                }

                if (0 == multiplier)
                {
                    //// Not found in list, find it manually
                    //// first multiplier to test must be 10^digitCount / n
                    //// because 10^digitCount is the next base-3
                    //multiplier = Pow(10, digitCount) / n;
                    //ulong fn = n * multiplier;
                    //while (true) {
                    //    bool fOk = true;
                    //    ulong test = fn;
                    //    while (test > 0) {
                    //        ulong digit = test % 10;
                    //        if (digit > 2) {
                    //            fOk = false;
                    //            break;
                    //        }
                    //        test /= 10;
                    //    }
                    //    if (fOk)
                    //        break;
                    //    fn += n; // next multiplier
                    //    multiplier++;
                    //}
                    List<ulong> queue = new List<ulong>
                        {
                            1,
                            2
                        };
                    while (true)
                    {
                        ulong fn = queue[0]; queue.RemoveAt(0);
                        if (fn >= n && 0 == (fn % n))
                        {
                            multiplier = fn / n;
                            break;
                        }
                        for (ulong i = 0; i <= 2; i++)
                            queue.Add(10 * fn + i);
                    }
                }
                multiplierList[n] = multiplier;
                // Optimisation 1
                ulong mul10 = n;
                while (true)
                {
                    mul10 *= 10;
                    if (mul10 > limit)
                        break;
                    multiplierList[mul10] = multiplier;
                }
                // Optimisation 2
                if (multiplier > 3 && 2 * n < limit)
                {
                    //ulong sqrtMultipler = (ulong)(Math.Sqrt(multiplier) + 0.5);
                    ulong p = 2;
                    while (true)
                    {
                        ulong test = multiplier;
                        ulong newN = n;
                        if (newN * p > limit) // stops if limit is reached
                            break;
                        while (test != p && 0 == (test % p))
                        {
                            test /= p;
                            newN *= p;
                            if (newN > limit) // stops if limit is reached
                                break;
                            multiplierList[newN] = test;
                        }
                        if (2 == p)
                            p++;
                        else
                            p += 2;
                        while (p <= limit && sieve[p]) 
                            p += 2;
                        if (p > limit)
                            break;
                    }
                }
            }
            //// DEBUG
            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"..\..\..\output.txt")) {
            //    for (ulong n = 1; n <= limit; n++) {
            //        ulong multiplier = multiplierList[n];
            //        if (multiplier == 0) {
            //            sw.WriteLine(n + "  !!!!!!!!!!!!!!!!NOT FOUND!!!!!!!!!!!!!");
            //        }
            //        else {
            //            ulong fn = n * multiplier;
            //            sw.WriteLine(n + " * " + multiplier + " = " + fn);
            //        }
            //    }
            //    sw.WriteLine("Sum=" + sum);
            //}
            return multiplierList.Aggregate<ulong, ulong>(0, (current, multiplier) => current + multiplier).ToString(CultureInfo.InvariantCulture);
        }

        private static void GenerateBase3Numbers(ulong length, ulong prefix, List<ulong> list)
        {
            if (length == 1)
                for (ulong i = 0; i <= 2; i++)
                    list.Add(prefix + i);
            else
                for (ulong i = 0; i <= 2; i++)
                {
                    ulong newPrefix = i * Tools.Tools.Pow(10, length - 1) + prefix;
                    GenerateBase3Numbers(length - 1, newPrefix, list);
                }
        }
    }
}
