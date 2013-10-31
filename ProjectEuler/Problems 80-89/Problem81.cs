using System;

namespace ProjectEuler
{
    public class Problem81
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                const int size = 80;
                ulong[,] matrix = new ulong[size, size];
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    string[] numbers = s.Split(',');
                    int j = 0;
                    foreach (string number in numbers)
                        matrix[i, j++] = Convert.ToUInt64(number);
                    i++;
                }

                for (int row = size - 1; row >= 0; row--)
                {
                    for (int column = size - 1; column >= 0; column--)
                    {
                        if (column == size - 1 && row == size - 1) continue;
                        ulong sum1 = matrix[row, column] + (row == size - 1 ? 1000000000 : matrix[row + 1, column]);
                        ulong sum2 = matrix[row, column] + (column == size - 1 ? 1000000000 : matrix[row, column + 1]);
                        matrix[row, column] = Math.Min(sum1, sum2);// sum1 < sum2 ? sum1 : sum2;
                    }
                }
                return matrix[0, 0];
            }
        }
    }
}
