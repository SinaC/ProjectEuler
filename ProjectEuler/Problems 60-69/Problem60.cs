using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem60
    {
        public ulong Solve()
        {
            // Brute-force
            const ulong sieveLimit = 100000000;
            bool[] sieve = Tools.BuildSieve(sieveLimit); // slowest step
            ulong[] limits = { 9999, 9999, 9999, 9999, 9999 }; // arbitrary limit
            ulong[] p = new ulong[5];
            for (p[0] = 3; p[0] <= limits[0]; p[0] += 2)
            { // 2 will never be concatenable to give another prime
                if (sieve[p[0]])
                    continue;
                for (p[1] = p[0] + 2; p[1] <= limits[1]; p[1] += 2)
                {
                    if (sieve[p[1]])
                        continue;
                    ulong index = 1;
                    bool fContinue = false;
                    ulong concat;
                    for (ulong i = 0; i < index; i++)
                    {
                        concat = Convert.ToUInt64(p[index].ToString(CultureInfo.InvariantCulture) + p[i].ToString(CultureInfo.InvariantCulture));
                        if (sieve[concat])
                        {
                            fContinue = true;
                            break;
                        }
                        concat = Convert.ToUInt64(p[i].ToString(CultureInfo.InvariantCulture) + p[index].ToString(CultureInfo.InvariantCulture));
                        if (sieve[concat])
                        {
                            fContinue = true;
                            break;
                        }
                    }
                    if (fContinue)
                        continue;
                    for (p[2] = p[1] + 2; p[2] <= limits[2]; p[2] += 2)
                    {
                        if (sieve[p[2]])
                            continue;
                        index = 2;
                        fContinue = false;
                        for (ulong i = 0; i < index; i++)
                        {
                            concat = Convert.ToUInt64(p[index].ToString(CultureInfo.InvariantCulture) + p[i].ToString(CultureInfo.InvariantCulture));
                            if (sieve[concat])
                            {
                                fContinue = true;
                                break;
                            }
                            concat = Convert.ToUInt64(p[i].ToString(CultureInfo.InvariantCulture) + p[index].ToString(CultureInfo.InvariantCulture));
                            if (sieve[concat])
                            {
                                fContinue = true;
                                break;
                            }

                        }
                        if (fContinue)
                            continue;
                        for (p[3] = p[2] + 2; p[3] <= limits[3]; p[3] += 2)
                        {
                            if (sieve[p[3]])
                                continue;
                            index = 3;
                            fContinue = false;
                            for (ulong i = 0; i < index; i++)
                            {
                                concat = Convert.ToUInt64(p[index].ToString(CultureInfo.InvariantCulture) + p[i].ToString(CultureInfo.InvariantCulture));
                                if (sieve[concat])
                                {
                                    fContinue = true;
                                    break;
                                }
                                concat = Convert.ToUInt64(p[i].ToString(CultureInfo.InvariantCulture) + p[index].ToString(CultureInfo.InvariantCulture));
                                if (sieve[concat])
                                {
                                    fContinue = true;
                                    break;
                                }

                            }
                            if (fContinue)
                                continue;
                            for (p[4] = p[3] + 2; p[4] <= limits[4]; p[4] += 2)
                            {
                                if (sieve[p[4]])
                                    continue;
                                index = 4;
                                fContinue = false;
                                for (ulong i = 0; i < index; i++)
                                {
                                    concat = Convert.ToUInt64(p[index].ToString(CultureInfo.InvariantCulture) + p[i].ToString(CultureInfo.InvariantCulture));
                                    if (sieve[concat])
                                    {
                                        fContinue = true;
                                        break;
                                    }
                                    concat = Convert.ToUInt64(p[i].ToString(CultureInfo.InvariantCulture) + p[index].ToString(CultureInfo.InvariantCulture));
                                    if (sieve[concat])
                                    {
                                        fContinue = true;
                                        break;
                                    }

                                }
                                if (fContinue)
                                    continue;
                                // We have found the 5 numbers
                                ulong sum = 0;
                                for (int i = 0; i < 5; i++)
                                    sum += p[i];
                                return sum;
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
