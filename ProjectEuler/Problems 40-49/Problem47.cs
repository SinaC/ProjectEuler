using System.Globalization;

namespace ProjectEuler
{
    public class Problem47 : ProblemBase
    {
        public Problem47() : base(47)
        {
        }

        public override string Solve()
        {
            const ulong factorCountLimit = 4;
            const ulong consecutiveCountLimit = 4;
            const ulong limit = 500 * 1000;
            const ulong sieveLimit = 1000;
            ulong result = 0;
            ulong count = 0;
            bool fFound = false;
            bool[] sieve = Tools.Tools.BuildSieve(sieveLimit);
            for (ulong i = 10; i <= limit; i++)
            {
                ulong n = i;
                ulong factor = 2;
                ulong factorCount = 0;
                while (true)
                {
                    ulong occurence = 0;
                    while (0 == (n % factor))
                    { // Count factor occurence
                        occurence++;
                        n /= factor;
                    }
                    if (occurence > 0)
                        factorCount++;
                    if (factorCount > factorCountLimit)
                        break; // No need of more than 4 factors
                    if (n == 1) // No more factoring
                        break;
                    bool fStop = false;
                    while (true)
                    { // Get next prime
                        factor++;
                        if (factor > sieveLimit)
                        {
                            fStop = true;
                            break;
                        }
                        if (!sieve[factor])
                            break;
                    }
                    if (fStop)
                        break;
                }
                if (factorCountLimit == factorCount)
                {
                    if (0 == count)
                    {
                        result = i;
                        count = 1;
                    }
                    else if (result + 1 == i)
                    {
                        result = i;
                        count++;
                    }
                    if (consecutiveCountLimit == count)
                    {
                        fFound = true;
                        break;
                    }
                }
                else
                    count = 0;
            }
            return (fFound ? result - consecutiveCountLimit + 1 : 0).ToString(CultureInfo.InvariantCulture);
        }
    }
}
