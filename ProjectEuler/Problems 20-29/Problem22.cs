using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem22
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string fileContent = reader.ReadToEnd();
                List<string> names = new List<string>(fileContent.Split(','));
                names.Sort();
                ulong sum = 0;
                for (int i = 0; i < names.Count; i++)
                {
                    ulong nameValue = names[i].Where(c => c != '"').Aggregate<char, ulong>(0, (current, c) => current + (Convert.ToUInt64(c) - 64));
                    sum += nameValue * ((ulong)i + 1);
                }
                return sum;
            }
        }
    }
}
