using System;

namespace ProjectEuler
{
    public class Problem179
    {
        public ulong Solve()
        {
            const ulong limit = 10000000;
            ulong sqrtLimit = (ulong)(Math.Sqrt(limit) + 0.5);
            // Count divisors using sieve
            int[] sieve = new int[limit + 1];
            for (int i = 0; i < sieve.Length; i++)
                sieve[i] = 2;
            for (ulong i = 2; i <= sqrtLimit; i++)
            {
                ulong j = i * i;
                sieve[j]--;
                while (j <= limit)
                {
                    sieve[j] += 2;
                    j += i;
                }
            }
            //
            ulong count = 0;
            for (ulong i = 2; i < limit; i++)
                if (sieve[i] == sieve[i + 1])
                    count++;
            return count;
        }
    }
}
