using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using Tools;

namespace Primes
{
    public class Check
    {
        private static readonly Random _random = new Random();

        //public static bool IsPrime(ulong number)
        //{
        //    bool returnValue = true;

        //    if (number < 2 || (number > 2 && (number % 2 == 0)) || (number > 2 && (number & (number - 1)) == 0))
        //        returnValue = false;
        //    else
        //        for (ulong i = 2; i * i <= number; i++)
        //            if (number % i == 0)
        //                returnValue = false;

        //    return returnValue;
        //}

        public static bool IsPrime(ulong n)
        {
            if (n <= 1) return false; // 0, 1
            if (n < 4) return true; // 2, 3
            if (0 == (n & 1)) return false; // even
            if (n < 9) return true; // 0, 1, 4, 6, 8 already rejected
            if (0 == (n%3)) return false; // multiple of 3
            ulong sqrtN = (ulong) Math.Sqrt(n);
            ulong divisor = 5;
            while (divisor <= sqrtN)
            {
                if (0 == (n%divisor)) return false;
                if (0 == (n%(divisor + 2))) return false;
                divisor += 6;
            }
            return true;
        }
        
        public static bool IsPrimeMillerRabin(ulong n, int levels = 5)
        {
            if (n < 2)
                return false;
            if (n%2 == 0)
                return false;
            ulong s = 0;
            ulong d = n - 1;
            while ((d%2) == 0)
            {
                s = s + 1;
                d = d/2;
            }
            foreach (int z in Enumerable.Range(0, levels))
            {
                ulong a = _random.NextULong(2, n - 2);
                ulong x = Tools.Tools.PowModulo(a, d, n);
                if (x == 1 || x == n - 1)
                    continue;
                for (ulong y = 0; y < s; y++)
                {
                    x = Tools.Tools.PowModulo(x, 2, n);
                    if (x == 1)
                        return false;
                    if (x == n - 1)
                        break;
                }
                if (x == n - 1)
                    continue;
                return false;
            }
            return true;
        }

        //http://rosettacode.org/wiki/Miller-Rabin_primality_test#C.23
        public static bool IsPrimeMillerRabin(BigInteger source, int certainty = 5)
        {
            if (source == 2 || source == 3)
                return true;
            if (source < 2 || source % 2 == 0)
                return false;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            // There is no built-in method for generating random BigInteger values.
            // Instead, random BigIntegers are constructed from randomly generated
            // byte arrays of the same length as the source.
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    // This may raise an exception in Mono 2.10.8 and earlier.
                    // http://bugzilla.xamarin.com/show_bug.cgi?id=2761
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= source - 2);

                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                        return false;
                    if (x == source - 1)
                        break;
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }
    }
}
