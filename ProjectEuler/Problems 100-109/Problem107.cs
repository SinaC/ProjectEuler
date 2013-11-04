using System;

namespace ProjectEuler
{
    public class Problem107
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                const int size = 40;
                ulong[,] matrix = new ulong[size, size];
                int r = 0;
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    string[] numbers = s.Split(',');
                    int c = 0;
                    foreach (string number in numbers)
                    {
                        if (0 == String.Compare(number, "-", StringComparison.Ordinal))
                            matrix[r, c] = 0;
                        else
                            matrix[r, c] = Convert.ToUInt64(number);
                        c++;
                    }
                    r++;
                }

                // Count total distance
                ulong total = 0;
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < i; j++)
                        total += matrix[i, j];

                // Prim
                bool[] inTree = new bool[size];
                ulong[] d = new ulong[size];
                //int[] whoTo = new int[size];

                // Init
                for (int i = 0; i < size; i++)
                {
                    d[i] = ulong.MaxValue; // Initialize with Infinity
                    inTree[i] = false; // Not in spanning tree
                    //whoTo[i] = -1;
                }
                // Add first node to the tree
                inTree[0] = true;
                UpdateDistances(size, matrix, d, 0);

                // Algo
                ulong totalOptimized = 0;
                for (int treeSize = 1; treeSize < size; treeSize++)
                {
                    // Find the node with the smallest distance to the tree
                    int min = -1;
                    for (int i = 0; i < size; i++)
                        if (!inTree[i])
                            if (min == -1 || d[min] > d[i])
                                min = i;
                    // Add it
                    inTree[min] = true;
                    totalOptimized += d[min];

                    // Update
                    UpdateDistances(size, matrix, d, min);
                }

                return total - totalOptimized;
            }
        }

        private void UpdateDistances(int size, ulong[,] matrix, ulong[] d/*, int[] whoTo*/, int target)
        {
            for (int i = 0; i < size; ++i)
                if ((matrix[target, i] != 0) && (d[i] > matrix[target, i]))
                {
                    d[i] = matrix[target, i];
                    /*whoTo[i] = target;*/
                }

        }
    }
}
