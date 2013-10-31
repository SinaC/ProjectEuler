namespace ProjectEuler
{
    public class Problem50
    {
        public ulong Solve()
        {
            //// Brute-force
            //ulong limit = 1000000;
            //bool[] sieve = BuildSieve(limit);
            //int maxCount = 0;
            //ulong nMax = 0;
            //for (ulong n = 1001; n < limit; n += 2) {
            //    if (sieve[n])
            //        continue;
            //    for (ulong start = 2; start <= 13; start++) {
            //        if (sieve[start])
            //            continue;
            //        ulong sum = start;
            //        int count = 1;
            //        for (ulong p = start + 1; p < n; p++) {
            //            if (sieve[p])
            //                continue;
            //            sum += p;
            //            count++;
            //            if (sum >= n)
            //                break;
            //        }
            //        if (sum == n)
            //            if (count > maxCount) {
            //                maxCount = count;
            //                nMax = n;
            //            }
            //    }
            //}
            //return nMax;

            const ulong limit = 1000000;
            bool[] sieve = Tools.BuildSieve(limit);
            ulong maxCount = 0;
            ulong nMax = 0;
            // n(n+1)/2 = sum(i) with sum(i) = 1000000  -> n ~= 1413 (should be lower because prime[i] > i)
            // the gap between 2 primes is > 1 (except for 2 and 3) so we can divide 1413 by 2
            // we suppose there is at least 200 terms
            for (ulong i = 200; i <= 707; i++)
            {
                for (ulong start = 2; start <= 13; start++)
                { 
                    // a long chain must start with the first primes
                    if (sieve[start])
                        continue;
                    ulong sum = (ulong)start;
                    ulong count = 1;
                    ulong p = start + 1;
                    while (true)
                    {
                        if (!sieve[p])
                        {
                            sum += p;
                            count++;
                            if (sum >= limit)
                                break;
                            if (count == i)
                                break;
                        }
                        p++;
                    }
                    if (count == i && sum <= limit && !sieve[sum])
                        if (count > maxCount)
                        {
                            maxCount = count;
                            nMax = sum;
                        }
                }
            }
            return nMax;
        }
    }
}
