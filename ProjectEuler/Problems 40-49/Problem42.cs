using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem42 : ProblemBase
    {
        public Problem42() : base(42)
        {
        }

        public override string Solve()
        {
            string[] words = Data.Split(',');
            ulong count = 0;
            foreach (string word in words)
            {
                ulong value = word.Where(char.IsLetter).Aggregate<char, ulong>(0, (current, c) => current + (Convert.ToUInt64(c) - 64));
                if (Tools.Tools.IsTriangle(value))
                    count++;
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
