using System.Numerics;

namespace ProjectEuler
{
    public class Problem169 : ProblemBase
    {
        public Problem169() : base(169)
        {
        }

        public override string Solve()
        {
            BigInteger n = BigInteger.Pow(10, 25);
            BigInteger a, b;
            Sub(n, out a, out b);
            return a.ToString();
        }

        private static void Sub(BigInteger n, out BigInteger a, out BigInteger b)
        {
            if (n == 0)
            {
                a = 1;
                b = 0;
            }
            else
            {
                BigInteger a_, b_;
                Sub(n / 2, out a_, out b_);
                if (0 == (n % 2))
                {
                    a = a_ + b_;
                    b = b_;
                }
                else
                {
                    a = a_;
                    b = a_ + b_;
                }
            }
        }
    }
}
