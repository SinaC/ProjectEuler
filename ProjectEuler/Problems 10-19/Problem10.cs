namespace ProjectEuler
{
    public class Problem10
    {
        public ulong Solve()
        {
            const ulong limit = 2000000;
            bool[] sieves = Tools.BuildSieve(limit);
            ulong sum = 2;
            for (ulong i = 3; i < limit; i+=2)
                if (!sieves[i])
                    sum += i;
            return sum;
        }
    }
}
