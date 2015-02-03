using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem153 : ProblemBase
    {
        public Problem153() : base(153)
        {
        }

        public override string Solve()
        {
            // n/(a+bi) = na/(a^2+b^2) - i * nb/(a^2+b^2)
            // na and nb divisible by a^2+b^2
            // a and b are interchangeable
            // if a+bi divides n, then a-bi, b+ai, b-ai also divides b
            // if a == b, a+bi and b+ai are the same
            // k(a+bi) -> n/k(a+bi) = na/k(a^2+b^2) - i * nb/k(a^2+b^2)

            //const int limit = 16;
            //const int sqrtLimit = 4;
            const ulong limit = 100000000;
            const ulong sqrtLimit = 10000;

            ulong sum = 0;
            for (ulong b = 0; b <= sqrtLimit; b++)
            {
                for (ulong a = b; a <= sqrtLimit; a++)
                {
                    if (b == 0 && a == 0)
                        continue;
                    if (Tools.Tools.GCD(b, a) != 1)
                        continue;
                    // a and b are co-prime
                    //Console.WriteLine("a:{0} b:{1}", a, b);
                    for (ulong k = 1; k <= limit; k++) // get multiple of co-prime couple
                    {
                        ulong x = limit/(k*(a*a + b*b));
                        if (x == 0)
                            break;
                        ulong bb = b*k;
                        ulong aa = a*k;
                        //Console.WriteLine("\tk:{0} aa:{1} bb:{2} x:{3}", k, aa, bb, x);
                        if (aa != 0)
                        {
                            sum += 2*bb*x;
                            //Console.WriteLine("\t\tcomplex factor complex part: {0} {1}", sum, 2*bb*x);
                        }
                        if (bb != aa)
                        {
                            if (bb == 0)
                            {
                                sum += aa*x;
                                //Console.WriteLine("\t\tnatural factor: {0} {1}", sum, aa*x); // sum of factors of each natural
                            }
                            else
                            {
                                sum += 2*aa*x;
                                //Console.WriteLine("\t\tcomplex factor natural part: {0} {1}", sum, 2*aa*x);
                            }
                        }
                    }
                }
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }

        public ulong Solve3()
        {
            const ulong limit = 16;
            ulong[] count = new ulong[limit + 1];

            // special case for 1
            count[1] = 1;
            // divisible by 1 and n
            for (ulong i = 2; i <= limit; i++)
                count[i] += i + 1;
            // if a == b, every multiple of 2*a are divisible a+ai and a-ai
            for (ulong i = 1; i <= limit / 2; i++)
            {
                Console.Write("{0}+{0}i and {0}-{0}i divides: ", i);
                for (ulong j = 2 * i; j < limit; j += 2 * i)
                {
                    Console.Write("{0},", j);
                    count[j] += 2*i;
                }
                Console.WriteLine();
            }
            // every multiple of i
            for(ulong i = 2; i <= limit/2; i++)
            {
                Console.Write("multiple of {0}: ", i);
                for (ulong j = i+i; j < limit; j+=i)
                {
                    Console.Write("{0},", j);
                    count[j] += i;
                }
                Console.WriteLine();
            }

            ulong sqrtLimit = (ulong)Math.Sqrt(limit / 2) + 1;
            for (ulong a = 1; a <= sqrtLimit; a++)
            {
                for (ulong b = a+1; ; b++) // a and b are interchangeable
                {
                    Console.WriteLine("testing {0},{1}", a, b);
                    ulong c = 2 * a + 2 * b; // a+bi+a-bi+b+ai+b-ai
                    ulong s = a * a + b * b;
                    if (s > limit)
                    {
                        Console.WriteLine("{0} breaking limit", s);
                        break;
                    }
                    for (ulong i = 1; i <= limit / s; i++)
                    {
                        // every multiple
                        count[i * s] += c * i;
                        Console.WriteLine("\t{0} is divisible {1}", i * s, c * i);
                    }
                }
            }

            ulong sum = count.Aggregate((ulong)0, (n, i) => n + i);
            ////ulong sum = count.Select((n, i) => i == 0 ? 0 : (limit/(ulong) i)*((ulong) i + n)).Aggregate((ulong) 0, (n, i) => n + i);
            //var x = count.Select((n, i) => i == 0 ? 0 : (limit/(ulong) i)*((ulong) i + n));
            //ulong sum = x.Aggregate((ulong)0, (n, i) => n + i);
            return sum;
        }

        [TooSlow]
        public ulong Solve2()
        {
            // http://oeis.org/A132994

            // n/(a+bi) = na/(a^2+b^2) - i * nb/(a^2+b^2)
            // na and nb divisible by a^2+b^2
            // na/(a^2+b^2) > 0  with n positive integer, a is also positive integer and b is integer
            // b = 0, a = 1 -> 1 solution
            // b = 0, a = n -> 1 solution
            // sum(b) = 0 because if a,b is a solution then a,-b is also a solution
            const ulong limit = 16;
            ulong sum = 0;

            ulong[] count = new ulong[limit+1];

            for (ulong n = 1; n <= limit; n++)
            {
                //Console.WriteLine(n);
                // b = 0, a = n
                Console.Write(n + "," + 0 + " | ");
                sum += n; // n,0
                count[n] += n;
                for (ulong a = 1; a <= n / 2; a++)
                {
                    ulong upperBound = (ulong)(Math.Sqrt(n * n - a * a) + 0.5);
                    // b = 0
                    if (0 == (n % a))
                    {
                        Console.Write(a + "," + 0 + " | ");
                        sum += a; // a,0
                        count[n] += a;
                    }
                    // b > 0
                    for (ulong b = 1; b <= upperBound; b++)
                    {
                        ulong divisor = a * a + b * b;
                        if (0 == ((n * a) % divisor) && 0 == ((n * b) % divisor))
                        {
                            Console.Write(a + "," + b + " | ");
                            Console.Write(a + ",-" + b + " | ");
                            sum += a + b; // a,b and a,-b
                            count[n] += a + b;
                        }
                    }
                }
                Console.WriteLine();
            }
            for(int i = 0; i < count.Length; i++)
                Console.WriteLine("{0}: {1}", i, count[i]);
            ulong s = count.Aggregate((ulong) 0, (n, i) => n + i);
            return sum;
        }
    }
}
