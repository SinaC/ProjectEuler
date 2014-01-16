using System;
using System.Linq;

namespace ProjectEuler
{
    public class Problem127
    {
        public ulong Solve()
        {
            /*
             Other simple options to save a lot of time based on the relation "a less than b less than c". This is in addition to skipping values of "c" altogether when rad(c)>=c/2.
                1) Process the a=1 first and separately. Skip immediately when rad(b)=b. No need to check the GCD when a=1; it will always be 1 by default.
                2) Then, precalculate c/6 and exit the main loop if rad(c)>=c/6 because rad(a)*rad(b) will be at least 6.
                3) Also skip any "b" value where rad(b)>=c/6 when a>1.
                4) Only the GCD(a,b) ever needs to be checked. If it is equal to 1, the GCD(a,c) and GCD(b,c) would also be equal to 1 by default.
            */
            const ulong limit = 120000;
            ulong[] radicals = Tools.Radicals(limit);
            ulong count1 = 0;
            //ulong count = 0;
            for (ulong c = 2; c < limit; c++)
            {
                ulong rc = radicals[c];
                ulong halfc = c/2;
                if (rc < halfc)
                {
                    ulong b = c - 1;
                    ulong radical = radicals[b]*rc;
                    if (radical < c)
                    {
                        //count++;
                        count1 += c;
                    }
                }
                ulong sixthc = c/6;
                if (rc < sixthc)
                {
                    for (ulong a = 2; a <= halfc; a++)
                    {
                        if ((a%2 != 0) || (c%2 != 0))
                        {
                            ulong radical = rc*radicals[a];
                            if (radical < halfc)
                            {
                                ulong b = c - a;
                                if (radicals[b] < sixthc)
                                {
                                    radical *= radicals[b];
                                    if (radical < c)
                                    {
                                        if (Tools.GCD(radicals[a], radicals[b]) == 1)
                                        {
                                            //count++;
                                            count1 += c;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count1;
        }

        [TooSlow]
        public ulong OLDSolve2()
        {
            const ulong limit = 120000;
            ulong[] radicals = Tools.Radicals(limit);
            //ulong limitSieve = (ulong)(Math.Sqrt(limit * limit * limit) + 0.5);
            //bool[] sieve = Tools.BuildSieve(limitSieve);
            //ulong[] radicals = Enumerable.Range(1, (int) limit).Select(x => Radical(sieve, (ulong) x)).ToArray();
            ulong total = 0;
            for (ulong c = 1; c < limit; c++)
                if (radicals[c] < c)
                {
                    ulong lim = c/radicals[c];
                    for (ulong j = 1; j < c/2; j++)
                        if (Tools.GCD(c, j) == 1)
                            if (radicals[c - j]*radicals[j] < lim) 
                                total += c;
                }
            return total;
        }

        [TooSlow]
        public ulong OLDSolve()
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
                    if (1 != Tools.GCD(a, b)) // by definition
                        continue;
                    if (1 != Tools.GCD(a, c)) // by definition
                        continue;
                    if (1 != Tools.GCD(b, c)) // by definition
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
