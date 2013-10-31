using System;

namespace ProjectEuler
{
    public class Problem99
    {
        public ulong Solve(string path)
        {
            // a^b > c^d  <==> b*ln(a) > d*ln(c) with a, b, c, d > 1
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                int lineNumber = 1;
                double bestPower = 1;
                int bestLineNumber = 1;
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    string[] tokens = s.Split(',');
                    ulong b = Convert.ToUInt64(tokens[0]);
                    ulong e = Convert.ToUInt64(tokens[1]);
                    double power = e * Math.Log(b);
                    if (power > bestPower)
                    {
                        bestPower = power;
                        bestLineNumber = lineNumber;
                    }
                    lineNumber++;
                }
                return (ulong)bestLineNumber;
            }
        }
    }
}
