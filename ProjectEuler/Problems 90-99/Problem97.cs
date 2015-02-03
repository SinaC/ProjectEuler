using System.Globalization;

namespace ProjectEuler
{
    public class Problem97 : ProblemBase
    {
        public Problem97() : base(97)
        {
        }

        public override string Solve()
        {
            // (a*a*a)%n = ((a%n)*(a%n)*(a%n)) %n
            const ulong last10Digits = 10000000000;
            ulong number = (1 + 28433 * Tools.Tools.PowModulo(2, 7830457, last10Digits)) % last10Digits;
            return number.ToString(CultureInfo.InvariantCulture);
        }
    }
}
