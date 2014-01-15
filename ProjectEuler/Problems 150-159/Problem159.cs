using System;
using System.Linq;

namespace ProjectEuler
{
    public class Problem159
    {
        public ulong Solve()
        {
            const ulong limit = 1000000;
            ulong[] array = new ulong[limit];
            ulong sum = 0;
            for (ulong i = 2; i < limit; i++)
                array[i] = ((i - 1)%9) + 1;
            for (ulong j = 2; j < limit; j++)
            {
                ulong drsj = array[j];
                for (ulong k = 2, n = j + j; k <= j && n < limit; k++, n += j)
                    array[n] = Math.Max(array[n], drsj + array[k]);
                sum += drsj;
            }
            return sum;
        }

        public ulong Solve2()
        {
            const ulong limit = 1000000;
            //const ulong limit = 25;

            ulong[] primes = Primes.SoE.Primes(limit).ToArray();
            ulong[] array = new ulong[limit];

            for (ulong i = 2; i < limit; i++)
                CalculateMDRS(primes, array, i);

            return array.Aggregate((ulong) 0, (n, i) => n + i);
        }

        private static void CalculateMDRS(ulong[] primes, ulong[] array, ulong n)
        {
            ulong max = Tools.GetDigitalRoot(n);

            if (primes.Contains(n))
            {
                array[n] = max;
                return;
            }

            for (ulong i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i != 0)
                    continue;

                if (array[i] + array[n / i] > max)
                    max = array[i] + array[n / i];
            }

            array[n] = max;
        }
    }
}
