using System;
using System.Linq;
using System.Globalization;

namespace ProjectEuler
{
    public sealed class Problem11 : Problem
    {
        public Problem11()
            : base(11)
        {
        }

        public override string Solve()
        {
            ulong[,] matrix = new ulong[20, 20];
            string[] lines = Data.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < numbers.Length; j++)
                    matrix[i, j] = Convert.ToUInt64(numbers[j]);
            }
            //ulong[,] matrix = Data.Split('\n').Select(x => x.Split(' ').Select(y => Convert.ToUInt64(y)).ToArray()).ToArray();

            ulong bestProduct = 0;
            for (int r = 0; r < 20; r++)
                for (int c = 0; c < 20; c++)
                {
                    ulong product;
                    if (c < 17)
                    {
                        // Right and "Left"
                        product = matrix[r, c]*matrix[r, c + 1]*matrix[r, c + 2]*matrix[r, c + 3];
                        if (bestProduct < product)
                            bestProduct = product;
                    }

                    if (r < 17)
                    {
                        // Down and "Up"
                        product = matrix[r, c]*matrix[r + 1, c]*matrix[r + 2, c]*matrix[r + 3, c];
                        if (bestProduct < product)
                            bestProduct = product;

                        // Diagonally, down to the right
                        if (c < 17)
                        {
                            product = matrix[r, c]*matrix[r + 1, c + 1]*matrix[r + 2, c + 2]*matrix[r + 3, c + 3];
                            if (bestProduct < product)
                                bestProduct = product;
                        }

                        // Diagonally, down to the left
                        if (c > 3)
                        {
                            product = matrix[r, c]*matrix[r + 1, c - 1]*matrix[r + 2, c - 2]*matrix[r + 3, c - 3];
                            if (bestProduct < product)
                                bestProduct = product;
                        }
                    }
                }
            return bestProduct.ToString(CultureInfo.InvariantCulture);
        }
    }
}