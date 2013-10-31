namespace ProjectEuler
{
    public class Problem10
    {
        public ulong Solve()
        {
            const ulong limit = 20000000;
            bool[] sieves = Tools.BuildSieve(limit);
            ulong sum = 0;
            for (ulong i = 2; i < limit; i++)
                if (!sieves[i])
                    sum += i;
            return sum;
        }
    }
}
