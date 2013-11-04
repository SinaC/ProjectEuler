using System;

namespace ProjectEuler
{
    public class Problem127
    {
        public ulong Solve()
        {
            const ulong limit = 120000;
            ulong limitSieve = (ulong)(Math.Sqrt(limit * limit * limit) + 0.5);
            bool[] sieve = Tools.BuildSieve(limitSieve);
            //ulong count = 0;
            ulong sum = 0;
            for (ulong a = 1; a < limit / 2; a++)
            {
                ulong radA = (a == 1) ? 1 : Radical(sieve, a);
                for (ulong b = a + 1; b + a < limit; b++)
                {
                    ulong c = a + b;
                    if (!sieve[a] && !sieve[b] && !sieve[c]) // heuristic
                        continue;
                    if (1 != Tools.PGCD(a, b)) // by definition
                        continue;
                    if (1 != Tools.PGCD(a, c)) // by definition
                        continue;
                    if (1 != Tools.PGCD(b, c)) // by definition
                        continue;
                    ulong radB = Radical(sieve, b);
                    ulong radC = Radical(sieve, c);
                    ulong radProduct = radA * radB * radC; // property of radical function
                    if (radProduct < c)
                    { // by definition
                        //Console.WriteLine(a + "," + b + "," + c + "->" + radProduct + " #=" + count + "  sum=" + sum);
                        //count++;
                        sum += c;
                    }
                }
            }
            return sum;
        }

        private ulong Radical(bool[] sieve, ulong n)
        {
            //ulong sqrtN = (ulong)(Math.Sqrt(n) + 0.5);
            ulong p = 2;
            ulong rad = 1;
            while (true)
            {
                if (0 == (n % p))
                    rad *= p;
                while (0 == (n % p))
                    n /= p;
                if (n == 1)
                    break;
                // next prime
                p++;
                while (sieve[p])
                    p++;
            }
            return rad;
        }
    }
}
