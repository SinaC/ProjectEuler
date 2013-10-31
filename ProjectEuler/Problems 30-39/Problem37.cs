using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem37
    {
        public ulong Solve()
        {
            const ulong limit = 1000000; // arbitrary limit
            bool[] sieve = Tools.BuildSieve(limit);
            List<ulong> numbers = new List<ulong>();
            for (ulong n = 11; n < limit; n++)
            {
                if (!sieve[n])
                {
                    bool fOk = true;
                    //string leftAsString = n.ToString();
                    //string rightAsString = (string)leftAsString.Clone();
                    //while (leftAsString.Length > 1) {
                    //    leftAsString = leftAsString.Substring(1);
                    //    int left = Convert.ToInt32(leftAsString);
                    //    if (sieve[left]) {
                    //        fOk = false;
                    //        break;
                    //    }
                    //    rightAsString = rightAsString.Substring(0, rightAsString.Length - 1);
                    //    int right = Convert.ToInt32(rightAsString);
                    //    if (sieve[right]) {
                    //        fOk = false;
                    //        break;
                    //    }
                    //}

                    ulong pow10 = 10;
                    while (true)
                    {
                        ulong left = n / pow10;
                        if (sieve[left])
                        {
                            fOk = false;
                            break;
                        }
                        ulong right = n % pow10;
                        if (sieve[right])
                        {
                            fOk = false;
                            break;
                        }
                        pow10 *= 10;
                        if (left < 10)
                            break;
                    }

                    if (fOk)
                        numbers.Add(n);
                    if (11 == numbers.Count)
                        break;
                }
            }
            return numbers.Aggregate<ulong, ulong>(0, (current, number) => current + (ulong) number);
        }
    }
}
