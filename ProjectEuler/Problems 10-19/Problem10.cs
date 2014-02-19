using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem10 : Problem
    {
        public Problem10() : base(10)
        {
        }

        public override string Solve()
        {
            const ulong limit = 2000000;
            bool[] sieves = Tools.BuildSieve(limit);
            ulong sum = 2; // 2 is 1st prime
            for (ulong i = 3; i < limit; i+=2)
                if (!sieves[i])
                    sum += i;
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
