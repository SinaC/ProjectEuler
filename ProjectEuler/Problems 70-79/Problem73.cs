namespace ProjectEuler
{
    public class Problem73
    {
        public ulong Solve()
        {
            // must find the largest n
            //  with n/d < a/b      d <= 12000, a=1 and b=2
            //  and  e/f < n/d      d <= 12000, e=1 and f=3
            // see problem 71
            // lower bound: floor(ed+1/f) 
            // upper bound: floor(ad-1/b)
            const ulong limit = 12000;
            const ulong a = 1;
            const ulong b = 2;
            const ulong e = 1;
            const ulong f = 3;
            ulong count = 0;
            ulong invalid0 = 0; // Debug purpose
            ulong invalid1 = 0;
            ulong invalid2 = 0; // Debug purpose
            for (ulong d = 2; d <= limit; d++)
            {
                ulong lowerBound = (e * d + 1) / f;
                ulong upperBound = (a * d - 1) / b;
                for (ulong n = lowerBound; n <= upperBound; n++)
                {
                    if (n * b < a * d && e * d < n * f)
                    {
                        ulong pgcd = Tools.PGCD(n, d);
                        if (1 == pgcd)
                            count++;
                        else
                            invalid0++; // Debug purpose
                    }
                    else
                    {
                        if (n * b >= a * d) invalid1++; // Debug purpose
                        if (e * d >= n * f) invalid2++; // Debug purpose
                    }
                }
            }
            return count;
        }
    }
}
