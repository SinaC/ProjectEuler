namespace ProjectEuler
{
    public class Problem166
    {
        [TooSlow]
        public ulong Solve()
        {
            ulong count = 0;
            for (ulong a1 = 0; a1 < 10; a1++)
                for (ulong a2 = 0; a2 < 10; a2++)
                    for (ulong a3 = 0; a3 < 10; a3++)
                        for (ulong a4 = 0; a4 < 10; a4++)
                            for (ulong a5 = 0; a5 < 10; a5++)
                                for (ulong a6 = 0; a6 < 10; a6++)
                                    for (ulong a7 = 0; a7 < 10; a7++)
                                        for (ulong a9 = 0; a9 < 10; a9++)
                                            for (ulong a11 = 0; a11 < 10; a11++)
                                            {
                                                ulong d = a1 + a2 + a3 + a4;
                                                ulong a8 = d - a5 - a6 - a7;
                                                if (a8 >= 0 && a8 < 10)
                                                {
                                                    ulong a13 = d - a1 - a5 - a9;
                                                    if (a13 >= 0 && a13 < 10)
                                                    {
                                                        ulong a10 = d - a4 - a7 - a13;
                                                        if (a10 >= 0 && a10 < 10)
                                                            if (d == a4 + a7 + a10 + a13)
                                                            {
                                                                ulong a12 = d - a9 - a10 - a11;
                                                                if (a12 >= 0 && a12 < 10)
                                                                {
                                                                    ulong a14 = d - a2 - a6 - a10;
                                                                    if (a14 >= 0 && a14 < 10)
                                                                    {
                                                                        ulong a15 = d - a3 - a7 - a11;
                                                                        if (a15 >= 0 && a15 < 10)
                                                                        {
                                                                            ulong a16 = d - a4 - a8 - a12;
                                                                            if (a16 >= 0 && a16 < 10
                                                                                && d == a13 + a14 + a15 + a16
                                                                                && d == a1 + a6 + a11 + a16)
                                                                                count++;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                    }
                                                }
                                            }
            return count;
        }
    }
}
