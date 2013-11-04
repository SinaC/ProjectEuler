namespace ProjectEuler
{
    public class Problem231
    {
        public ulong Solve()
        {
            // Cnk = n! / (k! * (n-k)! )
            // sum terms of prime factorisation (a*b) = sum terms of prime factorisation (a) + sum terms of prime factorisation (b)
            // stpf(12*18) = stpf(12) + stpf(18)
            // 12*18 = 2^2*3^1 * 2^1*3^2 = 2^(2+1)*3^(1+3)
            // stpf(12*18) = 2*3 + 3*3
            // stpf(12) = 2*2+3*1
            // stpf(18) = 2*1+3*2
            // same thing for division
            // prime factors of a factorial: http://answers.yahoo.com/question/index?qid=20091027134709AAVJlxi
            const ulong n = 20000000;
            const ulong k = 15000000;
            bool[] sieve = Tools.BuildSieve(n);
            ulong sum = 0;
            for (ulong p = 2; p < (ulong)sieve.Length; p++)
                if (!sieve[p])
                {
                    ulong primeFactorExponentOfCnk = PrimeFactorExponentOfFactorial(n, p) - (PrimeFactorExponentOfFactorial(k, p) + PrimeFactorExponentOfFactorial(n - k, p));
                    sum += p * primeFactorExponentOfCnk;
                }
            return sum;
        }

        private ulong PrimeFactorExponentOfFactorial(ulong n, ulong p)
        {
            // http://homepage.smc.edu/kennedy_john/NFACT.PDF
            // page 8
            ulong sum = 0;
            while (n > 0)
            {
                n /= p;
                sum += n;
            }
            return sum;
        }
    }
}
