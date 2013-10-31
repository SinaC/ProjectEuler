namespace ProjectEuler
{
    public class Problem31
    {
        public ulong Solve()
        {
            //1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p)
            //total 200p

            //200=200*a+100*b+50*c+20*d+10*e+5*f+2*g+1*h
            ulong count = 0;
            int a, b, c, d, e, f, g;
            for (a = 200; a >= 0; a -= 200)
                for (b = a; b >= 0; b -= 100)
                    for (c = b; c >= 0; c -= 50)
                        for (d = c; d >= 0; d -= 20)
                            for (e = d; e >= 0; e -= 10)
                                for (f = e; f >= 0; f -= 5)
                                    for (g = f; g >= 0; g -= 2)
                                        count++;
            return count;
        }
    }
}
