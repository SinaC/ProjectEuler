using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem203 : ProblemBase
    {
        public Problem203() : base(203)
        {
        }

        public override string Solve()
        {
            // Triangle[i,j] = Triangle[i-1,j-1] + Triangle[i,j-1]
            // Check for each distinct coefficient if it's divisible by any square of prime between 2^2 and 7^2 (highest square below 51)
            const int limit = 51;
            ulong[] primes = { 2, 3, 5, 7 };
            ulong[] line = { 1, 2, 1 }; // 3rd line of pascal triangle
            Dictionary<ulong, ulong> dict = new Dictionary<ulong, ulong>();
            while (line.Length <= limit)
            {
                // Get distinct coefficient
                foreach (ulong t in line)
                    if (!dict.ContainsKey(t))
                        dict.Add(t, t);
                // Compute next triangle line
                ulong[] newLine = new ulong[line.Length + 1];
                newLine[0] = 1;
                newLine[newLine.Length - 1] = 1;
                for (int i = 1; i < line.Length; i++)
                    newLine[i] = line[i - 1] + line[i];
                line = newLine;
            }
            // Sum square-free distinct coefficient
            //ulong sum = 0;
            //foreach (KeyValuePair<ulong, ulong> kv in dict)
            //{
            //    bool fOk = true;
            //    foreach (ulong prime in primes)
            //    {
            //        ulong squaredPrime = prime * prime;
            //        if (squaredPrime <= kv.Key && 0 == (kv.Key % squaredPrime))
            //        {
            //            fOk = false;
            //            break;
            //        }
            //    }
            //    if (fOk)
            //        sum += kv.Key;
            //}
            //return sum;
            ulong sum = 0;
            foreach (KeyValuePair<ulong, ulong> kv in dict)
            {
                bool fOk = primes.Select(prime => prime*prime).All(squaredPrime => squaredPrime > kv.Key || 0 != (kv.Key%squaredPrime));
                if (fOk)
                    sum += kv.Key;
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
