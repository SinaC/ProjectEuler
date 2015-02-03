using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem2 : ProblemBase
    {
        public Problem2()
            : base(2)
        {
        }

        // 1, 2, 3, 4, 5, 6,  7,  8,  9, 10, 11
        // 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89
        // => every 3rd number is pair
        // Fn = Fn-1 + Fn-2  (with Fn pair)
        // ...
        // Fn = 4*Fn-3 + Fn-6 (which are both pair)
        public override string Solve()
        {
            const ulong limit = 4000000;
            ulong fib3 = 2;
            ulong fib6 = 0;
            ulong fib = 2;
            ulong sum = 0;
            while(sum < limit)
            {
                sum += fib;
                fib = 4*fib3 + fib6;
                fib6 = fib3;
                fib3 = fib;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }

        //public ulong Solve()
        //{
        //    // Fn = Fn-1 + Fn-2
        //    const ulong limit = 4000000;
        //    ulong Fn_2 = 1;
        //    ulong Fn_1 = 1;
        //    ulong sum = 0;
        //    while (true)
        //    {
        //        ulong Fn = Fn_1 + Fn_2;
        //        if (Fn >= limit)
        //            break;
        //        if ((Fn & 1) == 0)
        //            sum += Fn;
        //        Fn_2 = Fn_1;
        //        Fn_1 = Fn;
        //    }
        //    return sum;
        //}
    }
}
