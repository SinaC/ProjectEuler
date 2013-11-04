namespace ProjectEuler
{
    public class Problem142
    {
        public ulong Solve()
        {
            // x+y = a^2
            // x-y = b^2
            // x+z = c^2
            // x-z = d^2
            // y+z = e^2
            // y-z = f^2
            //
            // a^2 + b^2 = c^2 + d^2
            // c^2 - b^2 = e^2
            // a^2 - c^2 = f^2
            //
            // x = (a^2+b^2)/2
            // y = (a^2-b^2)/2
            // z = (a^2+b^2)/2 - c^2
            //
            // so, with a, b, c we can find d, e, f and x, y, z
            // a > c > b and must have the same parity
            bool fSolved = false;
            ulong result = 0;
            ulong a = 1;
            while (!fSolved)
            {
                ulong a2 = a * a;
                for (ulong c = a & 1; c < a && !fSolved; c += 2)
                {
                    if (0 == c) continue;
                    ulong c2 = c * c;
                    ulong f2 = a2 - c2;
                    if (!Tools.IsSquare(f2)) continue;
                    for (ulong b = c & 1; b < c && !fSolved; b += 2)
                    {
                        if (0 == b) continue;
                        ulong b2 = b * b;
                        ulong e2 = c2 - b2;
                        if (!Tools.IsSquare(e2)) continue;
                        ulong d2 = a2 + b2 - c2;
                        if (!Tools.IsSquare(d2)) continue;
                        // Found
                        fSolved = true;
                        ulong x = (a2 + b2) / 2;
                        ulong y = (a2 - b2) / 2;
                        ulong z = x - c2;
                        result = x + y + z;
                    }
                }
                a++;
            }
            return result;

            //long a2, b2, c2, d2, e2, f2;
            //bool solved = false;

            //for (long a = 10; !solved; a++) {
            //    a2 = a * a;
            //    for (long c = 5 + (0 & a); c < a && !solved; c += 2) {
            //        c2 = c * c;
            //        f2 = a2 - c2;
            //        if (f2 < 1 || !IsSquare((ulong)f2))
            //            continue;
            //        for (long d = 2 + (1 & c); d < c; d += 2) {
            //            d2 = d * d;
            //            e2 = a2 - d2;
            //            if (e2 < 1 || !IsSquare((ulong)e2))
            //                continue;
            //            b2 = c2 - e2;
            //            if (b2 > 0 && IsSquare((ulong)b2)) {
            //                long x = (a2 + b2) / 2;
            //                long y = (e2 + f2) / 2;
            //                long z = (c2 - d2) / 2;
            //                solved = true;
            //                Console.WriteLine("x= " + x.ToString() +
            //                     " y = " + y.ToString() + " z = " + z.ToString()
            //                     + " sum = " + (z + y + x).ToString());
            //                break;
            //            }
            //        }
            //    }
            //}
            //return 0;
        }
    }
}
