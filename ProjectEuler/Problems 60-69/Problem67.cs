using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem67
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                List<List<ulong>> triangle = new List<List<ulong>>();
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    string[] numbers = s.Split(' ');
                    List<ulong> list = numbers.Select(number => Convert.ToUInt64(number)).ToList();
                    triangle.Add(list);
                }

                // Bottom-up approach, each number n at index i in line l is replaced by max( n+nl[i], n+nl[i+1] ) with nl = next line
                for (int l = triangle.Count - 2; l >= 0; l--)
                {
                    List<ulong> nextLine = triangle[l + 1];
                    List<ulong> line = triangle[l];
                    for (int i = 0; i < line.Count; i++)
                    {
                        ulong sum1 = line[i] + nextLine[i];
                        ulong sum2 = line[i] + nextLine[i + 1];
                        line[i] = Math.Max(sum1, sum2);//sum1 > sum2 ? sum1 : sum2;
                    }
                }
                return triangle[0][0];
            }
        }
    }
}
