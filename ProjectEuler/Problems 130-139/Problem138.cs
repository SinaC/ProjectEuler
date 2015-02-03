using System.Globalization;

namespace ProjectEuler
{
    public class Problem138 : ProblemBase
    {
        public Problem138() : base(138)
        {
        }

        public override string Solve()
        {
            //// Brute-force
            //// h=b-1 or h=b+1
            //// h^2 = L^2 - (b/2)^2
            //// (b+/-1)^2 + (b/2)^2 - L^2 = 0
            //// 5/4*b^2 +/- 2*b + 1 - L^2 = 0
            //// delta = 4 - 4*5/4*(1-L^2) = 4 - 5*(1-L^2)
            //// b = ( -/+ b - sqrt(delta) ) / (5/2)
            //// if delta is a perfect square, h = b +/- 1
            //// b must be even
            //ulong limit = 12;
            //ulong sum = 0;
            //ulong side = 5;
            //ulong count = 0;
            //List<ulong> list = new List<ulong>();
            //while (true) {
            //    ulong toTest = 4 - 5 * (1 - side * side);
            //    ulong sqrtToTest = (ulong)(Math.Sqrt(toTest) + 0.5);
            //    if (sqrtToTest * sqrtToTest == toTest) {
            //        list.Add(side);
            //        sum += side;
            //        if ( 0 == ( side & 1 ) )
            //            side++; // Must be odd
            //        count++;
            //        if (limit == count)
            //            break;
            //    }
            //    side += 2;
            //}
            //return sum;

            // First values: 17, 305, 5473, 98209, 1762289, 31622993
            // f(n)/f(n-1) = 17.94...
            // 17*f(n) + f(n-1) -> incorrect
            // 18*f(n) - f(n-1) -> correct
            // f(0) = 1
            // f(1) = 17
            // f(n) = 18*f(n-1) - f(n-2)
            const ulong limit = 12;
            ulong count = 1;
            ulong fn2 = 1;
            ulong fn1 = 17;
            ulong sum = 17;
            while (count < limit)
            {
                ulong fn = 18 * fn1 - fn2;
                sum += fn;
                fn2 = fn1;
                fn1 = fn;
                count++;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
