using System.Globalization;

namespace ProjectEuler
{
    public class Problem40
    {
        public ulong Solve()
        {
            //int limit = 1000000;
            //StringBuilder s = new StringBuilder();
            //int n = 1;
            //while (true) {
            //    s.Append(n);
            //    if (s.Length >= limit)
            //        break;
            //    n++;
            //}
            //int[] positions = { 0, 9, 99, 999, 9999, 99999, 999999 };
            //int product = 1;
            //foreach (int position in positions)
            //    product *= ToInt32(s[position]);
            //return product;

            const int limit = 1000000;
            int[] positions = { 1, 10, 100, 1000, 10000, 100000, 1000000 };
            ulong product = 1;
            int currentPos = 1;
            int positionsIndex = 0;
            int n = 1;
            while (true)
            {
                string s = n.ToString(CultureInfo.InvariantCulture);
                int nextPos = currentPos + s.Length;
                if (nextPos >= limit)
                    break;
                // position we are looking for is between current and next, extract digit
                if (positions[positionsIndex] >= currentPos && positions[positionsIndex] < nextPos)
                {
                    int diff = positions[positionsIndex] - currentPos;
                    ulong digitAtPosition = Tools.ToUInt64(s[diff]);
                    product *= digitAtPosition;
                    positionsIndex++;
                }
                currentPos = nextPos;
                n++;
            }
            return product;
        }
    }
}
