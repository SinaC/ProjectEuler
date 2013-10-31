namespace ProjectEuler
{
    public class Problem65
    {
        public ulong Solve()
        {
            //http://en.wikipedia.org/wiki/Continued_fraction#Infinite_continued_fractions
            // e=[2;1,2,1,1,4,1,16,1,1,...,2n,1,1,...]
            // No need to compute the denominator
            // 100th convergent > 64bits
            const ulong limit = 100;
            string numerator2 = "1264";
            string numerator1 = "1457";
            string numerator = "";
            for (ulong i = 11; i <= limit; i++)
            {
                ulong continuedFraction = (0 == (i % 3)) ? 2 * (i / 3) : 1;
                //numerator = numerator_2 + numerator_1 * continuedFraction;
                numerator = numerator2;
                for (ulong j = 0; j < continuedFraction; j++) // compute numerator_1 * continuedFraction
                    numerator = Tools.SumString(numerator, numerator1);
                numerator2 = numerator1;
                numerator1 = numerator;
            }
            return Tools.SumDigits(numerator);
        }
    }
}
