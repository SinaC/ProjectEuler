using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem87 : ProblemBase
    {
        public Problem87() : base(87)
        {
        }

        public override string Solve()
        {
            const ulong limit = 50000000;
            const ulong sieveLimit = 10000;
            bool[] sieve = Tools.Tools.BuildSieve(sieveLimit);
            Dictionary<ulong, bool> answer = new Dictionary<ulong, bool>();
            ulong count = 0;
            for (ulong i = 2; i < sieveLimit; i++)
            {
                if (sieve[i]) continue; // not a prime
                ulong ii = i * i; // square
                if (ii >= limit) continue; // not a prime
                for (ulong j = 2; j < sieveLimit; j++)
                {
                    if (sieve[j]) continue; // not a prime
                    ulong jjj = j * j * j; // cube
                    if (ii + jjj >= limit) continue;
                    for (ulong k = 2; k < sieveLimit; k++)
                    {
                        if (sieve[k]) continue; // not a prime
                        ulong kkkk = k * k * k * k; // fourth power
                        ulong sum = ii + jjj + kkkk;
                        if (sum >= limit) continue;
                        if (answer.ContainsKey(sum)) continue; // already found
                        answer.Add(sum, true);
                        count++;
                    }
                }
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
