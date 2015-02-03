using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem357 : ProblemBase
    {
        public Problem357() : base(357)
        {
        }

        public ulong Solve2()
        {
            const ulong limit = 100000000;
            // build sieve (0 means prime)
            ulong[] sieve = new ulong[limit];
            for (ulong i = 2; i < limit; i++)
                if (sieve[i] == 0)
                    for (ulong j = i + i; j < limit; j += i)
                        sieve[j] = i;
            //
            ulong sum = 1;
            for (ulong n = 2; n < limit - 1; n+=2)
                if (sieve[n + 1] == 0 && sieve[n/2 + 2] == 0) // n+1 represents first divisor aka 1, n/2+2 represents second divisor aka 2
                {
                    ulong d;
                    bool areAllPrime = true;
                    for (d = 3; d*d <= n; d++)
                        if ((n % d == 0) && sieve[d + n / d] != 0)
                        {
                            areAllPrime = false;
                            break;
                        }
                    if (areAllPrime)
                        sum += n;
                }
            return sum;
        }

        public override string Solve()
        {
            const ulong limit = 1000;
            List<Entry> result = new List<Entry>();
            bool[] sieve = Tools.Tools.BuildSieve(limit+1);
            //ulong[] radicals = Tools.Tools.Radicals(limit+1);
            result.Add(new Entry { Number = 1, Divisors = new List<ulong> { 1 } }); // 1 is ok
            for (ulong n = 2; n < limit; n+=2)
            {
                //if (radicals[n] == n) // heuristics found by testing manually :)
                if (true)
                {
                    List<ulong> divisors = new List<ulong>();
                    // no need to test greather sqrt(n)
                    // example with 30
                    //   < sqrt(n)   > sqrt(n)
                    //  1 + 30/1 = 30 + 30/30
                    //  2 + 30/2 = 15 + 30/15
                    //  3 + 30/3 = 10 + 30/10
                    //  5 + 30/5 =  6 + 30/6
                    bool areAllPrime = true;
                    if (sieve[n + 1]) // first, check n+1
                        areAllPrime = false;
                    else
                    {
                        divisors.Add(1);
                        ulong sqrtN = (ulong) (Math.Sqrt(n) + 0.5);
                        for (ulong d = 2; d <= sqrtN; d++)
                            if (n%d == 0)
                            {
                                divisors.Add(d);
                                ulong t = d + n/d;
                                if (sieve[t])
                                {
                                    areAllPrime = false;
                                    break;
                                }
                            }
                    }
                    if (areAllPrime)
                    {
                        //Console.WriteLine("{0} is prime-generator  {1}", n, divisors.Select(x => x.ToString(CultureInfo.InvariantCulture)).Aggregate((s, i) => s + "," + i));
                        result.Add(new Entry
                            {
                                Number = n,
                                Divisors = divisors
                            });
                    }
                }
            }
            //Console.WriteLine("Count: {0}", result.Count);
            //foreach(Entry entry in result)
            //    //Console.WriteLine("{0} {2} is prime-generator: {1}", entry.Number, entry.Divisors.Select(x => x.ToString(CultureInfo.InvariantCulture)).Aggregate((s, i) => s + "," + i), radicals[entry.Number]);
            //    Console.WriteLine("{0} is prime-generator: {1}", entry.Number, entry.Divisors.Select(x => x.ToString(CultureInfo.InvariantCulture)).Aggregate((s, i) => s + "," + i));

            ulong sum = result.Aggregate((ulong)0, (n,i) => n + i.Number);
            return sum.ToString(CultureInfo.InvariantCulture);
        }

        private class Entry
        {
            public ulong Number { get; set; }
            public List<ulong> Divisors { get; set; }
        }
    }
}
