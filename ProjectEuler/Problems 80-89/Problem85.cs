using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem85 : ProblemBase
    {
        public Problem85() : base(85)
        {
        }

        public override string Solve()
        {
            const long limit = 2000000;
            long bestDiff = limit;
            int bestX = 0;
            int bestY = 0;
            for (int x = 2; x <= 100; x++) // should be enough
                for (int y = 2; y <= 100; y++)
                { // should be enough
                    // Brute-force
                    //long count = 0;
                    //for (int i = 1; i <= y; i++)
                    //    for (int j = 1; j <= x; j++)
                    //        count += (i * j);

                    // sum(i=1->y, sum(j=1->x, i*j))
                    // sum(i=1->y, i*sum(j=1->x, j))
                    // sum(i=1->y, i* x*(x+1)/2)
                    // x*(x+1)/2 * sum(i=1->y, i)
                    // x*(x+1)/2 * y*(y+1)/2
                    long count = (x * (x + 1) * y * (y + 1)) / 4;

                    // Check if closer to limit than previous best solution
                    long diff = Math.Abs(count - limit);
                    if (diff < bestDiff)
                    {
                        bestDiff = diff;
                        bestX = x;
                        bestY = y;
                    }
                }
            return (bestX * bestY).ToString(CultureInfo.InvariantCulture);
        }
    }
}
