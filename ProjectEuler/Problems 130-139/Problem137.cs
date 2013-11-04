namespace ProjectEuler
{
    public class Problem137
    {
        public ulong Solve()
        {
            // AF(x) = F1*x + F2*x^2 + F3*x^3 + ... + Fk*x^k ...
            // with Fk = Fk-1 + Fk-2 and F1 = 1 and F2 = 2
            // If AF(x) is a positive integer and x is a rational, AF(x) is called a golden nugget

            // F(x) generating function is x/(1-x-x^2)
            // x/(1-x-x^2) = n
            // n*x^2 + (n+1)*x - n = 0
            // delta = 5n^2+2n+1  must be a perfect square
            // brute-force to get first nuggets

            //// Brute-Force
            //List<ulong> nuggets = new List<ulong>();
            //for (ulong i = 1; i < 100000000; i++) {
            //    ulong delta = 5 * i * i + 2 * i + 1;
            //    if (IsPerfectSquare(delta)) {
            //        Console.WriteLine(i + "-->" + delta);
            //        nuggets.Add(i);
            //    }
            //}

            // 2, 15, 104, 714, 4895, 33552, 229970, 1576239, 10803704
            // nugget(k+1)-nugget(k) = F(4*k+3)
            // nugget(k) = F(2k)*F(2k+1)
            // nugget(k) = 7*nugget(k-1) - nugget(k-2) + 1

            ulong nugget2 = 2;
            ulong nugget1 = 15;
            const int limit = 15;
            for (int i = 3; i <= limit; i++)
            {
                ulong nugget = 7 * nugget1 - nugget2 + 1;
                //Console.WriteLine(i + "-->" + nugget);
                nugget2 = nugget1;
                nugget1 = nugget;
            }

            return nugget1;
        }
    }
}
