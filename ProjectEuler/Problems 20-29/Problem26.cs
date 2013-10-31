using System.Collections.Generic;

namespace ProjectEuler
{
    public class Problem26
    {
        public ulong Solve()
        {
            ulong longest = 1;
            int length = 1;
            for (ulong i = 3; i <= 1000; i++)
            {
                ulong dividend = 1;
                ulong divisor = i;
                List<ulong> remainders = new List<ulong>();
                // Manual division
                while (true)
                {
                    while (dividend < divisor)
                        dividend *= 10;
                    ulong remainder = dividend % divisor;
                    if (0 == remainder)
                        break;
                    //int quotient = dividend / divisor;
                    if (remainders.Contains(remainder))
                        break;
                    remainders.Add(remainder);
                    dividend = remainder;
                }
                if (remainders.Count > length)
                {
                    length = remainders.Count;
                    longest = i;
                }
            }
            return longest;
        }
    }
}
