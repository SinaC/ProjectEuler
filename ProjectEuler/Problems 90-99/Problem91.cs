using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem91
    {
        public ulong Solve()
        {
            const int limit = 50;
            const int size = limit + 1;
            int counter = Tools.Combinations(Enumerable.Range(1, size*size - 1), 2).Count(p => Check(p[0]/size, p[0]%size, p[1]/size, p[1]%size));
            return (ulong)counter;
        }

        private static bool Check(int x1, int y1, int x2, int y2)
        {
            List<int> lens = new List<int>
                {
                    x1*x1 + y1*y1,
                    x2*x2 + y2*y2,
                    (x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2)
                };
            lens.Sort();

            return lens[0] + lens[1] == lens[2];
        }
    }
}
