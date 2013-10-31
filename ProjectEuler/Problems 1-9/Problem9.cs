namespace ProjectEuler
{
    public class Problem9
    {
        public ulong Solve()
        {
            for (ulong a = 1; a < 500; a++)
                for (ulong b = 1; b < 500; b++)
                    // a^2 + b^2 = c^2
                    // a + b + c = 1000
                    if (a * a + b * b == (1000 - a - b) * (1000 - a - b))
                        return a * b * (1000 - a - b);
            return 0;
        }
    }
}
