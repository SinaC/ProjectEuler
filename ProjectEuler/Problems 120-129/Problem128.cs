using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem128
    {
        public ulong Solve()
        {
            // Only the first and last of each layer must be checked
            // 3n(n-1)+2  first (line above 2, including 2)
            // potential neighbours giving prime
            //  down right: 3n(n+1)+1   diff: 6n-1
            //  up right: 3n(n+3)+7     diff: 12n+5
            //  up left: 3n(n+1)+3      diff: 6n+1
            // 3n(n+1)+1  last (line above 7, excluding 7)
            // potential neighbours giving prime
            //  down left: 3n(n-3)+8    diff: 12n-7
            //  up right: 3n(n+3)+6     diff: 6n+5
            //  up left: 3n(n-1)+2      diff: 6n-1
            const int count = 2000;
            List<ulong> list = new List<ulong>
                {
                    1
                };
            ulong n = 1;
            while (list.Count < count)
            {
                // first
                ulong first = 3 * n * (n - 1) + 2;
                ulong firstNeighbour1Diff = 6 * n - 1;
                ulong firstNeighbour2Diff = 12 * n + 5;
                ulong firstNeighbour3Diff = 6 * n + 1;
                if (Primes.Check.IsPrime(firstNeighbour1Diff) && Primes.Check.IsPrime(firstNeighbour2Diff) && Primes.Check.IsPrime(firstNeighbour3Diff))
                    list.Add(first);

                // last
                if (n != 1)
                { // 7 is excluded
                    ulong last = 3 * n * (n + 1) + 1;
                    ulong lastNeighbour1Diff = 12 * n - 7;
                    ulong lastNeighbour2Diff = 6 * n + 5;
                    ulong lastNeighbour3Diff = 6 * n - 1;
                    if (Primes.Check.IsPrime(lastNeighbour1Diff) && Primes.Check.IsPrime(lastNeighbour2Diff) && Primes.Check.IsPrime(lastNeighbour3Diff))
                        list.Add(last);
                }
                n++;
            }
            list.Sort();
            return list[count - 1];
        }
    }
}
