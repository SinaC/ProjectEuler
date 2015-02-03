using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem204 : ProblemBase
    {
        public Problem204() : base(204)
        {
        }

        public override string Solve()
        {
            // Out of memory :p
            //const ulong hamming = 100;
            //const ulong limit = 1000000000+1;
            //ulong[] sieve = new ulong[limit];
            //for (ulong i = 0; i < limit; i++) sieve[i] = i;
            //for (ulong i = 2; i <= hamming; i++)
            //    for (ulong j = i; j < limit; j += i)
            //        if (j > hamming) {
            //            ulong n = sieve[j];
            //            while (0 == (n % i))
            //                n /= i;
            //            sieve[j] = n;
            //        }
            //ulong count = 0;
            //for (ulong i = 0; i < limit; i++)
            //    if (sieve[i] == 1)
            //        count++;
            //return count;

            // Too slow
            //const ulong limit = 1000000000;
            //ulong[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 }; // primes < 100
            //ulong count = 0;
            //for (ulong i = 1; i <= limit; i++) {
            //    ulong n = i;
            //    foreach (ulong prime in primes) {
            //        while (0 == (n % prime))
            //            n /= prime;
            //        if (n == 1) {
            //            count++;
            //            break;
            //        }
            //    }
            //}
            //return count;

            const ulong limit = 1000000000;
            ulong[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 }; // primes < 100
            SortedDictionary<ulong, ulong> multiples = new SortedDictionary<ulong, ulong>
                {
                    {1, 1}
                };
            foreach (ulong prime in primes)
            {
                ulong multiple = 1;
                List<ulong> toAdd = new List<ulong>();
                while (true)
                {
                    multiple *= prime;
                    if (multiple > limit)
                        break;
                    //foreach (KeyValuePair<ulong, ulong> kv in multiples)
                    //{
                    //    ulong tmp = multiple * kv.Key;
                    //    if (tmp > limit)
                    //        break;
                    //    toAdd.Add(tmp);
                    //}
                    toAdd.AddRange(multiples.Select(kv => multiple*kv.Key).TakeWhile(tmp => tmp <= limit));
                }
                foreach (ulong m in toAdd.Where(m => !multiples.ContainsKey(m)))
                    multiples.Add(m, m);
            }
            return multiples.Count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
