using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Tools
    {
        public const double Epsilon = 0.00001;
        public static readonly ulong[] Factorials10 = { 1 /*0*/, 1 /*1*/, 2 /*2*/, 6 /*3*/, 24 /*4*/, 120 /*5*/, 720 /*6*/, 5040 /*7*/, 40320 /*8*/, 362880 /*9*/, 3628800 /*10*/};
        public static readonly ulong[] Primes10 = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

        public static ulong ToUInt64(char c)
        {
            return Convert.ToUInt64(c) - 48;
        }

        public static long ToInt64(char c)
        {
            return Convert.ToInt64(c) - 48;
        }

        public static uint ToUInt32(char c)
        {
            return Convert.ToUInt32(c) - 48;
        }

        public static int ToInt32(char c)
        {
            return Convert.ToInt32(c) - 48;
        }

        public static bool[] BuildSieve(ulong limit)
        {
            bool[] numbers = new bool[limit + 1];
            ulong sqrtLimit = (ulong)Math.Sqrt(limit);
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = false; // prime by default
            for (ulong i = 4; i <= limit; i += 2) // mark even number
                numbers[i] = true;
            for (ulong i = 3; i <= sqrtLimit; i += 2)
            {
                if (!numbers[i])
                    for (ulong j = i * i; j <= limit; j += 2 * i)
                        numbers[j] = true;
            }
            numbers[0] = true; // not prime
            numbers[1] = true; // not prime
            return numbers;
        }

        public static ulong SumDigits(ulong number)
        {
            ulong sum = 0;
            while (number >= 1)
            {
                sum += number%10;
                number /= 10;
            }
            return sum;
        }

        public static ulong SumDigits(string number)
        {
            return number.Aggregate<char, ulong>(0, (current, c) => current + ToUInt64(c));
        }

        public static ulong Factorial(ulong number)
        {
            ulong fact = 1;
            for (ulong i = 2; i <= number; i++)
                fact *= i;
            return fact;
        }

        public static ulong PGCD(ulong a, ulong b)
        {
            ulong r;
            while (0 != (r = a%b))
            {
                a = b;
                b = r;
            }
            return b;
            //while (b != 0) {
            //    a %= b;
            //    if (a == 0)
            //        return b;
            //    b %= a;
            //}
            //return a;
        }

        public static bool IsPalindromic(ulong number, ulong baseToTest)
        {
            ulong num = number;
            ulong rev = 0;
            while (num > 0)
            {
                ulong dig = num%baseToTest;
                rev = rev*baseToTest + dig;
                num = num/baseToTest;
            }
            return number == rev;
        }

        public static bool IsPandigital(string s)
        {
            char limit = Convert.ToChar(s.Length + 48);
            for (char i = '1'; i <= limit; i++)
                if (-1 == s.IndexOf(i))
                    return false;
            return true;
        }

        public static bool IsPandigitalCharRange(string s, char lowerLimit, char higherLimit)
        {
            for (char i = lowerLimit; i <= higherLimit; i++)
                if (-1 == s.IndexOf(i))
                    return false;
            return true;
        }

        public static ulong SumOfDivisors(ulong n)
        {
            ulong prod = 1;
            for (ulong k = 2; k*k <= n; ++k)
            {
                ulong p = 1;
                while (n%k == 0)
                {
                    p = p*k + 1;
                    n /= k;
                }
                prod *= p;
            }
            if (n > 1)
                prod *= 1 + n;
            return prod;
        }

        public static ulong SumOfProperDivisors(ulong number)
        {
            return SumOfDivisors(number) - number;
        }

        public static string SumString(string a, string b)
        {
            if (a.Length < b.Length)
            {
                string swap = a;
                a = b;
                b = swap;
            }
            StringBuilder result = new StringBuilder(a.Length + 1);
            int carry = 0;
            int bIndex = b.Length - 1;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int digitA = ToInt32(a[i]);
                int digitB = (bIndex < 0) ? 0 : ToInt32(b[bIndex--]);
                int sum = digitA + digitB + carry;
                carry = (sum >= 10) ? 1 : 0;
                int digit = sum%10;
                result.Insert(0, digit);
            }
            if (0 != carry)
                result.Insert(0, '1');
            return result.ToString();
        }

        public static string SubString(string a, string b)
        {
            if (a.Length > b.Length)
                b = b.PadLeft(a.Length, '0');
            string complement = b.Aggregate("", (current, c) => current + (9 - ToInt32(c)));
            string sum = SumString(a, complement);
            sum = SumString(sum, "1");
            string difference = sum.Substring(1);
            while (difference[0] == '0')
                difference = difference.Substring(1);
            return difference;
        }

        public static ulong Triangle(ulong n)
        {
            return n*(n + 1)/2;
        }

        public static ulong Square(ulong n)
        {
            return n*n;
        }

        public static ulong Pentagonal(ulong n)
        {
            return n*(3*n - 1)/2;
        }

        public static ulong Hexagonal(ulong n)
        {
            return n*(2*n - 1);
        }

        public static ulong Heptagonal(ulong n)
        {
            return n*(5*n - 3)/2;
        }

        public static ulong Octogonal(ulong n)
        {
            return n*(3*n - 2);
        }

        public static double TriangleIndex(ulong number)
        {
            return (-1 + Math.Sqrt(8*number + 1))/2;
        }

        public static double SquareIndex(ulong number)
        {
            return Math.Sqrt(number);
        }

        public static double PentagonalIndex(ulong number)
        {
            return (1 + Math.Sqrt(24*number + 1))/6;
        }

        public static double HexagonalIndex(ulong number)
        {
            return (1 + Math.Sqrt(8*number + 1))/4;
        }

        public static double HeptagonalIndex(ulong number)
        {
            return (3 + Math.Sqrt(40*number + 9))/10;
        }

        public static double OctogonalIndex(ulong number)
        {
            return (2 + Math.Sqrt(12*number + 4))/6;
        }

        public static bool IsTriangle(ulong number)
        {
            double n = TriangleIndex(number);
            return Math.Abs(n - Math.Truncate(n)) < Epsilon;
        }

        public static bool IsSquare(ulong number)
        {
            double n = SquareIndex(number);
            return Math.Abs(n - Math.Truncate(n)) < Epsilon;
        }

        public static bool IsPentagonal(ulong number)
        {
            double n = PentagonalIndex(number);
            return Math.Abs(n - Math.Truncate(n)) < Epsilon;
        }

        public static bool IsHexagonal(ulong number)
        {
            double n = HexagonalIndex(number);
            return Math.Abs(n - Math.Truncate(n)) < Epsilon;
        }

        public static bool IsHeptagonal(ulong number)
        {
            double n = HeptagonalIndex(number);
            return Math.Abs(n - Math.Truncate(n)) < Epsilon;
        }

        public static bool IsOctogonal(ulong number)
        {
            double n = OctogonalIndex(number);
            return Math.Abs(n - Math.Truncate(n)) < Epsilon;
        }

        public static List<ulong> SqrtContinuedFraction(ulong n)
        {
            // sqrt(n) = [List[0];(List[1],List[2],...)]
            //http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/cfINTRO.html
            ulong sqrtN = (ulong) Math.Sqrt(n);
            List<ulong> result = new List<ulong>();
            ulong a = sqrtN;
            ulong p = 0;
            ulong q = 1;
            result.Add(a);
            while (true)
            {
                p = a*q - p;
                q = (n - p*p)/q;
                a = (p + sqrtN)/q;
                result.Add(a);
                if (q == 1)
                    break;
            }
            return result;
        }

        public static ulong Pow(ulong number, ulong exponent)
        {
            ulong result = 1;
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                    result *= number;
                number *= number;
                exponent >>= 1;
            }
            return result;
        }

        public static ulong PowModulo(ulong number, ulong exponent, ulong modulo)
        {
            ulong result = 1;
            for (ulong i = 0; i < exponent; i++)
                result = (result*number)%modulo;
            return result;
        }

        public static ulong FastPowModulo_BeCareful(ulong number, ulong exponent, ulong modulo)
        {
            // Doesn't work if (*) overflows 64 bits
            // when computing power of 2, result will be 0
            // otherwise, result is unpredictable
            ulong result = 1;
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                    result = (result*number)%modulo;
                number = (number*number)%modulo; // (*)
                exponent >>= 1;
            }
            return result;
        }

        public static void MulDigitsNumber(ulong[] digits, ref ulong digitsCount, ulong multiplier)
        {
            ulong carry = 0;
            for (ulong i = 0; i < digitsCount; i++)
            {
                carry += digits[i]*multiplier;
                digits[i] = carry%10;
                carry /= 10;
            }
            while (carry > 0)
            {
                digits[digitsCount++] = carry%10;
                carry /= 10;
            }
        }

        public static bool IsPermutation(ulong a, ulong b)
        {
            // TODO: optimize this
            string aStr = a.ToString(CultureInfo.InvariantCulture);
            string bStr = b.ToString(CultureInfo.InvariantCulture);
            if (aStr.Length != bStr.Length)
                return false;
            char[] aArray = aStr.ToCharArray();
            Array.Sort(aArray);
            char[] bArray = bStr.ToCharArray();
            Array.Sort(bArray);
            return !aArray.Where((t, i) => t != bArray[i]).Any();
        }

        //public static ulong Phi(bool[] sieve, ulong n) {
        //    if (!sieve[n])
        //        return n - 1;
        //    ulong limit = n / 2;
        //    ulong phiN = n;
        //    for (ulong j = 2; j <= limit; j++)
        //        if (!sieve[j] && (0 == (n % j)))
        //            phiN = (phiN * (j - 1)) / j;
        //    return phiN;
        //}

        //public static ulong Phi(bool[] sieve, ulong n) {
        //    if (!sieve[n])
        //        return n - 1;
        //    if (n == 1 || n == 2)
        //        return 1;
        //    ulong sieveLimit = (ulong)sieve.Length;
        //    ulong phi = n;
        //    ulong i = 2;
        //    ulong lastPrime = 2;
        //    while (i < sieveLimit) {
        //        if (!sieve[i]) {
        //            lastPrime = i;
        //            if (0 == (n % i)) {
        //                phi -= phi / lastPrime;
        //                while (0 == (n % lastPrime))
        //                    n /= lastPrime;
        //            }
        //        }
        //        if (lastPrime * lastPrime > n)
        //            break;
        //        i++;
        //    }
        //    if (n > 1)
        //        phi -= phi / n;
        //    return phi;
        //}

        public static ulong SumFactorialDigits(ulong number)
        {
            ulong sum = 0;
            while (number >= 1)
            {
                sum += Factorials10[number%10];
                number /= 10;
            }
            return sum;
        }

        public static bool IsPerfectSquare(ulong n)
        {
            // TODO: if (n and 7) = 1 or (n and 31) = 4 or (n and 127) = 16 or (n and 191) = 0 then print n "is probably square" else print n "is definitely not square".   http://en.wikipedia.org/wiki/Square_number#Properties
            //http://www.johndcook.com/blog/2008/11/17/fast-way-to-test-whether-a-number-is-a-square/
            ulong h = n & 0xF; // last hexidecimal "digit"
            if (h > 9)
                return false; // return immediately in 6 cases out of 16.

            // Take advantage of Boolean short-circuit evaluation
            if (h != 2 && h != 3 && h != 5 && h != 6 && h != 7 && h != 8)
            {
                ulong t = (ulong) (Math.Sqrt((double) n) + 0.5d);
                return t*t == n;
            }
            return false;
        }

        public static ulong MakePalindrom(ulong n, ulong baseToUse, bool fOddLength)
        {
            ulong res = n;
            if (fOddLength)
                n /= baseToUse;
            while (n > 0)
            {
                res = (res*baseToUse) + (n%baseToUse);
                n /= baseToUse;
            }
            return res;
        }

        public static int CompareNumberAsString(string a, string b)
        {
            if (a.Length < b.Length)
                return -1;
            if (a.Length > b.Length)
                return +1;
            return String.CompareOrdinal(a, b);
        }

        // Solve a*lastX + b*lastY = 1
        public static long ExtendedPGCD(long a, long b, out long lastX, out long lastY)
        {
            long x = 0;
            long y = 1;
            lastX = 1;
            lastY = 0;
            while (0 != b)
            {
                long tmp;
                long q = a/b;

                tmp = a;
                a = b;
                b = tmp%b;

                tmp = x;
                x = lastX - q*x;
                lastX = tmp;

                tmp = y;
                y = lastY - q*y;
                lastY = tmp;
            }
            return a;
        }

        public static bool IsSpecialSet(ulong[] set)
        {
            int max = 1 << set.Length;
            for (int a = 1; a < max; a++)
                for (int b = 1; b < max; b++)
                {
                    // check all bit patterns
                    if ((a & b) != 0)
                        continue; // not disjoint
                    // sum and count number of elements in sub-set A
                    int bitCount = 0;
                    ulong total = 0;
                    int pos = 0;
                    int include = a;
                    while (include > 0)
                    {
                        if ((include & 1) != 0)
                        {
                            total += set[pos];
                            bitCount++;
                        }
                        pos++;
                        include >>= 1;
                    }
                    ulong sumA = total;
                    int countA = bitCount;

                    // sum and count number of elements in sub-set B
                    bitCount = 0;
                    total = 0;
                    pos = 0;
                    include = b;
                    while (include > 0)
                    {
                        if ((include & 1) != 0)
                        {
                            total += set[pos];
                            bitCount++;
                        }
                        pos++;
                        include >>= 1;
                    }
                    ulong sumB = total;
                    int countB = bitCount;

                    // Check special set properties
                    if (sumA == sumB)
                        return false;
                    if ((countA > countB) && (sumA <= sumB))
                        return false;
                    if ((countA < countB) && (sumA >= sumB))
                        return false;
                }
            return true;
        }

        public static string[] Permutations(string digits)
        {
            int n = 1;
            for (int i = 1; i <= digits.Length; i++)
                n *= i;
            string[] result = new string[n];
            if (n == 1)
            {
                result[0] = digits;
                return result;
            }
            for (int i = 0; i < digits.Length; i++)
            {
                string digitsSub = digits.Substring(0, i) + digits.Substring(i + 1);
                string[] resultSub = Permutations(digitsSub);
                for (int j = 0; j < resultSub.Length; j++)
                    result[i*resultSub.Length + j] = digits[i] + resultSub[j];
            }
            return result;
        }
    }
}