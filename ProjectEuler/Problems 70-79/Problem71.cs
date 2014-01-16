namespace ProjectEuler
{
    public class Problem71
    {
        public ulong Solve()
        {
            // must find the largest n  with n/d < a/b, d <= 1000000, a=3 and b=7
            // n/d < a/b ==> nb < ad ==> nb <= ad-1 ==> n <= floor(ad-1/b)
            // n/d will be the largest fraction < a/b if n = floor(ad-1/b)
            const ulong limit = 1000000;
            const ulong a = 3;
            const ulong b = 7;
            ulong bestN = 0;
            ulong bestD = 1;
            for (ulong d = 2; d <= limit; d++)
            {
                ulong n = (a * d - 1) / b;
                ulong pgcd = Tools.GCD(n, d);
                if (1 == pgcd && n * bestD > bestN * d)
                {
                    // n/d > bestN/bestD
                    bestN = n;
                    bestD = d;
                }
            }
            return bestN;
        }
    }
}
