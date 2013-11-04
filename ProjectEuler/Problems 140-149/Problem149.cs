namespace ProjectEuler
{
    public class Problem149
    {
        public ulong Solve()
        {
            // |laggedFibonacci| < 1500000
            const long side = 2000;
            // Generate lagged fibonacci
            long[] laggedFibonacci = new long[side * side + 1];
            for (long i = 1; i <= 55; i++)
                laggedFibonacci[i] = ((100003 - 200003 * i + 300007 * i * i * i) % 1000000) - 500000;
            for (long i = 56; i <= side * side; i++)
                laggedFibonacci[i] = ((laggedFibonacci[i - 24] + laggedFibonacci[i - 55] + 1000000) % 1000000) - 500000;
            //// Create grid
            //long[,] grid = new long[side, side];
            //for (long i = 0; i < side; i++)
            //    for (long j = 0; j < side; j++)
            //        grid[i, j] = laggedFibonacci[i * side + j + 1];
            // Get best sum
            long best = 0;
            for (long i = 0; i < side; i++)
            {
                long current1 = 0;
                long current2 = 0;
                for (long j = 0; j < side; j++)
                {
                    if (current1 < 0) current1 = 0;
                    if (current2 < 0) current2 = 0;
                    //current1 += grid[i, j];
                    current1 += laggedFibonacci[i * side + j + 1];
                    //current2 += grid[j, i];
                    current2 += laggedFibonacci[j * side + i + 1];
                    if (current1 > best) best = current1;
                    if (current2 > best) best = current2;
                }
            }
            for (long i = -2000; i <= 2000; i++)
            {
                long current = 0;
                for (long j = 0; j < 2000; j++)
                {
                    if (j + i >= 0 && j + i < 2000)
                    {
                        if (current < 0) current = 0;
                        //current += grid[j, i + j];
                        current += laggedFibonacci[j * side + (j + i) + 1];
                        if (current > best) best = current;
                    }
                }
            }
            for (long i = 0; i < 4000; i++)
            {
                long current = 0;
                for (long j = 0; j < 2000; j++)
                {
                    if (j - i >= 0 && j - i < 2000)
                    {
                        if (current < 0) current = 0;
                        //current += grid[j, j - i];
                        current += laggedFibonacci[j * side + (j - i) + 1];
                        if (current > best) best = current;
                    }
                }
            }

            return (ulong)best;
        }
    }
}
