using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem81 : ProblemBase
    {
        public Problem81()
            : base(81)
        {
        }

        public override string Solve()
        {
            const int size = 80;
            ulong[,] matrix = new ulong[size,size];
            int i = 0;
            foreach (string line in Lines.Where(line => !String.IsNullOrWhiteSpace(line)))
            {
                string[] numbers = line.Split(',');
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
                    matrix[row, column] = Math.Min(sum1, sum2); // sum1 < sum2 ? sum1 : sum2;
                }
            }
            return matrix[0, 0].ToString(CultureInfo.InvariantCulture);
        }
    }
}
