using System.Globalization;

namespace ProjectEuler
{
    public class Problem150 : ProblemBase
    {
        public Problem150() : base(150)
        {
        }

        public override string Solve()
        {
            //    0
            //   1 2
            //  3 4 5
            // 6 7 8 9
            // 0: 0, 0 -> 0+0 -> 0+0
            // 1: 0, 1 -> 0+(1+0)
            // 2: 1, 1 -> 1+(1+0)
            // 3: 0, 2 -> 0+(2+1+0)
            // 4: 1, 2 -> 1+(2+1+0)
            // 5: 2, 2 -> 2+(2+1+0)
            // 6: 0, 3 -> 0+(3+2+1+0)
            // 7: 1, 3 -> 1+(3+2+1+0)
            // 8: 2, 3 -> 2+(3+2+1+0)
            // 9: 3, 3 -> 3+(3+2+1+0)
            // col, row -> col + row*(row+1)/2
            // triangle starting at i, j
            // next line: i,j+1 -> i+1,j+1
            // next line: i,j+2 -> i+2,j+2
            // next line: i,j+3 -> i+3,j+3

            long power19 = (long)Tools.Tools.Pow(2, 19);
            long power20 = power19 * 2;
            const int height = 1000;
            const int size = height * (height + 1) / 2;
            long[] array = new long[size];
            long t = 0;
            for (int i = 0; i < size; i++)
            {
                t = (615949 * t + 797807) & (power20 - 1); // modulo 2^20
                array[i] = t - power19;
                //array[i] = i;
            }
            //int height = 6;
            //long[] array = { 
            //    15, 
            //    -14, -7, 
            //    20, -13, -5, 
            //    -3, 8, 23, -26, 
            //    1, -4, -5, -18, 5, 
            //    -16, 31, 2, 9, 28, 3 };
            long[,] sums = new long[1, 1];
            sums[0, 0] = array[0];
            long best = sums[0, 0];
            for (int i = 1; i < height; i++)
            {
                long[,] newSums = new long[i + 1, i + 1];
                //Console.WriteLine("Line:" + i);
                int indexShift = i * (i + 1) / 2;
                for (int j = 0; j <= i; j++)
                {
                    //int index = indexShift + j;
                    //Console.WriteLine(j + "," + i + "->" + index + " = " + array[index]);
                    //Console.WriteLine("++++++++++++++++");
                    long sum = 0;
                    // TOO SLOW
                    //for (int k = i; k < height; k++) {
                    //    //Console.WriteLine("line:" + k);
                    //    int subIndexShift = k * (k + 1) / 2;
                    //    for (int l = 0; l <= k-i; l++) {
                    //        int subIndex = subIndexShift + l + j;
                    //        sum += array[subIndex];
                    //        //Console.WriteLine(l + "," + k + "->" + index + " = " + array[subIndex]);
                    //    }
                    //    //Console.WriteLine("Sum: " + sum);
                    //    if (sum < best) {
                    //        best = sum;
                    //        //Console.WriteLine("Best: " + best);
                    //    }
                    //}
                    // Keep previously computed sum
                    for (int k = j; k <= i; k++)
                    {
                        int subIndex = indexShift + k;
                        sum += array[subIndex];
                        if (j == k)
                            newSums[j, k] = sum;
                        else
                            newSums[j, k] = sum + sums[j, k - 1];
                        if (newSums[j, k] < best)
                            best = newSums[j, k];
                    }
                    //Console.WriteLine("----------------");
                }
                sums = newSums;
            }
            return best.ToString(CultureInfo.InvariantCulture);
        }
    }
}
