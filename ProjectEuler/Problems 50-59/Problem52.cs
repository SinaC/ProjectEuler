namespace ProjectEuler
{
    public class Problem52
    {
        public ulong Solve()
        {
            ulong n = 1;
            ulong result;
            while (true)
            {
                //string sortedString = _52_SortString(n.ToString());
                //if (
                //    sortedString == _52_SortString((n * 2).ToString())
                //    && sortedString == _52_SortString((n * 3).ToString())
                //    && sortedString == _52_SortString((n * 4).ToString())
                //    && sortedString == _52_SortString((n * 5).ToString())
                //    && sortedString == _52_SortString((n * 6).ToString())
                //    ) {
                //    result = n;
                //    break;
                //}
                ulong hash = Hash(n);
                if (
                    hash == Hash(n * 2)
                    && hash == Hash(n * 3)
                    && hash == Hash(n * 4)
                    && hash == Hash(n * 5)
                    && hash == Hash(n * 6)
                    )
                {
                    result = n;
                    break;
                }

                n++;
            }
            return result;
        }

        private ulong Hash(ulong n)
        {
            ulong r = 1;
            while (n > 0)
            {
                r *= Tools.Primes10[n % 10];
                n /= 10;
            }
            return r;
        }
    }
}
