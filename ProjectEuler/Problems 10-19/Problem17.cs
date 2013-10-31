namespace ProjectEuler
{
    public class Problem17
    {
        public ulong Solve()
        {
            ulong[,] bases = { {0, 0}, {3, 0}, {3, 6}, {5, 6}, {4, 5}, {4, 5}, {3, 5}, {5, 7}, 
                  {5, 6}, {4, 6}, {3, 0}, {6, 0}, {6, 0}, {8, 0}, {8, 0}, {7, 0},
                  {7, 0}, {9, 0}, {8, 0}, {8, 0} };
            ulong count = 0;
            for (ulong i = 1; i <= 1000; i++)
                count += LettersOfNumber(i, bases);
            return count;
        }

        private static ulong LettersOfNumber(ulong num, ulong[,] bases)
        {
            ulong count = 0;
            if (num == 1000)
                count = 11;
            else
            {
                ulong tempnum = num % 100;
                if (tempnum < 20)
                    count += bases[tempnum, 0];
                else
                    count += bases[num % 10, 0] + bases[(num / 10) % 10, 1];
                if (num > 99)
                    count += bases[(num / 100), 0] + (ulong)(7 + ((tempnum == 0) ? 0 : 3));
            }
            return count;
        }
    }
}
