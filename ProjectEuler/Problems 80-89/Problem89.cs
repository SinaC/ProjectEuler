namespace ProjectEuler
{
    public class Problem89
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                ulong count = 0;
                ulong compressedCount = 0;
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    count += (ulong)s.Length;
                    string t = s.Replace("VIIII", "IX").Replace("IIII", "IV").Replace("LXXXX", "XC").Replace("XXXX", "XL").Replace("DCCCC", "CM").Replace("CCCC", "CD");
                    compressedCount += (ulong)t.Length;
                }
                return count - compressedCount;
            }
        }
    }
}
