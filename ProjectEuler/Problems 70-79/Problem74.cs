using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem74 : ProblemBase
    {
        public Problem74() : base(74)
        {
        }

        public override string Solve()
        {
            const ulong limit = 1000000;
            const int chainCount = 60;
            ulong count = 0;
            Dictionary<ulong, int> cache = new Dictionary<ulong, int>();
            for (ulong n = 69; n <= limit; n++)
            {
                int index;
                bool fFound;
                List<ulong> list = new List<ulong>();
                ulong sum = n;
                while (true)
                {
                    fFound = cache.TryGetValue(sum, out index);
                    if (fFound)
                        break;
                    list.Add(sum);
                    sum = Tools.Tools.SumFactorialDigits(sum);
                    index = list.IndexOf(sum);
                    if (-1 != index)
                        break;
                }
                // If found, index represents the length of the chain to add
                // Else, index represents the index of the cycle
                for (int i = 0; i < list.Count; i++)
                    if (fFound)
                        cache.Add(list[i], list.Count - i + index);
                    else if (i < index)
                        cache.Add(list[i], list.Count - i); // before cycle, length is equal to length from the beginning
                    else
                        cache.Add(list[i], list.Count - index); // after cycle, length is equal to cycle length
            }
            foreach (KeyValuePair<ulong, int> kv in cache)
                if (kv.Value == chainCount)
                    count++;
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
