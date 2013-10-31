namespace ProjectEuler
{
    public class Problem53
    {
        public ulong Solve()
        {
            const ulong limit = 1000000;
            // C(n,k) == C(n,n-k)
            const int nLimit = 100;
            ulong count = 0;
            for (int n = 23; n <= nLimit; n++)
                for (int k = 1; k < n; k++)
                {
                    double cnr = _53_Cnk(n, k);
                    if (cnr >= limit)
                    { // Once the limit is reached, every number between k and n-k will break the limit
                        count += (ulong)(n + 1 - 2 * k);
                        break;
                    }
                }
            return count;
        }

        private double _53_Cnk(int n, int k)
        {
            // n!/(k!(n-k)!)
            double result = 1;
            for (int i = k + 1; i <= n; i++)
                result *= (double)i;
            for (int i = 1; i <= (n - k); i++)
                result /= (double)i;
            return result;
        }
    }
}
