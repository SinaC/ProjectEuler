using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    // DOESN'T WORK
    public class Problem180
    {
        public ulong Solve()
        {
            // f1n(x,y,z) = x^(n+1) + y^(n+1) - z^(n+1)
            // f2n(x,y,z) = (xy+yz+zx) * (x^(n-1) + y^(n-1) - z^(n-1))
            // f3n(x,y,z) = xyz * (x^(n-2) + y^(n-2) - z^(n-2))
            // fn(x,y,z) = f1n(x,y,z) + f2n(x,y,z) - f3n(x,y,z)
            // fn(x,y,z) = x^(n+1) + y^(n+1) - z^(n+1) + (xy+yz+zx) * (x^(n-1) + y^(n-1) - z^(n-1)) - xyz * (x^(n-2) + y^(n-2) - z^(n-2))
            // fn(x,y,z) = x^(n+1) + y^(n+1) - z^(n+1) + y*x^n + x*y^n - x*y*z^(n-1) + y*z*x^(n-1) + z*y^n - y*z^n + z*x^n + x*z*y^(n-1) - x*z^n - y*z*x^(n-1) - x*z*y^(n-1) - x*y*z^(n-1)
            // fn(x,y,z) = (x+y+z) * (x^n + y^n - z^n)
            // 
            // fn(x,y,z) = 0
            // if x+y+z = 0, impossible because x, y, z > 0
            // or (x^n + y^n - z^n) = 0
            // impossible for |n| > 2 (fermat theorem)
            // n = 2:  z = sqrt(x^2+y^2)
            // n = 1:  z = x+y
            // n = -1: z = xy / (x+y)
            // n = -2: z = xy / sqrt(x^2+y^2)

            // order=10 -> solution=12519  with 76 fractions in sums

            const ulong order = 35;
            // Create fractions
            Dictionary<Fraction, bool> fractions = new Dictionary<Fraction, bool>(new FractionEqualityComparer());
            for (ulong denominator = 1; denominator <= order; denominator++)
                for (ulong numerator = 1; numerator <= denominator - 1; numerator++)
                {
                    Fraction fraction = new Fraction(numerator, denominator);
                    fraction.Simplify();
                    if (!fractions.ContainsKey(fraction))
                        fractions.Add(fraction, true);
                }
            // Compute z for each pair of fraction x, y
            // If z is in fractions, store x+y+z if not already stored
            Dictionary<Fraction, int> sums = new Dictionary<Fraction, int>(new FractionEqualityComparer());
            foreach (KeyValuePair<Fraction, bool> kvx in fractions)
                foreach (KeyValuePair<Fraction, bool> kvy in fractions)
                {
                    Fraction x = kvx.Key;
                    Fraction y = kvy.Key;
                    // Sum
                    // Compute sqrt( x^2 + y^2 )
                    ulong numeratorSqrt = x.Numerator * x.Numerator * y.Denominator * y.Denominator + y.Numerator * y.Numerator * x.Denominator * x.Denominator;
                    ulong denominatorSqrt = x.Denominator * x.Denominator * y.Denominator * y.Denominator;
                    Fraction.Simplify(ref numeratorSqrt, ref denominatorSqrt);
                    // Test n=2 and n=-2 only if sqrt(x^2 + y^2) is a perfect square
                    if (Tools.IsPerfectSquare(numeratorSqrt) && Tools.IsPerfectSquare(denominatorSqrt))
                    {
                        numeratorSqrt = (ulong)Math.Sqrt(numeratorSqrt);
                        denominatorSqrt = (ulong)Math.Sqrt(denominatorSqrt);
                        Fraction.Simplify(ref numeratorSqrt, ref denominatorSqrt);
                        // n = 2
                        Fraction zn2 = new Fraction(numeratorSqrt, denominatorSqrt);
                        zn2.Simplify();
                        if (fractions.ContainsKey(zn2))
                        {
                            Fraction sum = Fraction.Add(x, y);
                            sum = Fraction.Add(sum, zn2);
                            sum.Simplify();
                            if (sums.ContainsKey(sum))
                                sums[sum]++;
                            else
                                sums.Add(sum, 1);
                            //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn2=" + zn2.ToString());
                        }
                        // n = -2  -> x*y / n2
                        Fraction zn_2 = new Fraction(x.Numerator * y.Numerator * zn2.Denominator, x.Denominator * y.Denominator * zn2.Numerator);
                        zn_2.Simplify();
                        if (fractions.ContainsKey(zn_2))
                        {
                            Fraction sum = Fraction.Add(x, y);
                            sum = Fraction.Add(sum, zn_2);
                            sum.Simplify();
                            if (sums.ContainsKey(sum))
                                sums[sum]++;
                            else
                                sums.Add(sum, 1);
                            //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn_2=" + zn_2.ToString());
                        }
                    }
                    // n = 1
                    Fraction zn1 = Fraction.Add(x, y);
                    zn1.Simplify();
                    if (fractions.ContainsKey(zn1))
                    {
                        Fraction sum = Fraction.Add(x, y);
                        sum = Fraction.Add(sum, zn1);
                        sum.Simplify();
                        if (sums.ContainsKey(sum))
                            sums[sum]++;
                        else
                            sums.Add(sum, 1);
                        //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn1=" + zn1.ToString());
                    }
                    // n = -1  -> x*y / n1
                    Fraction zn_1 = new Fraction(x.Numerator * y.Numerator * zn1.Denominator, x.Denominator * y.Denominator * zn1.Numerator);
                    zn_1.Simplify();
                    if (fractions.ContainsKey(zn_1))
                    {
                        Fraction sum = Fraction.Add(x, y);
                        sum = Fraction.Add(sum, zn_1);
                        sum.Simplify();
                        if (sums.ContainsKey(sum))
                            sums[sum]++;
                        else
                            sums.Add(sum, 1);
                        //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn_1=" + zn_1.ToString());
                    }
                }
            Fraction total = new Fraction(0, 1);
            foreach (KeyValuePair<Fraction, int> kv in sums)
            {
                total = Fraction.Add(total, kv.Key);
                total.Simplify();
            }
            return total.Numerator + total.Denominator;
        }

        class Fraction
        {
            public ulong Numerator, Denominator;

            public Fraction(ulong numerator, ulong denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }

            public void Simplify()
            {
                ulong a = Numerator;
                ulong b = Denominator;
                ulong r;
                while (0 != (r = a % b))
                {
                    a = b;
                    b = r;
                }
                // b contains PGCD
                Numerator /= b;
                Denominator /= b;
            }

            public static Fraction Add(Fraction f1, Fraction f2)
            {
                return new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
            }

            public static void Simplify(ref ulong numerator, ref ulong denominator)
            {
                ulong a = numerator;
                ulong b = denominator;
                ulong r;
                while (0 != (r = a % b))
                {
                    a = b;
                    b = r;
                }
                // b contains PGCD
                numerator /= b;
                denominator /= b;
            }

            public override string ToString()
            {
                return Numerator.ToString() + "/" + Denominator.ToString();
            }
        }

        class FractionEqualityComparer : IEqualityComparer<Fraction>
        {
            #region IEqualityComparer<Fraction> Members
            bool IEqualityComparer<Fraction>.Equals(Fraction x, Fraction y)
            {
                return x.Numerator == y.Numerator && x.Denominator == y.Denominator;
            }

            int IEqualityComparer<Fraction>.GetHashCode(Fraction obj)
            {
                return obj.Numerator.GetHashCode() ^ obj.Denominator.GetHashCode();
            }
            #endregion
        }
    }
}
