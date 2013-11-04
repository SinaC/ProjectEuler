namespace ProjectEuler
{
    public class Problem110
    {
        public ulong Solve()
        {
            // TODO: optimise using http://www.mathpages.com/home/kmath332.htm and http://oeis.org/A018892

            // Compute first primes
            const int primesCount = 10000;
            ulong[] primes = new ulong[primesCount];
            primes[0] = 2;
            int idx = 1;
            while (idx < primesCount)
            {
                primes[idx] = primes[idx - 1] + 1;
                while (!Primes.Check.IsPrime(primes[idx]))
                    primes[idx]++;
                idx++;
            }
            // Use dichotomy to find the solution
            const ulong limit = 4000000;
            ulong solution;
            ulong n = 1000;
            ulong increment = 1;
            while (true)
            {
                //Console.WriteLine(n + "  " + increment);
                ulong number = ProductPrimesExponent(primes, n, 50, 0);
                ulong count = (FactorOfSquareCount(primes, number) + 1) / 2;
                if (count >= limit)
                {
                    if (1 == increment)
                    { // if limit is reached and increment = 1, solution found
                        solution = number;
                        break;
                    }
                    else
                    {
                        n -= increment; // if limit is reached but increment > 1, went to high, restart from current - increment and reset increment
                        increment = 1;
                    }
                }
                else
                    increment *= 2;
                n += increment;
            }
            return solution;
        }

        private ulong ProductPrimesExponent(ulong[] primes, ulong factorsCount, ulong maxExponent, ulong startingPrimeIndex)
        {
            if (factorsCount <= 1)
                return 1;
            if (factorsCount <= 3)
                return primes[startingPrimeIndex];
            ulong pPow = primes[startingPrimeIndex];
            ulong best = pPow * ProductPrimesExponent(primes, (factorsCount + 2) / 3, 1, startingPrimeIndex + 1);
            for (ulong exponent = 2; exponent <= maxExponent; exponent++)
            {
                pPow *= primes[startingPrimeIndex];
                if (pPow > best)
                    break;
                ulong test = pPow * ProductPrimesExponent(primes, (factorsCount + 2 * exponent) / (2 * exponent + 1), exponent, startingPrimeIndex + 1);
                if (test < best)
                    best = test;
            }
            return best;
        }

        private ulong FactorOfSquareCount(ulong[] primes, ulong n)
        {
            ulong count = 1;
            int idx = 0;
            while (n > 1)
            {
                if (idx >= primes.Length)
                    break; // not a solution if we need a really high prime
                if (0 == (n % primes[idx]))
                {
                    ulong exponentCount = 0;
                    while ((n % primes[idx]) == 0)
                    {
                        exponentCount++;
                        n /= primes[idx];
                    }
                    count *= 2 * exponentCount + 1;
                }
                if (0 == n)
                    break;
                idx++;
            }
            return count;
        }
    }
}
