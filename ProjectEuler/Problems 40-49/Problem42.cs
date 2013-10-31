using System;
using System.Linq;

namespace ProjectEuler
{
    public class Problem42
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string s = reader.ReadToEnd();
                string[] words = s.Split(',');
                ulong count = 0;
                foreach (string word in words)
                {
                    ulong value = word.Where(char.IsLetter).Aggregate<char, ulong>(0, (current, c) => current + (Convert.ToUInt64(c) - 64));
                    if (Tools.IsTriangle(value))
                        count++;
                }
                return count;
            }
        }
    }
}
