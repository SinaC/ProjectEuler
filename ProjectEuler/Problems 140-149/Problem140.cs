using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem140
    {
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

            // Brute-Force to find first value
            //List<ulong> nuggets = new List<ulong>();
            //for (ulong i = 1; i < 100000000; i++)
            //{
            //    ulong delta = 5 * i * i + 14 * i + 1;
            //    if (Tools.IsPerfectSquare(delta))
            //    {
            //        Console.WriteLine(i + "-->" + delta);
            //        nuggets.Add(i);
            //    }
            //}

            // search relation between nugget and fibonacci

            // F
            // 0, 1, 2, 3, 4, 5, 6,  7,  8,  9, 10, 11,  12,  13,  14,  15,  16,   17,   18,   19,   20
            // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765,

            // N
            // 0, 1,  2,  3,   4,   5,    6,    7,    8,     9,    10,    11,     12,     13,      14,      15,       16,       17
            // 2, 5, 21, 42, 152, 296, 1050, 2037, 7205, 13970, 49392, 95760, 338546, 656357, 2320437, 4498746, 15904520, 30834872

            // nugget(1) - nugget(0) = 5-2 = 3 = F(4)
            // nugget(2) - nugget(1) = 21-5 = 16 = 2*F(6)
            // nugget(3) - nugget(2) = 42-21 = 21 = F(8)
            // nugget(4) - nugget(3) = 152-42 = 110 = 2*F(10)
            // nugget(5) - nugget(4) = 296-152 = 144 = F(12)
            // nugget(6) - nugget(5) = 1050-296 = 754 = 2*F(14)
            // nugget(7) - nugget(6) = 2037-1050 = 987 = F(16)

            // n odd: nugget(n+1) - nugget(n) = F( 2*(n+2) )
            // n even: nugget(n+1) - nugget(n) = 2*F( 2*(n+2) )

            // n odd: nugget(n) = nugget(n-1) + F( 2*(n+1) )
            // n even: nugget(n) = nugget(n-1) + 2*F( 2*(n+1) )

            const int limit = 30;

            ulong[] fibonacci = new ulong[2*(limit + 1)];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];

            ulong[] nuggets = new ulong[limit];
            nuggets[0] = 2;
            nuggets[1] = 5;
            for (int i = 2; i < limit; i++)
                if (i%2 != 0)
                    nuggets[i] = nuggets[i - 1] + fibonacci[2*(i + 1)];
                else
                    nuggets[i] = nuggets[i - 1] + 2*fibonacci[2*(i + 1)];

            return nuggets.Aggregate((ulong) 0, (n, i) => n + i);


            // d^2 = 5*n^2 + 14*n + 1 -> diophantine equation http://www.alpertron.com.ar/QUAD.HTM
            // solutions: { 0, -1 }, { 0, 1 }, { -3, -2 }, { -3, 2 }, { -4, -5 }, { -4, 5 }, { 2, -7 }, { 2, 7 }
            // generators:
            //  n[k+1] = -9 * n[k] - 4 * d[k] - 14
            //  d[k+1] = -20 * n[k] - 9 * d[k] - 28

            //List<Tuple<long, long>> start = new List<Tuple<long, long>>
            //    {
            //        new Tuple<long, long>(0, -1),
            //        new Tuple<long, long>(0, 1),
            //        new Tuple<long, long>(-3, -2),
            //        new Tuple<long, long>(-3, 2),
            //        new Tuple<long, long>(-4, -5),
            //        new Tuple<long, long>(-4, 5),
            //        new Tuple<long, long>(2, -7),
            //        new Tuple<long, long>(2, 7)
            //    };
            //List<ulong> nuggets = new List<ulong>();

            //foreach (Tuple<long, long> couple in start)
            //{
            //    long n = couple.Item1;
            //    long d = couple.Item2;

            //    for (int i = 0; i < 30; i++)
            //    {
            //        long nNew = -9*n - 4*d - 14;
            //        long dNew = -20*n - 9*d - 28;

            //        n = nNew;
            //        d = dNew;

            //        ulong unsignedN = (ulong) n;

            //        if (n > 0 && !nuggets.Contains(unsignedN))
            //            nuggets.Add(unsignedN);
            //    }
            //}

            //return nuggets.OrderBy(x => x).Take(30).Aggregate((ulong) 0, (n, i) => n + i);
        }
    }
}