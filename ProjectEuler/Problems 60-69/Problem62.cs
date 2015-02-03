using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem62 : ProblemBase
    {
        public Problem62() : base(62)
        {
        }

        public override string Solve()
        {
            const ulong limit = 1000000;
            // key: cube sorted digits
            // value: list of number whose cube sorted digits equals key
            Dictionary<string, List<ulong>> dict = new Dictionary<string, List<ulong>>();
            for (ulong i = 1; i < limit; i++)
            {
                // compute cube
                ulong cube = i * i * i;
                // sort digits
                char[] arr = cube.ToString(CultureInfo.InvariantCulture).ToCharArray();
                Array.Sort(arr);
                string sorted = new string(arr);
                // search in dictionary if cube already exists
                List<ulong> list;
                bool fFound = dict.TryGetValue(sorted, out list);
                if (!fFound)
                {
                    list = new List<ulong>();
                    dict.Add(sorted, list);
                }
                list.Add(i);
                if (5 == list.Count)
                { // maybe we could have 6 permutations?
                    ulong min = list[0];
                    for (int j = 1; j < list.Count; j++)
                        if (list[j] < min)
                            min = list[j];
                    return (min * min * min).ToString(CultureInfo.InvariantCulture);
                }
            }
            return "0";
        }
    }
}
