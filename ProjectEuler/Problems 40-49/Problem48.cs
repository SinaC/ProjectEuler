namespace ProjectEuler
{
    public class Problem48
    {
        public ulong Solve()
        {
            // Only the last 10 digits are significant
            const ulong last10Digits = 10000000000;
            ulong sum = 0;
            for (ulong i = 1; i <= 1000; i++)
            {
                ulong pow = Tools.PowModulo(i, i, last10Digits);
                sum = (sum + pow) % last10Digits; // last 10 digits;
            }
            return sum;
        }
    }
}
