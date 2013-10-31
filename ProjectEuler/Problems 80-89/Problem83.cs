using System;

namespace ProjectEuler
{
    public class Problem83
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

                // TODO: Inefficient Dijkstra, should use a priority queue instead of find a nearest by looping in the matrix
                // Int64.MaxValue -> future
                // < 0 -> past
                // > 0 -> present
                long[,] dijkstra = new long[size, size];
                for (int r = 0; r < size; r++)
                    for (int c = 0; c < size; c++)
                        dijkstra[r, c] = Int64.MaxValue;

                dijkstra[0, 0] = (long)matrix[0, 0];
                while (true)
                {
                    // Search for min value and if every node has been visited
                    int minR = 0;
                    int minC = 0;
                    long min = Int64.MaxValue;
                    bool done = true;
                    for (int r = 0; r < size; r++)
                        for (int c = 0; c < size; c++)
                        {
                            if (dijkstra[r, c] > 0)
                                done = false;
                            if (dijkstra[r, c] > 0 && dijkstra[r, c] < min)
                            {
                                min = dijkstra[r, c];
                                minR = r;
                                minC = c;
                            }
                        }
                    if (done)
                        break;
                    dijkstra[minR, minC] = -dijkstra[minR, minC]; // move to the past
                    for (int h = -1; h <= 1; h++)
                        for (int v = -1; v <= 1; v++)
                        {
                            if (h == 0 && v == 0) continue; // not ourself
                            if (h != 0 && v != 0) continue; // not in diagonal
                            int newR = minR + h;
                            int newC = minC + v;
                            if (newR < 0 || newR >= size || newC < 0 || newC >= size) continue; // out of matrix
                            long dist = Math.Abs(dijkstra[minR, minC]) + Math.Abs((long)matrix[newR, newC]);
                            if (dist < Math.Abs(dijkstra[newR, newC]))
                                dijkstra[newR, newC] = dist; // move to present
                        }
                }

                return (ulong)(-dijkstra[size - 1, size - 1]);
            }
        }
    }
}
