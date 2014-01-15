using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem140
    {
        //http://www.mathblog.dk/project-euler-140-modified-fibonacci-golden-nuggets/
        public ulong Solve()
        {
            // Compute generating function: Gk = Gk-1 + Gk-2 with G1 = 1 and G2 = 4     http://en.wikipedia.org/wiki/Fibonacci_number#Power_series
            // s(x) = SUM(1,Gk * x^k)  k is SUM index and goes to infinity
            // s(x) = G1 * x + G2 * x^2 + SUM(3,Gk * x^k)
            // s(x) = G1 * x + G2 * x^2 + SUM(3, (Gk-1 + Gk-2) * x^k
            // with G1 = 1 and G2 = 4
            // s(x) = x + 4 * x^2 + SUM(3, (Gk-1 + Gk-2) * x^k)   split sum in 2 sums
            // s(x) = x + 4 * x^2 + SUM(3, Gk-1 * x^k) + SUM(3, Gk-2 * x^k)   extract x and x^2 from sums
            // s(x) = x + 4 * x^2 + x * SUM(3, Gk-1 * x^k-1) + x^2 * SUM(3, Gk-2 * x^k-2)   replace k-1 with k in first sum and k-2 with k in second sum (allowed because sum goes to infinity)
            // s(x) = x + 4 * x^2 + x * SUM(2, Gk * x^k) + x^2 * SUM(1, Gk * x^k)   last sum is s(x) and first sum is s(x) - G1 * x and G1 = 1
            // s(x) = x + 4 * x^2 + x * (s(x) - x) + x^2 * s(x)
            //        x + 3 * x^2
            // s(x) = -----------
            //        1 - x - x^2
            //
            // let n be an integer solution
            // n = (x + 3*x^2)/(1-x-x^2)
            // (3+n) * x^2 + (1+n) * x - n = 0
            // delta = (1+n)^2 + 4*(3+n)*n = 5*n^2 + 14*n + 1  must be a perfect square
            // d^2 = 5*n^2 + 14*n + 1 -> diophantine equation http://www.alpertron.com.ar/QUAD.HTM
            // solutions: { 0, -1 }, { 0, 1 }, { -3, -2 }, { -3, 2 }, { -4, -5 }, { -4, 5 }, { 2, -7 }, { 2, 7 }
            // generators:
            //  n[k+1] = -9 * n[k] - 4 * d[k] - 14
            //  d[k+1] = -20 * n[k] - 9 * d[k] - 28

            List<Tuple<long, long>> start = new List<Tuple<long, long>>
                {
                    new Tuple<long, long>(0, -1),
                    new Tuple<long, long>(0, 1),
                    new Tuple<long, long>(-3, -2),
                    new Tuple<long, long>(-3, 2),
                    new Tuple<long, long>(-4, -5),
                    new Tuple<long, long>(-4, 5),
                    new Tuple<long, long>(2, -7),
                    new Tuple<long, long>(2, 7)
                };
            List<ulong> nuggets = new List<ulong>();

            foreach (Tuple<long, long> couple in start)
            {
                long n = couple.Item1;
                long d = couple.Item2;

                for (int i = 0; i < 30; i++)
                {
                    long nNew = -9*n - 4*d - 14;
                    long dNew = -20*n - 9*d - 28;

                    n = nNew;
                    d = dNew;

                    ulong unsignedN = (ulong) n;

                    if (n > 0 && !nuggets.Contains(unsignedN))
                        nuggets.Add(unsignedN);
                }
            }

            return nuggets.OrderBy(x => x).Take(30).Aggregate((ulong) 0, (n, i) => n + i);
        }
    }
}