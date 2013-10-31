using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem46
    {
        public ulong Solve()
        {
            Dictionary<ulong, ulong> primes = new Dictionary<ulong, ulong>
                {
                    {2, 2},
                    {3, 3}
                };
            ulong result;
            ulong n = 5;
            while (true)
            {
                bool fPrime = primes.All(kv => 0 != (n%kv.Key));
                //foreach (KeyValuePair<ulong, ulong> kv in primes)
                //    if (0 == (n % kv.Key))
                //    {
                //        fPrime = false;
                //        break;
                //    }
                if (fPrime)
                    primes.Add(n, n);
                else
                {
                    bool fFound = false;
                    for (ulong i = 1; i * i <= n; i++)
                    {
                        ulong number = n - 2 * i * i;
                        if (primes.ContainsKey(number))
                        {
                            fFound = true;
                            break;
                        }
                    }
                    if (!fFound)
                    {
                        result = n;
                        break;
                    }
                }
                n += 2; // Only odd composite
            }
            return result;
        }
    }
}
