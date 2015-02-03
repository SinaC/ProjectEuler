using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem144 : ProblemBase
    {
        public Problem144() : base(144)
        {
        }

        public override string Solve()
        {
            // Entering point
            double oldX = 0;
            double oldY = 10.1;
            // First reflection point
            double newX = 1.4;
            double newY = -9.6;
            ulong count = 0;
            while (!(Math.Abs(newX) <= 0.01 && newY > 0))
            {
                count++;
                // Line from old to new
                double m = (oldY - newY) / (oldX - newX);
                double n = oldY - m * oldX;
                // Normal at intersection with ellipse
                double normalM = newY / (4 * newX); // slope, given in problem
                //double normalN = newY - normalM * newX;
                // Reflected line
                double tanAlpha = (m - normalM) / (1 + m * normalM);
                double reflectM = (normalM - tanAlpha) / (1 + normalM * tanAlpha);
                double reflectN = newY - reflectM * newX;
                // old = new
                oldX = newX;
                oldY = newY;
                // Compute new intersection
                double b = (2 * reflectM * reflectN) / (4 + reflectM * reflectM);
                newX = -b - oldX;
                newY = reflectM * newX + reflectN;
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
