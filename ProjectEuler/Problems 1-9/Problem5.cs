using System;

namespace ProjectEuler
{
    public class Problem5
    {
        public ulong Solve()
        {
            // 1 = 1^1          2 = 2^1
            // 3 = 3^1          4 = 2^2
            // 5 = 5^1          6 = 2^1*3^1
            // 7 = 7^1          8 = 2^3
            // 9 = 3^2          10 = 2^1*5^1
            // 11 = 11^1        12 = 2^2*3^1
            // 13 = 13^1        14 = 2^1*7^1
            // 15 = 3^1*5^1     16 = 2^4
            // 17 = 17^1        18 = 2^1*3^2
            // 19 = 19^1        20 = 2^2*5^1
            // Max exponent for a factor still below limit is Log(limit) / Log(factor) rounded down

            const ulong limit = 20;
            ulong result = 1;
            foreach (ulong factor in Primes.SoE.PrimesCacheFriendly(limit))
            {
                ulong exponent = (ulong)Math.Floor(Math.Log(limit) / Math.Log(factor));
                result *= (ulong)Math.Pow(factor, exponent);
            }

            return result;
        }

        /*
        public ulong Solve() {
            //ulong result = 2 * 3 * 5 * 7 * 9 * 11 * 13 * 17 * 19; // start with the product of the first prime
            //while (true) {
            //    bool fOk = true;
            //    for (ulong i = 11; i <= 20; i++) // if divisible by number between 11 and 20, divisible by 2 to 10
            //        if (0 != (result % i)) {
            //            fOk = false;
            //            break;
            //        }
            //    if (fOk)
            //        break;
            //    result += 2; // must be even
            //}
            //return result;

            // 1 = 1^1          2 = 2^1
            // 3 = 3^1          4 = 2^2
            // 5 = 5^1          6 = 2^1*3^1
            // 7 = 7^1          8 = 2^3
            // 9 = 3^2          10 = 2^1*5^1
            // 11 = 11^1        12 = 2^2*3^1
            // 13 = 13^1        14 = 2^1*7^1
            // 15 = 3^1*5^1     16 = 2^4
            // 17 = 17^1        18 = 2^1*3^2
            // 19 = 19^1        20 = 2^2*5^1
            // result = product of every prime with highest exponent
            return Pow(2, 4) * Pow(3, 2) * 5 * 7 * 11 * 13 * 17 * 19;
        }
         */
    }
}
