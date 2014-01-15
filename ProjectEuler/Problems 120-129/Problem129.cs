namespace ProjectEuler
{
    public class Problem129
    {
        public ulong Solve()
        {
            const ulong limit = 1000000;
            ulong n = limit + 1;
            while (true)
            {
                if (1 == Tools.PGCD(n, 10))
                {
                    // Compute An
                    ulong An = 1;
                    ulong x = 1;
                    // Search repunit divisible by n
                    while (x != 0)
                    {
                        x = (x * 10 + 1) % n;
                        An++;
                    }
                    if (An > limit)
                        break;
                }
                n += 2; // Only odd numbers
            }
            return n;
        }
    }
}
