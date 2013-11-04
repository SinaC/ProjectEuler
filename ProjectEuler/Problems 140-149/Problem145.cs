namespace ProjectEuler
{
    public class Problem145
    {
        public ulong Solve()
        {
            // Brute-force
            //ulong[] digitsCount = { 0, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
            //ulong limit = 1000000000;
            //ulong count = 0;
            //for (ulong n = 12; n <= limit; n++) {
            //    if (n % 1000000 == 0)
            //        Console.WriteLine(n);
            //    if (0 == (n % 10)) // no leading 0
            //        continue;
            //    ulong pow10 = 1;
            //    for (ulong i = 1; i < (ulong)digitsCount.Length; i++) {
            //        if (n <= digitsCount[i])
            //            break;
            //        pow10 *= 10;
            //    }
            //    bool fOk = true;
            //    ulong carry = 0;
            //    ulong number = n;
            //    while (number > 0) {
            //        ulong digitNumber = (n / pow10) % 10;
            //        ulong digitReverse = number % 10;
            //        ulong sum = digitNumber + digitReverse + carry;
            //        if (sum >= 10)
            //            carry = 1;
            //        else
            //            carry = 0;
            //        if (0 == (sum & 1)) {
            //            fOk = false;
            //            break;
            //        }
            //        number /= 10;
            //        pow10 /= 10;
            //    }
            //    if (fOk)
            //        count++;
            //}
            //return count;

            // Brute-force
            const ulong limit = 1000000000;
            ulong[] digits = new ulong[10];
            for (int i = 0; i < digits.Length; i++)
                digits[i] = 0;
            digits[0] = 1;
            ulong length = 1; // Length in digits
            ulong count = 0;
            for (ulong n = 1; n < limit; n++)
            {
                ulong i;
                if (digits[0] > 0)
                { // No trailing zeroes
                    ulong carry = 0; // Carry
                    for (i = 0; i < length; ++i)
                    {
                        ulong sum = digits[i] + digits[length - 1 - i] + carry; // Digits of sum
                        if (0 == (sum & 1))
                            break; // Want odd ones
                        carry = (sum >= 10) ? (ulong)1 : (ulong)0; // New carry
                    }
                    if (i == length)
                        count++; // Got one
                }
                // Increment
                for (i = 0; digits[i] == 9; ++i)
                    digits[i] = 0;
                if (i == length)
                {
                    length++;
                    digits[i] = 1;
                }
                else
                    digits[i]++;
            }
            return count;

            // Trailing digit cannot be 0
            // 1 digit: 0 solutions
            // 2 digits: ab: a+b must be odd and < 10 ==> 20 solutions
            // 3 digits: abc: a+c must be odd and > 10, 2b must be < 10 ==> 20 (ac) * 5 (b) solutions
            // 4 digits: abcd: a+d must be odd and < 10, b+c must be odd and < 10 => 20 (ad) * 30 (bc) solutions
            // 5 digits: 0 solutions
            // 6 digits: abcdef: a+f, b+e, c+d must be odd and < 10 => 20 (af) * 30 (be) * 30 (cd) solutions
            // 7 digits: abcdefg: a+g must be odd and > 10, b+f even and > 10, c+e even and > 10, 2d must be < 10 => 20 (ag) * 25 (bf) * 20 (ce) * 5 (d) solutions
            // 8 digits: see 2, 4 and 6 ==> 20*30*30*30 solutions
            // 9 digits: 0 solutions
            // 10 digits: see 2, 4 and 6 ==> 20*30*30*30*30 solutions
            // 2n digits: 20*30^(n-1)
            // 4n+1 digits: no solutions
            // 4n+3 digits: 5*20*(25*20)^n
            //ulong limit = 1000000000;
            //ulong sum = 0;
            //for (ulong i = 1; i <= 9; i++) {
            //    if (0 == (i & 1))
            //        sum += 20 * PowModulo(30, i / 2 - 1, limit);
            //    else if (3 == (i % 4))
            //        sum += 5 * 20 * PowModulo(25 * 20, i / 4, limit);
            //}
            //return sum;
        }
    }
}
