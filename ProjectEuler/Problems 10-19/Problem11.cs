using System;

namespace ProjectEuler
{
    public class Problem11
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                ulong[,] matrix = new ulong[20, 20];
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    string[] numbers = s.Split(' ');
                    int j = 0;
                    foreach (string number in numbers)
                        matrix[i, j++] = Convert.ToUInt64(number);
                    i++;
                }

                ulong bestProduct = 0;
                for (int r = 0; r < 20; r++)
                    for (int c = 0; c < 20; c++)
                    {
                        ulong product;
                        if (c < 17)
                        {
                            // Right and "Left"
                            product = matrix[r, c] * matrix[r, c + 1] * matrix[r, c + 2] * matrix[r, c + 3];
                            if (bestProduct < product)
                                bestProduct = product;
                        }

                        if (r < 17)
                        {
                            // Down and "Up"
                            product = matrix[r, c] * matrix[r + 1, c] * matrix[r + 2, c] * matrix[r + 3, c];
                            if (bestProduct < product)
                                bestProduct = product;

                            // Diagonally, down to the right
                            if (c < 17)
                            {
                                product = matrix[r, c] * matrix[r + 1, c + 1] * matrix[r + 2, c + 2] * matrix[r + 3, c + 3];
                                if (bestProduct < product)
                                    bestProduct = product;
                            }

                            // Diagonally, down to the left
                            if (c > 3)
                            {
                                product = matrix[r, c] * matrix[r + 1, c - 1] * matrix[r + 2, c - 2] * matrix[r + 3, c - 3];
                                if (bestProduct < product)
                                    bestProduct = product;
                            }
                        }
                    }
                return bestProduct;
            }
        }
    }
}
