namespace ProjectEuler
{
    // TOO SLOW
    public class Problem258
    {
        public ulong Solve()
        {
            // Gk = Fk-2000
            const ulong limit = 1000000000000000000;
            const ulong mod = 20092010;
            ulong fn = 1;
            ulong fn1 = 1;
            for (ulong n = 2000; n <= limit; n++)
            {
                ulong fn2 = (fn + fn1) % mod;
                fn = fn1;
                fn1 = fn2;
            }
            return fn1;
        }
    }
}
