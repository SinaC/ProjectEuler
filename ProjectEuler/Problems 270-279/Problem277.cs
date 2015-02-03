using System;

namespace ProjectEuler
{
    public class Problem277 : ProblemBase
    { 
        public Problem277() : base(277)
        {
        }

        [UnderConstruction]
        public override string Solve()
        {
            // Let An be ( n - a ) / b
            // Compte n, a, b of An+1
            // U: ( n - a ) / b -> ( 4n - (4a-2b) ) / 3b  ==> n = 4n, a = 4a-2b, b = 3b
            // D: ( n - a ) / b -> ( n - a ) / 3b  ==> n = n, a = a, b = 3b
            // d: ( n - a ) / b -> ( 2n - (2a+b) ) / 3b  ==> n = 2n, a=2a+b, b = 3b

            // Build recurrence to get next number
            //const ulong limit = 1000000000000000;
            //string sequence = "DdDddUUdDD";
            //string sequence = "DdDddUUdDDDdUDUUUdDdUUDDDUdDD";
            const string sequence = "UDDDUdddDDUDDddDdDddDDUDDdUUDd";
            long n = 1;
            long a = 0;
            long b = 1;
            foreach (char c in sequence)
            {
                switch (c)
                {
                    case 'U':
                        n = 4 * n;
                        a = 4 * a - 2 * b;
                        b = 3 * b;
                        break;
                    case 'D':
                        b = 3 * b;
                        break;
                    case 'd':
                        n = 2 * n;
                        a = 2 * a + b;
                        b = 3 * b;
                        break;
                    default:
                        n = 0;
                        break;
                }
                Console.WriteLine(c + "-->" + n + "  " + a + "  " + b);
            }

            // the iteration must end with 1
            // ( n*x - a ) / b = 1
            // x = ( b + a ) / n
            long x = (b + a) / n; // give lowest possible number if remainder = 0
            long remainder = (b + a) % n;
            //// TODO: get next value until limit is reached

            // Check
            long an = x;
            Console.WriteLine(an);
            foreach (char operation in sequence)
            {
                bool fStop = false;
                long mod = an % 3;
                switch (operation)
                {
                    case 'D':
                        if (0 != mod)
                            fStop = true;
                        else
                            an = an / 3;
                        break;
                    case 'U':
                        if (1 != mod)
                            fStop = true;
                        else
                            an = (4 * an + 2) / 3;
                        break;

                    case 'd':
                        if (2 != mod)
                            fStop = true;
                        else
                            an = (2 * an - 1) / 3;
                        break;
                }
                if (fStop)
                    break;
                Console.WriteLine(an);
            }

            if (1 != an)
                Console.WriteLine("ERROR");

            return "0";

            ////string sequence = "DdDddUUdDDDdUDUUUdDdUUDDDUdDD";
            ////ulong n = 1000000;
            //string sequence = "UDDDUdddDDUDDddDdDddDDUDDdUUDd";
            //ulong n = 1000000000000001+2;
            //ulong startN = n;
            //int idx = 0;
            //while (true) {
            //    char operation = sequence[idx];
            //    ulong mod = n % 3;
            //    switch (operation) {
            //        case 'D':
            //            if (0 != mod) {
            //                idx = 0;
            //                n = startN + 1;
            //                startN = n;
            //            }
            //            else {
            //                idx++;
            //                n = n / 3;
            //            }
            //            break;
            //        case 'U':
            //            if (1 != mod) {
            //                idx = 0;
            //                n = startN + 1;
            //                startN = n;
            //            }
            //            else {
            //                idx++;
            //                n = (4 * n + 2) / 3;
            //            }
            //            break;

            //        case 'd':
            //            if (2 != mod) {
            //                idx = 0;
            //                n = startN + 1;
            //                startN = n;
            //            }
            //            else {
            //                idx++;
            //                n = (2 * n - 1) / 3;
            //            }
            //            break;
            //    }
            //    if (idx == sequence.Length) {
            //        if (1 == n)
            //            break;
            //        idx = 0;
            //        n = startN + 1;
            //        startN = n;
            //    }
            //}
            //return startN;
        }
    }
}
