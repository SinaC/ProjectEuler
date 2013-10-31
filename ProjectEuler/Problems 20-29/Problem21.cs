﻿namespace ProjectEuler
{
    public class Problem21
    {
        public ulong Solve()
        {
            //ulong sum = 0;
            //for (ulong a = 2; a <= 9999; a++) {
            //    ulong b = SumOfProperDivisors(a);
            //    if (b > a) {
            //        ulong c = SumOfProperDivisors(b);
            //        if (a == c)
            //            sum = sum + a + b;
            //    }
            //}
            //return sum;
            const ulong limit = 10000;
            bool[] sieve = Tools.BuildSieve(limit);
            ulong sum = 0;
            for (ulong i = 10; i < limit; i++)
            {
                if (sieve[i])
                {
                    ulong factorSum = Tools.SumOfProperDivisors(i);
                    ulong amicableFactorSum = Tools.SumOfProperDivisors(factorSum);
                    if (factorSum != amicableFactorSum && i == amicableFactorSum)
                        sum = sum + i;
                }
            }
            return sum;
        }
    }
}