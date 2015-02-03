using System.Globalization;

namespace ProjectEuler
{
    public class Problem89 : ProblemBase
    {
        public Problem89() : base(89)
        {
        }

        public override string Solve()
        {
            ulong count = 0;
            ulong compressedCount = 0;
            foreach(string line in Lines)
            {
                count += (ulong)line.Length;
                string t = line.Replace("VIIII", "IX").Replace("IIII", "IV").Replace("LXXXX", "XC").Replace("XXXX", "XL").Replace("DCCCC", "CM").Replace("CCCC", "CD");
                compressedCount += (ulong)t.Length;
            }
            return (count - compressedCount).ToString(CultureInfo.InvariantCulture);
        }
    }
}
