using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem348
    {
        public ulong Solve()
        {
            ulong sum = 0;
            int found = 0;
            for (Palindrom p = new Palindrom(); found < 5; p.Increment())
            {
                ulong n = p.GetValue();
                int numWays = 0;
                for (ulong c = 1; c*c*c < n; c++)
                {
                    ulong s2 = n - c*c*c;
                    ulong s = (ulong) (Math.Sqrt(s2) + 0.5);
                    if (s*s == s2) 
                        numWays++;
                }
                if (numWays == 4)
                {
                    sum += n;
                    found++;
                }
            }
            return sum;
        }

        public ulong Solve2()
        {
            //const ulong limit = 30000;
            Dictionary<ulong, List<Tuple<ulong, ulong>>> result = new Dictionary<ulong, List<Tuple<ulong, ulong>>>();

            for(ulong i = 1; i < 1000; i++)
                for(ulong j = 1; j < 32000; j++) // sqrt(1000^3)
                {
                    ulong number = i*i*i + j*j;
                    if (Tools.IsPalindromic(number, 10))
                    {
                        List<Tuple<ulong, ulong>> lst;
                        if (!result.TryGetValue(number, out lst))
                        {
                            lst = new List<Tuple<ulong, ulong>>();
                            result.Add(number, lst);
                        }

                        lst.Add(new Tuple<ulong, ulong>(i, j));
                    }
                        
                }
            Dictionary<ulong, List<Tuple<ulong, ulong>>> filteredResult = result.Where(x => x.Value.Count == 4).ToDictionary(x => x.Key, x => x.Value);
            return filteredResult.Aggregate((ulong) 0, (r, kv) => r + kv.Key);
        }
    }
}
