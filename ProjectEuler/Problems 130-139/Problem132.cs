using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem132 : ProblemBase
    {
        public Problem132() : base(132)
        {
        }

        public override string Solve()
        {
            // R(n) = ( 10^n - 1 ) / 9   or R(n) * 9 + 1 = 10^n
            // R(n) = sum(i=1->n-1,10^i)
            // n = 4: 1 + 10^1 + 10^2 + 10^3 = ( 1 + 10^1 ) * ( 1 + 10^2 )
            // n = 5: 1 + 10^1 + 10^2 + 10^3 + 10^4 = ( 1 + 10^1 ) * ( 1 + 10^2 )^+ 10^4
            // n = 6: 1 + 10^1 + 10^2 + 10^3 + 10^4 + 10^5 = ( ( 1 + 10^1 ) + 10^2 ) * ( 1 + 10^3 )
            // ( a + b + c ) mod p = a mod p + b mod p + c mod p
            // R(n) mod p may be computed with a recursive function computing this sum modulo p
            // recurs( n, p )
            //  if n == 1, return 1
            //  if n == 2, return 1 + 10
            //  result = recurs( n/2, p ) mod p * ( 1 + 10^(n/2) mod p ) mod p
            //  if ( n odd )
            //      result += 10^(n-1) mod p
            //  return result

            ulong n = Tools.Tools.Pow(10, 9);
            ulong p = 3; // R(n) not divisible by 2
            List<ulong> factors = new List<ulong>();
            while (true)
            {
                if (Primes.Check.IsPrime(p))
                {
                    ulong remainder = Sub(10, n, p);
                    if (0 == remainder)
                        factors.Add(p);
                }
                if (40 == factors.Count)
                    break;
                p += 2;
            }

            ulong sum = factors.Aggregate<ulong, ulong>(0, (current, factor) => current + factor);
            return sum.ToString(CultureInfo.InvariantCulture);
        }

        private static ulong Sub(ulong b, ulong n, ulong p)
        {
            if (1 == n) return 1;
            if (2 == n) return (1 + b) % p;
            ulong result = ((Sub(b, n / 2, p) % p) * (1 + Tools.Tools.FastPowModulo_BeCareful(10, n / 2, p))) % p;
            if (1 == (n & 1))
                result = (result + Tools.Tools.FastPowModulo_BeCareful(10, n - 1, p)) % p;
            return result;
        }
    }
}
