using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem92 : ProblemBase
    {
        public Problem92() : base(92)
        {
        }

        public override string Solve()
        {
            const ulong limit = 10000000;
            Dictionary<ulong, ulong> list89 = new Dictionary<ulong, ulong>();
            Dictionary<ulong, ulong> list1 = new Dictionary<ulong, ulong>();
            list89.Add(89, 89);
            list1.Add(1, 1);
            ulong count = 0;
            for (ulong n = 2; n <= limit; n++)
            {
                if (list89.ContainsKey(n))
                {
                    count++;
                    continue;
                }
                if (list1.ContainsKey(n)) continue;

                List<ulong> list = new List<ulong>();
                ulong i = n;
                while (true)
                {
                    i = SumSquareDigits(i);
                    if (i == 89 || list89.ContainsKey(i))
                    {
                        count++;
                        foreach (ulong item in list)
                            list89.Add(item, item);
                        break;
                    }
                    if (i == 1 || list1.ContainsKey(i))
                    {
                        foreach (ulong item in list)
                            list1.Add(item, item);
                        break;
                    }
                    list.Add(i); // No need to store n, we store only after the first sum
                }
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }

        private static ulong SumSquareDigits(ulong number)
        {
            ulong sum = 0;
            while (number >= 1)
            {
                ulong digit = number % 10;
                sum += digit * digit;
                number /= 10;
            }
            return sum;
        }
    }
}
