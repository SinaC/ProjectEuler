using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Problem103
    {
        public ulong Solve()
        {
            // min = near_optimal - 1
            ulong[] mins = new ulong[] { 19, 30, 37, 38, 39, 41, 44 };
            // max = near_optimal + 1
            ulong[] maxs = new ulong[] { 21, 32, 39, 40, 41, 43, 46 };
            ulong[] nums = new ulong[] { 19, 30, 37, 38, 39, 41, 44 };
            ulong bestSum = UInt64.MaxValue;
            ulong bestSet = 0;
            DoStuff(mins, maxs, nums, 0, ref bestSum, ref bestSet);
            return bestSet;
        }

        private void DoStuff(ulong[] mins, ulong[] maxs, ulong[] nums, int index, ref ulong bestSum, ref ulong bestSet)
        {
            for (ulong i = mins[index]; i <= maxs[index]; i++)
            {
                nums[index] = i;
                if (index < mins.Length - 1)
                    DoStuff(mins, maxs, nums, index + 1, ref bestSum, ref bestSet);
                else
                {
                    //foreach (ulong n in nums)
                    //    Console.Write(" " + n);
                    //Console.WriteLine();
                    if (Tools.IsSpecialSet(nums))
                    {
                        ulong sum = nums.Aggregate<ulong, ulong>(0, (current, n) => current + n);
                        if (sum < bestSum)
                        {
                            StringBuilder s = new StringBuilder(7 * 2);
                            foreach (ulong n in nums)
                                s.Append(n.ToString(CultureInfo.InvariantCulture));
                            bestSet = Convert.ToUInt64(s.ToString());
                            bestSum = sum;
                        }
                    }
                }
            }
        }
    }
}
