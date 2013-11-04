using CarlJohansen;

namespace ProjectEuler
{
    public class Problem169
    {
        public string Solve()
        {
            BigInt n = BigInt.Power(10, 25);
            BigInt a, b;
            Sub(n, out a, out b);
            return a.ToString();
        }

        private void Sub(BigInt n, out BigInt a, out BigInt b)
        {
            if (n == 0)
            {
                a = 1;
                b = 0;
            }
            else
            {
                BigInt a_, b_;
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
