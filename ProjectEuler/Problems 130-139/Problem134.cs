namespace ProjectEuler
{
    public class Problem134
    {
        public ulong Solve()
        {
            ulong[] digitsCount = { 0, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
            const ulong limit = 1000000;
            bool[] sieve = Tools.BuildSieve(2 * limit);
            ulong p1 = 5; // first prime to consider
            ulong p2 = 7; // consecutive prime
            ulong sum = 0;
            while (true)
            {
                // Get number of digits of p1
                ulong pow10 = 10;
                for (ulong i = 1; i < (ulong)digitsCount.Length; i++)
                {
                    if (p1 <= digitsCount[i])
                        break;
                    pow10 *= 10;
                }

                // Brute-force
                //// Get smallest number multiple of index with last digits == previousIndex
                ////ulong count = 0;
                //ulong n = p2 * p1; // lower bound
                //while (true) {
                //    if (p1 == (n % pow10)) {
                //        // Found
                //        sum += n;
                //        //Console.WriteLine("p1:" + p1 + " p2:" + p2 + "  result:" + n + "  count:"+count);
                //        break;
                //    }
                //    n += p2; // Get next multiple
                //    //count++;
                //}

                // number must be a multiple of p2 and last digits must be equal to p1
                // number % 10^digits(p1) = p1
                // number / p2 must be integral
                // Solve equation p1*x = p2 (mod 10^digits(p1))
                long x, dummy;
                Tools.ExtendedPGCD((long)p2, (long)pow10, out x, out dummy);
                ulong result;
                // number = p2 * ( ( p1 * x ) % 10^digits(p1) )
                if (x < 0)
                    result = p2 * (ulong)((long)pow10 + (((long)p1 * x) % (long)pow10));
                else
                    result = p2 * ((p1 * (ulong)x) % pow10);
                sum += result;

                // Get next prime
                p1 = p2;
                if (p1 >= limit)
                    break;
                while (sieve[++p2])
                    ; // empty statement
            }
            return sum;
        }
    }
}
