using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem79 : ProblemBase
    {
        public Problem79()
            : base(79)
        {
        }

        public override string Solve()
        {
            List<int> list = Lines
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .Select(x => Convert.ToInt32(x)).ToList();
            // Get digits
            List<int> digits = new List<int>();
            foreach (int i in list)
            {
                int n = i;
                for (int j = 0; j < 3; j++)
                {
                    int digit = n%10;
                    if (!digits.Contains(digit))
                        digits.Add(digit);
                    n /= 10;
                }
            }
            //foreach (int d in digits)
            //    Console.Write(d);
            //Console.WriteLine();
            // Create passcode
            foreach (int i in list)
            {
                // digits
                int d0 = (i/100); // 1st digit
                int d1 = (i/10)%10; // 2nd digit
                int d2 = i%10; // 3rd digit

                // offsets
                int o0 = digits.IndexOf(d0);
                int o1 = digits.IndexOf(d1);
                int o2 = digits.IndexOf(d2);

                // check if digits are in right order
                // if not, swap them
                if ( /*o1 >= 0 &&*/ o0 > o1)
                {
                    digits[o0] = d1;
                    digits[o1] = d0;
                    // update o1 for next check
                    o1 = o0;
                }
                if ( /*o2 >= 0 &&*/ o1 > o2)
                {
                    digits[o1] = d2;
                    digits[o2] = d1;
                }
                //Console.Write(i + "->");
                //foreach (int d in digits)
                //    Console.Write(d);
                //Console.WriteLine();
            }
            return digits.Aggregate<int, ulong>(0, (current, i) => current*10 + (ulong) i).ToString(CultureInfo.InvariantCulture);
        }
    }
}
