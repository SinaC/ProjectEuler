using System;

namespace ProjectEuler
{
    public class Problem153
    {
        public ulong Solve()
        {
            // http://oeis.org/A132994

            // n/(a+bi) = na/(a^2+b^2) - i * nb/(a^2+b^2)
            // na and nb divisible by a^2+b^2
            // na/(a^2+b^2) > 0  with n positive integer, a is also positive integer and b is integer
            // b = 0, a = 1 -> 1 solution
            // b = 0, a = n -> 1 solution
            // sum(b) = 0 because if a,b is a solution then a,-b is also a solution
            const ulong limit = 100000;
            ulong sum = 0;
            for (ulong n = 1; n <= limit; n++)
            {
                //Console.WriteLine(n);
                // b = 0, a = n
                //Console.Write(n + "," + 0 + " | ");
                sum += n; // n,0
                for (ulong a = 1; a <= n / 2; a++)
                {
                    ulong upperBound = (ulong)(Math.Sqrt(n * n - a * a) + 0.5);
                    // b = 0
                    if (0 == (n % a))
                    {
                        //Console.Write(a + "," + 0 + " | ");
                        sum += a; // a,0
                    }
                    // b > 0
                    for (ulong b = 1; b <= upperBound; b++)
                    {
                        ulong divisor = a * a + b * b;
                        if (0 == ((n * a) % divisor) && 0 == ((n * b) % divisor))
                        {
                            //Console.Write(a + "," + b + " | ");
                            //Console.Write(a + ",-" + b + " | ");
                            sum += 2 * a; // a,b and a,-b
                        }
                    }
                }
                //Console.WriteLine();
            }
            return sum;
        }
    }
}
