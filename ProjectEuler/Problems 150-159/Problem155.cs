using System.Linq;

namespace ProjectEuler
{
    public class Problem155
    {
        public ulong Solve()
        {
            //http://oeis.org/A051389
            ulong[] a051389 = { 1, 2, 4, 8, 20, 42, 102, 250, 610, 1486, 3710, 9228, 23050, 57718, 145288, 365820, 922194, 2327914 };
            return a051389.Aggregate<ulong, ulong>(0, (current, n) => current + n);
        }
    }
}
