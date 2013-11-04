using System.Collections.Generic;

namespace ProjectEuler
{
    // TOO SLOW
    public class Problem297
    {
        public ulong Solve()
        {
            //A007895
            const ulong limit = 1000000; // 10^17
            ulong sum = 2; // 1+1
            List<ulong> fibonacci = new List<ulong>
                {
                    1,
                    2
                };
            for (ulong i = 3; i < limit; i++)
            {
                // Compute next fibonacci
                if (i > fibonacci[fibonacci.Count - 1])
                    fibonacci.Add(fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2]);
                // Get Zeckendorf representation of i
                //Console.Write(i+":");
                ulong count = 0;
                ulong n = i;
                int idx = fibonacci.Count - 1;
                while (true)
                    if (fibonacci[idx] > n)
                        idx--;
                    else
                    {
                        //if (count > 0)
                        //    Console.Write("+");
                        //Console.Write(fibonacci[idx]);
                        count++;
                        if (fibonacci[idx] == n)
                            break;
                        n -= fibonacci[idx];
                        idx -= 2;
                    }
                sum += count;
                //Console.WriteLine(" -> "+count);
            }
            return sum;
        }
    }
}
