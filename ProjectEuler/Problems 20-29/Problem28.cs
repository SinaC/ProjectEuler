namespace ProjectEuler
{
    public class Problem28
    {
        public ulong Solve()
        {
            // square side 3 = square side 1 + [ 3 + 5 + 7 + 9 ]
            // square side 5 = square side 3 + [ 13 + 17 + 21 + 25 ]
            // square side 7 = square side 5 + [ 31 + 37 + 43 + 49 ]
            //return Sub(1001);

            // Corners: n^2-3n+3, n^2-2n+2, n^2-n+1, n^2
            // Sum: 4n^2-6n+6
            ulong sum = 1;
            for (ulong i = 3; i <= 1001; i += 2)
                sum += 4 * i * i - 6 * i + 6;
            return sum;
        }
        //private ulong Sub(ulong n) {
        //    if (n == 1)
        //        return 1;
        //    else {
        //        ulong increment = n * n;
        //        ulong sum = 0;
        //        for (int i = 0; i < 4; i++) {
        //            sum += increment;
        //            increment -= (n - 1);
        //        }
        //        return sum + Sub(n - 2);
        //    }
        //}
    }
}
