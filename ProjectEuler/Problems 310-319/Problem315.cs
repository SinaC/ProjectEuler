using System.Globalization;
using Primes;

namespace ProjectEuler
{
    public class Problem315 : Problem
    {
        public Problem315()
            : base(315)
        {
        }

        public override string Solve()
        {
            const ulong lowerBound = 10000000;
            const ulong upperBound = 20000000;
            ulong difference = 0;
            for (ulong i = lowerBound; i <= upperBound; ++i)
                if (Check.IsPrime(i))
                    difference += Sam(i) - Max(i);
            return difference.ToString(CultureInfo.InvariantCulture);
        }

        private const int Base = 10;
        private const int SegmentsCount = 7;
        private readonly bool[,] _segments = new[,]
            {
                { // 0
                    true, true, true, false, true, true, true
                },
                { // 1
                    false, false, true, false, false, true, false
                },
                { // 2
                    true, false, true, true, true, false, true
                },
                { // 3
                    true, false, true, true, false, true, true
                },
                { // 4
                    false, true, true, true, false, true, false
                },
                { // 5
                    true, true, false, true, false, true, true
                },
                { // 6
                    true, true, false, true, true, true, true
                },
                { // 7
                    true, true, true, false, false, true, false
                },
                { // 8
                    true, true, true, true, true, true, true
                },
                { // 9
                    true, true, true, true, false, true, true
                }
            };

        private ulong ShowDigitCost(uint n)
        {
            ulong ret = 0;
            for (int i = 0; i < SegmentsCount; i++)
                if (_segments[n, i])
                    ret++;
            return ret;
        }

        private ulong TransitionDigitCost(uint n1, uint n2)
        {
            ulong ret = 0;
            for (int i = 0; i < SegmentsCount; i++)
                if (_segments[n1, i] != _segments[n2, i])
                    ret++;
            return ret;
        }

        private ulong ShowCost(ulong n)
        {
            ulong curr = n;
            ulong ret = 0;
            while (curr != 0)
            {
                ret += ShowDigitCost((uint) (curr%Base));
                curr /= Base;
            }
            return ret;
        }

        private ulong DigitSum(ulong n)
        {
            ulong curr = n;
            ulong ret = 0;
            while (curr != 0)
            {
                ret += curr%Base;
                curr /= Base;
            }
            return ret;
        }

        private ulong Sam(ulong n)
        {
            ulong ret = 2*ShowCost(n);
            ulong sum = DigitSum(n);
            if (sum != n)
                ret += Sam(sum);
            return ret;
        }

        private ulong TransitionCost(ulong n1, ulong n2)
        {
            ulong curr1 = n1;
            ulong curr2 = n2;
            ulong ret = 0;
            while (curr1 != 0 || curr2 != 0)
            {
                if (curr1 != 0 && curr2 != 0)
                {
                    ret += TransitionDigitCost((uint) (curr1%Base), (uint) (curr2%Base));
                    curr1 /= Base;
                    curr2 /= Base;
                }
                else if (curr1 == 0)
                {
                    ret += ShowDigitCost((uint) (curr2%Base));
                    curr2 /= Base;
                }
                else if (curr2 == 0)
                {
                    ret += ShowDigitCost((uint) (curr1%Base));
                    curr1 /= Base;
                }
            }
            return ret;
        }

        private ulong Max(ulong n)
        {
            ulong curr = n;
            ulong ret = ShowCost(curr);
            while (true)
            {
                ulong sum = DigitSum(curr);
                if (sum == curr)
                    break;
                ret += TransitionCost(curr, sum);
                curr = sum;
            }
            return ret + ShowCost(curr);
        }
    }
}