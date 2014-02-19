using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem29 : Problem
    {
        public Problem29() : base(29)
        {
        }

        public override string Solve()
        {
            List<double> distinct = new List<double>();
            for (int a = 2; a <= 100; a++)
                for (int b = 2; b <= 100; b++)
                {
                    double pow = Math.Pow(a, b); // no precision problem, lucky us
                    if (!distinct.Contains(pow))
                        distinct.Add(pow);
                }
            return distinct.Count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
