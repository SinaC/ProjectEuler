using System.Globalization;

namespace ProjectEuler
{
    public class Problem188 : ProblemBase
    {
        public Problem188() : base(188)
        {
        }

        public override string Solve()
        {
            // (a*a*a)%n = ((a%n)*(a%n)*(a%n)) %n
            const ulong last8Digits = 100000000;

            ulong previousNumber = 0;
            ulong number = 1;
            ulong exponent = 1855;
            while (exponent > 0)
            {
                number = Tools.Tools.FastPowModulo_BeCareful(1777, number, last8Digits);
                exponent--;
                if (number == previousNumber)
                    break;
                previousNumber = number;
            }
            return number.ToString(CultureInfo.InvariantCulture);
        }
    }
}
