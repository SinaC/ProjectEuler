using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem234 : ProblemBase
    {
        public Problem234() : base(234)
        {
        }

        //private bool _234_IsPrime(bool[] sieve, ulong n) {
        //    if (n < (ulong)sieve.Length)
        //        return !sieve[n];
        //    if (n <= 1) return false; // 0, 1
        //    if (n < 4) return true; // 2, 3
        //    if (0 == (n & 1)) return false; // even
        //    if (n < 9) return true; // 0, 1, 4, 6, 8 already rejected
        //    if (0 == (n % 3)) return false; // multiple of 3
        //    ulong sqrtN = (ulong)Math.Sqrt(n);
        //    ulong divisor = 5;
        //    while (divisor <= sqrtN) {
        //        if (0 == (n % divisor)) return false;
        //        divisor += 2;
        //        while (sieve[divisor])
        //            divisor+=2;
        //    }
        //    return true;
        //}
        //private ulong _234_SumOfMultipleOfDBetweenAandB(ulong a, ulong b, ulong d) {
        //    a = (a - 1) / d + 1;
        //    b = b / d;
        //    return (((b - a + 1) * (b + a)) / 2) * d;
        //}
        public override string Solve()
        {
            // Brute-force
            //const ulong limit = 999966663333;
            //ulong sqrtLimit = 2 * (ulong)(Math.Sqrt(limit) + 0.5);
            //bool[] sieve = BuildSieve(sqrtLimit);
            //ulong sum = 0;
            //for (ulong i = 4; i <= limit; i++) {
            //    if (!_234_IsPrime(sieve, i)) {
            //        double sqrtI = Math.Sqrt(i);
            //        ulong lps = (ulong)Math.Floor(sqrtI);
            //        if (0 == (lps & 1) && 2 != lps ) // only odd number <> 2
            //            lps--;
            //        while (sieve[lps])
            //            lps-=2;
            //        ulong ups = (ulong)Math.Ceiling(sqrtI);
            //        if (0 == (ups & 1) && 2 != lps) // only odd number <> 2
            //            ups++;
            //        while (sieve[ups])
            //            ups+=2;
            //        long check = 0;
            //        check += ( 0 == ( i % lps ) ) ? 1 : 0;
            //        check += ( 0 == ( i % ups ) ) ? 1 : 0;
            //        if ( 1 == check )
            //            sum += i;
            //    }
            //}
            //return sum;

            const ulong min = 5; // 4 is not semi-divisible, avoid some additional tests
            const ulong max = 999966663333;
            ulong sqrtMax = 2 * (ulong)(Math.Sqrt(max) + 0.5);
            bool[] sieve = Tools.Tools.BuildSieve(sqrtMax);
            ulong lps = 2;
            ulong ups = 3;
            ulong sum = 0;
            while (true)
            {
                // Count numbers between lps^2 and ups^2 divisible by previous or next (but not both)
                //ulong from = lps * lps + 1;
                //ulong to = ups * ups - 1;
                //if (from >= max)
                //    break;
                //if (from < min) from = min;
                //if (to > max) to = max;
                //for (ulong i = from; i <= to; i++) {
                //    long check = 0;
                //    check += (0 == (i % lps)) ? 1 : 0;
                //    check += (0 == (i % ups)) ? 1 : 0;
                //    if (1 == check)
                //        sum += i;
                //}

                // No need to iterate every number between lps^2 and ups^2, consider multiples of lps and ups (not both)
                //// Count numbers between lps^2 and ups^2 divisible by previous or next (but not both)
                //// Get multiple of lps
                //ulong from = lps * lps;
                //ulong to = ups * ups;
                //if (from >= max)
                //    break;
                //// Get multiple of lps
                //Dictionary<ulong, ulong> multipleOfLps = new Dictionary<ulong, ulong>();
                //for (ulong i = from + lps; i <= to; i += lps)
                //    if (i >= min && i <= max)
                //        multipleOfLps.Add(i, i);
                //// Get multiple of ups
                //Dictionary<ulong, ulong> multipleOfUps = new Dictionary<ulong, ulong>();
                //for (ulong i = to - ups; i >= from; i -= ups)
                //    if (i >= min && i <= max)
                //        multipleOfUps.Add(i, i);
                //// Add elements found only in one of the 2 list
                //foreach (KeyValuePair<ulong, ulong> kv in multipleOfLps)
                //    if (!multipleOfUps.ContainsKey(kv.Key))
                //        sum += kv.Key;
                //foreach (KeyValuePair<ulong, ulong> kv in multipleOfUps)
                //    if (!multipleOfLps.ContainsKey(kv.Key))
                //        sum += kv.Key;

                // No need of a dictionary, consider the numbers divisible only by lps or ups (not both)
                ulong from = lps * lps;
                ulong to = ups * ups;
                if (from >= max)
                    break;
                // Get multiple of lps not multiple of ups
                for (ulong i = from + lps; i <= to; i += lps)
                    if (i >= min && i <= max && 0 != (i % ups))
                        sum += i;
                // Get multiple of ups not multiple of lps
                for (ulong i = to - ups; i >= from; i -= ups)
                    if (i >= min && i <= max && 0 != (i % lps))
                        sum += i;

                // Doesn't work
                //// Compute numbers between lps^2 and ups^2 divisible by previous or next (but not both)
                //ulong from = lps * lps + 1;
                //ulong to = ups * ups - 1;
                //if (from >= max)
                //    break;
                //if (from > max)
                //    from = max;
                //sum += (
                //    _234_SumOfMultipleOfDBetweenAandB(from, to, lps)
                //    + _234_SumOfMultipleOfDBetweenAandB(from, to, ups)
                //    - 2 * _234_SumOfMultipleOfDBetweenAandB(from, to, lps * ups));

                // Next prime pair
                lps = ups;
                ups += 2;
                while (sieve[ups]) // Get next prime
                    ups += 2;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
