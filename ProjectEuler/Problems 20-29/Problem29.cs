using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem29
    {
        public ulong Solve()
        {
            List<double> distinct = new List<double>();
            for (int a = 2; a <= 100; a++)
                for (int b = 2; b <= 100; b++)
                {
                    double pow = Math.Pow(a, b); // no precision problem, lucky us
                    if (!distinct.Contains(pow))
                        distinct.Add(pow);
                }
            return (ulong)distinct.Count;
        }
    }
}
