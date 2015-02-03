using System.Globalization;

namespace ProjectEuler
{
    public class Problem113 : ProblemBase
    {
        public Problem113() : base(113)
        {
        }

        public override string Solve()
        {
            const int numOfDigits = 100; // 10^100 (a gogol) has 100 digits
            ulong[,] incCount = new ulong[10, numOfDigits + 1]; // 2nd index 0 not used
            ulong[,] decCount = new ulong[10, numOfDigits + 1]; // 2nd index 0 not used
            ulong count = 0;
            for (int i = 1; i <= numOfDigits; i++)
                count += IncNum(incCount, 1, i) + DecNum(decCount, 9, i) - 10;
            return count.ToString(CultureInfo.InvariantCulture);
        }

        private static ulong IncNum(ulong[,] incCount, int leftDigit, int numOfDigits)
        {
            if (0 == incCount[leftDigit, numOfDigits])
                if (1 == numOfDigits)
                    incCount[leftDigit, numOfDigits] = (ulong)(10 - leftDigit);
                else
                    for (int i = leftDigit; i < 10; i++)
                        incCount[leftDigit, numOfDigits] += IncNum(incCount, i, numOfDigits - 1);
            return incCount[leftDigit, numOfDigits];
        }

        private static ulong DecNum(ulong[,] decCount, int leftDigit, int numOfDigits)
        {
            if (0 == decCount[leftDigit, numOfDigits])
                if (1 == numOfDigits)
                    decCount[leftDigit, numOfDigits] = (ulong)(leftDigit + 1);
                else
                    for (int i = leftDigit; i >= 0; i--)
                        decCount[leftDigit, numOfDigits] += DecNum(decCount, i, numOfDigits - 1);
            return decCount[leftDigit, numOfDigits];
        }
    }
}
