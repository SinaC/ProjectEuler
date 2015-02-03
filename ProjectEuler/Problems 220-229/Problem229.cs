using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem229 : ProblemBase
    {
        public Problem229() : base(229)
        {
        }

        [TooSlow]
        public override string Solve()
        {
            const ulong limit = 2000000000;
            byte[] flags = new byte[limit/2]; // divide by 2 size, store odd in first quartet and even in second quartet

            Task t1 = Task.Factory.StartNew(() => Flags(flags, limit, 1, 0x01, 0x10));
            Task t2 = Task.Factory.StartNew(() => Flags(flags, limit, 2, 0x02, 0x20));
            Task t4 = Task.Factory.StartNew(() => Flags(flags, limit, 3, 0x04, 0x40));
            Task t7 = Task.Factory.StartNew(() => Flags(flags, limit, 7, 0x08, 0x80));
            Task.WaitAll(t1, t2, t4, t7);
            //Flags(flags, limit, 1, 0x01, 0x10);
            //Flags(flags, limit, 2, 0x02, 0x20);
            //Flags(flags, limit, 3, 0x04, 0x40);
            //Flags(flags, limit, 7, 0x08, 0x80);

            int count = flags.Count(x => (x & 0x0F) == 0x0F) + flags.Count(x => (x & 0xF0) == 0xF0);

            return count.ToString(CultureInfo.InvariantCulture);
        }

        private static void Flags(byte[] flags, ulong limit, ulong multiplier, byte flagEven, byte flagOdd)
        {
            for (ulong a = 1; ; a++)
            {
                ulong a2 = a * a;
                if (a2 > limit)
                    break;
                if (a % 1000 == 0)
                    Console.WriteLine("{0} -> {1}", multiplier, a);
                for (ulong b = 1; ; b++)
                {
                    ulong n = a2 + b * b * multiplier;
                    if (n > limit)
                        break;

                    //flags[n] |= 0x1;
                    if (n % 2 == 0)
                        flags[(n - 1) / 2] |= flagEven;
                    else
                        flags[(n - 1) / 2] |= flagOdd;
                }
            }
        }
    }
}
