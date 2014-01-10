using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem200
    {
        [UnderConstruction]
        public ulong Solve()
        {
            char[] odd =
                {
                    '1', '3', '5', '7', '9'
                };
            List<ulong> primeProof200 = new List<ulong>();
            const uint limit = 10000;
            bool[] sieve = Tools.BuildSieve(limit);
            Parallel.For(0, limit + 1, sp =>
                {
                    ulong p = (ulong)sp;
                    if (!sieve[p])
                        for (ulong q = 0; q <= limit; q++)
                            if (q != p && !sieve[q])
                            {
                                //p^2 * q^3
                                ulong sqube = p*p*q*q*q;

                                // Contains 200
                                string s = sqube.ToString(CultureInfo.InvariantCulture);
                                if (s.Contains("200"))
                                {
                                    int lastIndex = s.Length - 1;
                                    char[] sAsArray = s.ToCharArray();
                                    char last = s[lastIndex];
                                    // Modify only last digit if ends with 0, 2, 4, 5, 6, 8
                                    if (last == '0' || last == '2' || last == '4' || last == '5' || last == '6' || last == '8')
                                    {
                                        bool primeProof = true;
                                        foreach (char c in odd)
                                        {
                                            sAsArray[lastIndex] = c;
                                            string toCheckAsString = new string(sAsArray);
                                            ulong toCheck = ulong.Parse(toCheckAsString);
                                            if (Primes.Check.IsPrime(toCheck))
                                            {
                                                primeProof = false;
                                                break;
                                            }
                                        }
                                        if (primeProof)
                                            primeProof200.Add(sqube);
                                    }
                                }
                            }
                });
            primeProof200.Sort();
            return 0;
        }
    }
}
