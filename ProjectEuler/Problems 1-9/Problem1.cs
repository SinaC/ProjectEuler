using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem1 : ProblemBase
    {
        public Problem1()
            : base(1)
        {
        }

        public override string Solve()
        {
            // sum(i:1->n,i) = n*(n+1)/2  (triangle number)
            // multiple of 3 = 3*sum(i:1->n/3,i)
            // multiple of 5 = 5*sum(i:1->n/5,i)
            // must substract multiple of 15 = 15*sum(i:1->n/15,i)
            const ulong limit = 999;
            ulong result = 3*Tools.Tools.Triangle(limit/3) + 5*Tools.Tools.Triangle(limit/5) - 15*Tools.Tools.Triangle(limit/15);
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
