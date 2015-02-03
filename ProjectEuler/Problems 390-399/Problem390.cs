using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem390 : ProblemBase
    {
        public Problem390() : base(390)
        {
        }

        [UnderConstruction]
        public override string Solve()
        {
            // SQRT(1+b^2), SQRT(1+c^2) and SQRT(b^2+c^2)
            // http://en.wikipedia.org/wiki/Triangle#Using_Heron.27s_formula
            // using formula 1/4 SQRT( (a^2+b^2+c^2)^2 - 2*(a^4+b^4+c^4) )
            // S = 1/2 SQRT(b^2+c^2+b^2*c^2) => 4S^2 = b^2+c^2+b^2*c^2 -> b and c must be even

            const ulong limit = 1000000;

            List<Tuple<ulong,ulong>> result = new List<Tuple<ulong, ulong>>();

            const ulong limit2 = 4*limit*limit;
            ulong bMax = (ulong)(Math.Sqrt(2*limit-1)+0.5);
            for (ulong b = 2; b <= bMax; b += 2)
            {
                ulong cMax = (ulong) Math.Sqrt((4.0*limit*limit + 1.0)/(1.0 + b*b) - 1.0);
                for (ulong c = b; c <= cMax; c++)
                {
                    ulong t = b*b + c*c + b*b*c*c;
                    if (t < limit2 && Tools.Tools.IsPerfectSquare(t / 4))
                        result.Add(new Tuple<ulong, ulong>(b, c));
                }
            }

            ulong sum = 0;
            foreach(Tuple<ulong,ulong> tuple in result)
            {
                double c1 = Math.Sqrt(1 + tuple.Item1*tuple.Item1);
                double c2 = Math.Sqrt(1 + tuple.Item2 * tuple.Item2);
                double c3 = Math.Sqrt(tuple.Item1 * tuple.Item1 + tuple.Item2 * tuple.Item2);

                double s = 0.5*(c1 + c2 + c3);
                double area = Math.Sqrt(s*(s - c1)*(s - c2)*(s - c3));
                Console.WriteLine("{0},{1} => {2}", tuple.Item1, tuple.Item2, area);

                sum += (ulong) Math.Round(area);
            }

            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
