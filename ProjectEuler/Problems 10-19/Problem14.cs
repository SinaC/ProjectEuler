using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem14 : Problem
    {
        public Problem14() : base(14)
        {
        }

        public override string Solve()
        {
            const ulong limit = 1000000;
            int[] lengths = new int[limit];
            for (ulong i = 0; i < limit; i++) 
                lengths[i] = 0;
            int bestLength = 0;
            ulong longest = 0;
            for (ulong n = 2; n < limit; n++)
            {
                if (0 != lengths[n]) // Already computed, don't compute
                    continue;
                // Compute sequence
                List<ulong> sequence = new List<ulong>();
                ulong iterator = n;
                int baseLength = 0;
                sequence.Add(iterator);
                while (true)
                {
                    if (0 == (iterator & 1))
                        iterator >>= 1;
                    else
                        iterator = 3 * iterator + 1;
                    if (iterator < n)
                    {
                        baseLength = lengths[iterator];
                        if (0 != baseLength)
                            break; // Already computed, stop
                    }
                    sequence.Add(iterator);
                    if (iterator == 1)
                        break;
                }
                // Add length foreach number below limit in the sequence
                for (int i = 0; i < sequence.Count; i++)
                {
                    ulong v = sequence[i];
                    if (v < limit)
                    {
                        int length = sequence.Count - i + baseLength;
                        lengths[v] = length;
                        if (length > bestLength)
                        {
                            bestLength = length;
                            longest = v;
                        }
                    }
                }
            }
            return longest.ToString(CultureInfo.InvariantCulture);

            //ulong longest = 0;
            //ulong bestLength = 0;
            //for (ulong i = 2; i <= 1000000; i++) {
            //    ulong iterator = i;
            //    ulong length = 1;
            //    while (iterator != 1) {
            //        length++;
            //        if (length > bestLength) {
            //            bestLength = length;
            //            longest = i;
            //        }
            //        if ((iterator & 1) == 0)
            //            iterator /= 2;
            //        else
            //            iterator = 3 * iterator + 1;
            //    }
            //}
            //return longest;
        }
    }
}
