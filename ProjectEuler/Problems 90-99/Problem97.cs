namespace ProjectEuler
{
    public class Problem97
    {
        public ulong Solve()
        {
            // (a*a*a)%n = ((a%n)*(a%n)*(a%n)) %n
            const ulong last10Digits = 10000000000;
            ulong number = (1 + 28433 * Tools.PowModulo(2, 7830457, last10Digits)) % last10Digits;
            return number;
        }
    }
}
