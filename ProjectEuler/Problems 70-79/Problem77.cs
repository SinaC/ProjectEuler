namespace ProjectEuler
{
    public class Problem77
    {
        public ulong Solve()
        {
            ulong[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79 };
            const ulong limit = 5000;
            ulong target = 10;
            while (true)
            {
                ulong[] ways = new ulong[target + 1];
                for (ulong i = 0; i < target + 1; i++) ways[i] = 0;
                ways[0] = 1;
                foreach (ulong p in primes)
                    for (ulong i = p; i < target + 1; i++)
                        ways[i] += ways[i - p];
                if (ways[target] > limit)
                    break;
                target++;
            }
            return target;
        }
    }
}
