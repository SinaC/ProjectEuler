using System.Globalization;

namespace ProjectEuler
{
    public class Problem225 : ProblemBase
    {
        public Problem225() : base(225)
        {
        }

        public override string Solve()
        {
            // let i the number to test
            // compute Tn-2, Tn-1, Tn modulo i
            // stop computing when Tn-2 == Tn-1 == Tn == 1 or Tn = 0 (restart the sequence or Tn is divisible by i)
            ulong c = 0;
            ulong i = 27;
            while (true)
            {
                ulong tn2 = 1;
                ulong tn1 = 1;
                ulong tn = 3;
                while (tn > 0 && tn * tn1 * tn2 != 1)
                {
                    ulong oldTn2 = tn2;
                    ulong oldTn1 = tn1;
                    ulong oldTn = tn;
                    tn2 = oldTn1;
                    tn1 = oldTn;
                    tn = (oldTn + oldTn1 + oldTn2) % i;
                }
                if (tn > 0)
                {
                    // not divisible
                    c++;
                    if (c == 124)
                        break;
                }
                i += 2; // odd
            }
            return i.ToString(CultureInfo.InvariantCulture);
        }
    }
}
