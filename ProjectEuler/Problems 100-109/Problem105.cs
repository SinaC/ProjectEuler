using System;
using System.Linq;

namespace ProjectEuler
{
    public class Problem105
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                ulong total = 0;
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    string[] numbers = s.Split(',');
                    ulong[] set = new ulong[numbers.Length];
                    int idx = 0;
                    foreach (string number in numbers)
                        set[idx++] = Convert.ToUInt64(number);
                    if (Tools.IsSpecialSet(set))
                        total = set.Aggregate(total, (current, val) => current + val);
                }
                return total;
            }
        }
    }
}
