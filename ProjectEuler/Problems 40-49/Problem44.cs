using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem44
    {
        public ulong Solve()
        {
            const ulong limit = 10000; // arbitrary limit
            Dictionary<ulong, ulong> pentagonals = new Dictionary<ulong, ulong>();
            for (ulong n = 1; n <= limit; n++)
                pentagonals.Add(Tools.Pentagonal(n), n);
            foreach (KeyValuePair<ulong, ulong> kv1 in pentagonals)
            {
                foreach (KeyValuePair<ulong, ulong> kv2 in pentagonals)
                {
                    ulong diff = kv2.Key - kv1.Key; // kv2 is always >= kv1
                    ulong sum = kv2.Key + kv1.Key;
                    ulong value;
                    if (pentagonals.TryGetValue(diff, out value) && pentagonals.TryGetValue(sum, out value))
                        return diff;
                }
            }
            return 0;
        }
    }
}
