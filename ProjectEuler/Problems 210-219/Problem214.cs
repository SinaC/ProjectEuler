using System.Globalization;

namespace ProjectEuler
{
    public class Problem214 : ProblemBase
    {
        public Problem214() : base(214)
        {
        }

        public override string Solve()
        {
            // Brute-force
            //const ulong limit = 40000000;
            //const ulong chainLength = 25;
            //bool[] sieve = BuildSieve(limit);
            //ulong[] totients = new ulong[limit+1];
            //totients[1] = 1;
            //totients[2] = 1;
            //totients[3] = 2;
            //totients[4] = 2;
            //totients[5] = 4;
            //totients[6] = 2;
            //ulong filled = 7;
            //ulong n = 7;
            //ulong sum = 0;
            //while (n <= limit) {
            //    if (0 == totients[n]) {
            //        ulong totient = Phi(sieve, n);
            //        totients[n] = totient;
            //        filled++;
            //        // phi(n*m) = phi(n)*phi(m) * d / phi(d)  with d = GCD(m,n)
            //        // Calculate phi of multiple of multiple < n
            //        for (ulong multiple = 2; multiple < n; multiple++) {
            //            ulong product = multiple * n;
            //            if (product >= limit)
            //                break;
            //            ulong totientMultiple = totients[multiple];
            //            if (0 == totientMultiple) throw new Exception("!!!");
            //            ulong pgcd = GCD(n, multiple);
            //            ulong totientPGCD = totients[pgcd];
            //            if (0 == totientPGCD) throw new Exception("!!!");
            //            totients[product] = (totient * totientMultiple * pgcd) / totientPGCD;
            //            filled++;
            //        }
            //    }
            //    if (!sieve[n]) {
            //        ulong count = 2;
            //        ulong step = totients[n];
            //        while (1 != step) {
            //            step = totients[step];
            //            count++;
            //            if (count > chainLength)
            //                break;
            //        }
            //        if (chainLength == count)
            //            sum += n;
            //    }
            //    n++;
            //}
            //return sum;

            // phi(n*m) = phi(n)*phi(m) * d / phi(d)  with d = GCD(m,n)
            // if m is prime, phi(n*m) = phi(n)*phi(m)
            const ulong limit = 40000000;
            const ulong chainLength = 25;
            bool[] primes = new bool[limit];
            ulong[] totients = new ulong[limit];
            // Init
            for (ulong i = 0; i < limit; i++)
            {
                primes[i] = true; // in the beginning was the prime
                totients[i] = i;
            }
            // Compute totient
            for (ulong i = 2; i < limit; i++)
                if (primes[i])
                {
                    ulong j = i * 2;
                    // Totient of prime is prime-1
                    totients[i] = i - 1;
                    // Compute totient of multiple
                    while (j < limit)
                    {
                        primes[j] = false; // composite
                        totients[j] = totients[j] * (i - 1) / i; // See definition of totient
                        j += i;
                    }
                }
            // Count and sum, totient function is stricly increasing
            ulong sum = 0;
            ulong[] count = new ulong[limit];
            count[1] = 1;
            for (ulong i = 2; i < limit; i++)
            {
                count[i] = count[totients[i]] + 1;
                if (count[i] == chainLength && primes[i])
                    sum += i;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
