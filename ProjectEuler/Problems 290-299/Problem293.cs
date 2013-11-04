using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem293
    {
        public ulong Solve()
        {
            const ulong limit = 1000000000;
            ulong[] primes = new ulong[150];
            List<ulong> numbers = new List<ulong>();
            List<ulong> previousMultiples = new List<ulong>();

            // Compute 150 first primes
            ulong count = 1;
            primes[0] = 2;
            ulong n = 3;
            while (true)
            {
                if (Primes.Check.IsPrime(n))
                {
                    primes[count++] = n;
                    if (count >= 150)
                        break;
                }
                n += 2;
            }

            // Get power of 2 and multiples of primes
            ulong multiple;
            // Get all power of 2
            multiple = 1;
            while (true)
            {
                multiple = multiple * primes[0];
                if (multiple >= limit)
                    break;
                previousMultiples.Add(multiple);
                numbers.Add(multiple);
            }
            // Get all multiples of a prime and the multiples of the previous prime
            foreach (ulong prime in primes)
            {
                multiple = 1;
                List<ulong> currentMultiples = new List<ulong>();
                while (true)
                {
                    multiple *= prime;
                    if (multiple >= limit)
                        break;
                    foreach (ulong number in previousMultiples)
                    {
                        ulong tmp = multiple * number;
                        if (tmp >= limit)
                            break;
                        currentMultiples.Add(tmp);
                        numbers.Add(tmp);
                    }
                }
                currentMultiples.Sort();
                previousMultiples = currentMultiples;
            }

            // For each of these numbers, find the next prime and build a list of distinct pseudo-fortunate numbers
            Dictionary<ulong, ulong> pseudo = new Dictionary<ulong, ulong>();
            ulong sum = 0;
            foreach (ulong number in numbers)
            {
                ulong nextPrime = number + 2; // Difference must be > 1
                if (0 == (nextPrime & 1))
                    nextPrime++; // Starts with an odd number
                while (!Primes.Check.IsPrime(nextPrime))
                    nextPrime += 2; // skip even number
                ulong diff = nextPrime - number;
                if (!pseudo.ContainsKey(diff))
                {
                    pseudo.Add(diff, diff);
                    sum += diff;
                }
            }

            return sum;
        }
    }
}
