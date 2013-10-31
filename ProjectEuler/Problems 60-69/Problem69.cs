using System;

namespace ProjectEuler
{
    public class Problem69
    {
        public ulong Solve()
        {
            //// Brute-force
            //// maximize n/phi(n) is equivalent to maximize the number of factors
            //// phi(n) will be low if the number of factors is high because the numbers relatively prime to n will be low
            //ulong limit = 1000000;
            //bool[] sieve = BuildSieve(1001); // sqrt limit
            //ulong maxN = 0;
            //ulong maxFactor = 0;
            //for (ulong n = 3; n < limit; n++) {
            //    ulong factorsCount = _69_GetFactorsCount(sieve, n);
            //    if (factorsCount > maxFactor) {
            //        //Console.WriteLine("n:" + n + "->" + factorsCount);
            //        maxFactor = factorsCount;
            //        maxN = n;
            //    }
            //}
            //return maxN;

            // max is the product of the n first primes
            const ulong limit = 1000000;
            ulong sqrtLimit = (ulong)(Math.Sqrt(limit) + 0.5);
            ulong product = 2;
            for (ulong n = 3; n <= sqrtLimit; n += 2)
                if (Primes.Check.IsPrime(n))
                {
                    ulong newProduct = product * n;
                    if (newProduct > limit)
                        break;
                    else
                        product = newProduct;
                }
            return product;
        }
        
        //private ulong _69_GetFactorsCount(bool[] sieve, ulong n) {
        //    ulong sqrtN = (ulong)Math.Sqrt(n);
        //    ulong factorsCount = 0;
        //    for (ulong j = 2; j <= sqrtN; j++)
        //        if (!sieve[j] && (0 == (n % j)))
        //            factorsCount += 2;
        //    if (sqrtN * sqrtN == n)
        //        factorsCount--; // sqrtN is counted twice if N is a perfect square
        //    return factorsCount;
        //}
    }
}
