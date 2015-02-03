using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem102 : ProblemBase
    {
        public Problem102() : base(102)
        {
        }

        public override string Solve()
        {
            ulong count = 0;
            foreach (string line in Lines.Where(line => !String.IsNullOrWhiteSpace(line)))
            {
                string[] tokens = line.Split(',');
                long ax = Convert.ToInt64(tokens[0]);
                long ay = Convert.ToInt64(tokens[1]);
                long bx = Convert.ToInt64(tokens[2]);
                long by = Convert.ToInt64(tokens[3]);
                long cx = Convert.ToInt64(tokens[4]);
                long cy = Convert.ToInt64(tokens[5]);
                bool fIsInTriangle = PointInsideTriangle(ax, ay, bx, by, cx, cy, 0, 0);
                if (fIsInTriangle)
                    count++;
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }

        private static long DotProduct(long ax, long ay, long bx, long by)
        {
            return ax * bx + ay * by;
        }

        private static bool PointInsideTriangle(long ax, long ay, long bx, long by, long cx, long cy, long px, long py)
        {
            //http://www.blackpawn.com/texts/pointinpoly/default.html
            // Compute vectors
            long v0X = cx - ax;
            long v0Y = cy - ay;
            long v1X = bx - ax;
            long v1Y = by - ay;
            long v2X = px - ax;
            long v2Y = py - ay;

            // Compute dot products
            long dot00 = DotProduct(v0X, v0Y, v0X, v0Y);
            long dot01 = DotProduct(v0X, v0Y, v1X, v1Y);
            long dot02 = DotProduct(v0X, v0Y, v2X, v2Y);
            long dot11 = DotProduct(v1X, v1Y, v1X, v1Y);
            long dot12 = DotProduct(v1X, v1Y, v2X, v2Y);

            // Compute barycentric coordinates
            double u = (dot11 * dot02 - dot01 * dot12) / (double)(dot00 * dot11 - dot01 * dot01);
            double v = (dot00 * dot12 - dot01 * dot02) / (double)(dot00 * dot11 - dot01 * dot01);

            // Check if point is in triangle
            return (u > 0) && (v > 0) && (u + v < 1);
        }
    }
}
