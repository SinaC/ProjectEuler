using System.Globalization;

namespace ProjectEuler
{
    public class Problem95 : ProblemBase
    {
        public Problem95() : base(95)
        {
        }

        public override string Solve()
        {
            //ulong limit = 1000000;
            //ulong longestLength = 0;
            //ulong smallestOfLongestLength = 0;
            //ulong[] chain = new ulong[limit];
            //for (int idx = 0; idx < chain.Length; idx++)
            //    chain[idx] = 0;
            //ulong i = 10;
            //while (true) {
            //    if (i >= limit)
            //        break;
            //    bool fChain = false;
            //    ulong chainLength = 0;
            //    ulong smallest = i;
            //    if (0 == chain[i]) {
            //        // Build list of sum of proper divisors
            //        bool fTooBig = false;
            //        List<ulong> list = new List<ulong>();
            //        ulong n = i;
            //        while (true) {
            //            chainLength++;
            //            ulong nPrevious = n;
            //            list.Add(n);
            //            n = SumOfProperDivisors(n);
            //            if (n >= limit) {
            //                fTooBig = true;
            //                break;
            //            }
            //            if (n < smallest)
            //                smallest = n;
            //            if (n == i) { // stops if a circular chain is found
            //                fChain = true;
            //                break;
            //            }
            //            if (1 == n) // stops when a prime number is found
            //                break;
            //            if (list.Contains(n)) // stops if number already found in this loop
            //                break;
            //        }
            //        if (!fTooBig) {
            //            for (int idx = 0; idx < list.Count - 1; idx++) {
            //                int next = (idx + 1) % list.Count;
            //                chain[list[idx]] = list[next];
            //            }
            //            chain[list[list.Count - 1]] = n;
            //        }
            //    }
            //    else {
            //        // Number already found, check if circular chain
            //        ulong index = i;
            //        smallest = i;
            //        List<ulong> list = new List<ulong>();
            //        while (true) {
            //            list.Add(index);
            //            chainLength++;
            //            if (index < smallest)
            //                smallest = index;
            //            ulong previousIndex = index;
            //            index = chain[index];
            //            if (index == i) { // true cycle
            //                fChain = true;
            //                break;
            //            }
            //            if (list.Contains(index)) { // false cycle
            //                fChain = false;
            //                break;
            //            }
            //            if (index == 1) { // chain ended by a prime number
            //                fChain = false;
            //                break;
            //            }
            //        }
            //    }
            //    if (fChain) { // circular chain
            //        //if ((ulong)list.Count > longestLength) {
            //        //    longestLength = (ulong)list.Count;
            //        //    ulong smallest = ulong.MaxValue;
            //        //    foreach (ulong item in list)
            //        //        if (item < smallest)
            //        //            smallest = item;
            //        //    smallestOfLongestLength = smallest;
            //        //}
            //        if (chainLength > longestLength) {
            //            longestLength = chainLength;
            //            smallestOfLongestLength = smallest;
            //        }
            //    }
            //    i++;
            //}
            //return smallestOfLongestLength;
            const ulong limit = 1000000;
            ulong[] divisorsSum = new ulong[limit];
            // Modified sieve
            for (ulong i = 0; i < limit; i++)
                divisorsSum[i] = 1;
            for (ulong factor = 2; factor < limit / 2; factor++)
                for (ulong mult = 2; factor * mult < limit; mult++)
                    divisorsSum[factor * mult] += factor;
            // Build chains
            ulong[] chain = new ulong[limit];
            for (ulong i = 0; i < limit; i++)
                chain[i] = 0;
            //ulong index = 0;
            ulong longest = 0;
            ulong smallestOfLongestLength = 0;
            for (ulong i = 2; i < limit; i++)
            {
                ulong smallest, length;
                bool fCheckChain = CheckChain(limit, divisorsSum, chain, i, out smallest, out length);
                if (fCheckChain && length > longest)
                {
                    longest = length;
                    //index = i;
                    smallestOfLongestLength = smallest;
                }
            }
            return smallestOfLongestLength.ToString(CultureInfo.InvariantCulture);
        }

        private static bool CheckChain(ulong limit, ulong[] divisorsSum, ulong[] chain, ulong n, out ulong smallest, out ulong length)
        {
            ulong i = n;
            length = 1;
            smallest = limit;
            chain[n] = n;
            while (true)
            {
                i = divisorsSum[i];
                smallest = (smallest > i) ? i : smallest;
                if (i > limit) 
                    return false;
                if (chain[i] == n)
                {
                    if (i == n) 
                        return true;
                    return false;
                }
                chain[i] = n;
                length++;
            }
        }
    }
}
