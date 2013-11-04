namespace ProjectEuler
{
    public class Problem164
    {
        public ulong Solve()
        {
            const ulong limit = 9;
            const ulong numDigits = 20;
            ulong[, ,] count = new ulong[10, 10, numDigits];
            ulong result = 0;
            for (ulong i = 1; i <= 9; i++)
                result += GetCount(limit, count, 0, i, numDigits - 1);
            return result;
        }

        private ulong GetCount(ulong limit, ulong[, ,] count, ulong d1, ulong d2, ulong remainDigits)
        {
            if (remainDigits == 0)
                return 1;
            else
            {
                if (count[d1, d2, remainDigits] == 0)
                    for (ulong i = 0; i <= limit - (d1 + d2); i++)
                        count[d1, d2, remainDigits] += GetCount(limit, count, d2, i, remainDigits - 1);
                return count[d1, d2, remainDigits];
            }
        }
    }
}
