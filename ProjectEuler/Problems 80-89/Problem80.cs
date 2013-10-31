using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem80
    {
        public ulong Solve()
        {
            const ulong limit = 100;
            const int precision = 100;
            ulong sum = 0;
            for (ulong i = 2; i <= limit; i++)
            {
                // Only irrational sqrt
                ulong sqrtI = (ulong)(Math.Sqrt(i) + 0.5);
                if (sqrtI * sqrtI == i) continue;
                // Compute sqrt
                string sqrt = SqrtString(i, precision + 5); // add 5 to precision just to be sure
                // Sum digits
                for (int j = 0; j < precision; j++)
                    sum += Tools.ToUInt64(sqrt[j]);
            }
            return sum;
        }

        private string SqrtString(ulong number, int digitsCount)
        {
            //http://www.afjarvis.staff.shef.ac.uk/maths/jarvisspec02.pdf
            string a = (5 * number).ToString(CultureInfo.InvariantCulture);
            string b = "5";
            while (b.Length < digitsCount)
            {
                int cmp = Tools.CompareNumberAsString(a, b);
                if (cmp > 0)
                {
                    a = Tools.SubString(a, b);
                    b = Tools.SumString(b, "10");
                }
                else
                {
                    a = a + "00";
                    b = b.Substring(0, b.Length - 1) + "05";
                }
            }
            return b;
        }
    }
}
