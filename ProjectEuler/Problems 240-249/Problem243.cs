using System.Globalization;

namespace ProjectEuler
{
    public class Problem243 : ProblemBase
    {
        public Problem243() : base(243)
        {
        }

        public override string Solve()
        {
            // number of resilient fraction for n = phi(n)
            // R(n) = phi(n) / (n-1) =  1/(n-1) * n * (p1-1)/p1 * (p2-1)/p2 ...
            // primorials(n) = p0 * p1 * p2 .. * pn where pk is the k-th prime
            // totient(a*b) = totient(a)*totient(b)
            // totient(p) = p-1 if p is prime
            // stop when 15499/94744 > totient(primorial)/#proper_fraction(primorial) (=primorial-1)
            // when limit is reached, we have to use previous value to compute Resilience
            // we know Resilience must be a multiple of primorial, so we only have to compute this multiple
            // and return primorial * multiple
            const ulong targetNumerator = 15499;
            const ulong targetDenominator = 94744;
            ulong oldPrimorial = 1;
            ulong oldTotient = 1;
            foreach (ulong p in Tools.Tools.Primes10)
            {
                ulong newPrimorial = oldPrimorial * p; // compute primorials
                ulong newTotient = oldTotient * (p - 1); // compute totient function of primorials
                // targetNumerator/targetDenominator > totient / (primorial-1)
                if (targetNumerator * (newPrimorial - 1) > newTotient * targetDenominator)
                {
                    // limit reached, use old primorial and old totient to compute the multiplier
                    // compute difference between target and current value
                    ulong difference = targetNumerator * oldPrimorial - targetDenominator * oldTotient;
                    ulong multiple = (targetNumerator + difference - 1) / difference; // integral division to get the multiple
                    return (multiple * oldPrimorial).ToString(CultureInfo.InvariantCulture);
                }
                oldPrimorial = newPrimorial;
                oldTotient = newTotient;
            }
            return "0";
        }
    }
}
