using System;
using System.Collections.Generic;
using System.Globalization;
using Fractions;

namespace ProjectEuler
{
    // DOESN'T WORK
    public class Problem180 : ProblemBase
    {
        public Problem180() : base(180)
        {
        }

        [UnderConstruction]
        public override string Solve()
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
            Dictionary<OldFraction, bool> fractions = new Dictionary<OldFraction, bool>(new FractionEqualityComparer());
            for (ulong denominator = 1; denominator <= order; denominator++)
                for (ulong numerator = 1; numerator <= denominator - 1; numerator++)
                {
                    OldFraction fraction = new OldFraction(numerator, denominator);
                    fraction.Simplify();
                    if (!fractions.ContainsKey(fraction))
                        fractions.Add(fraction, true);
                }
            // Compute z for each pair of fraction x, y
            // If z is in fractions, store x+y+z if not already stored
            Dictionary<OldFraction, int> sums = new Dictionary<OldFraction, int>(new FractionEqualityComparer());
            foreach (KeyValuePair<OldFraction, bool> kvx in fractions)
                foreach (KeyValuePair<OldFraction, bool> kvy in fractions)
                {
                    OldFraction x = kvx.Key;
                    OldFraction y = kvy.Key;
                    // Sum
                    // Compute sqrt( x^2 + y^2 )
                    ulong numeratorSqrt = x.Numerator * x.Numerator * y.Denominator * y.Denominator + y.Numerator * y.Numerator * x.Denominator * x.Denominator;
                    ulong denominatorSqrt = x.Denominator * x.Denominator * y.Denominator * y.Denominator;
                    OldFraction.Simplify(ref numeratorSqrt, ref denominatorSqrt);
                    // Test n=2 and n=-2 only if sqrt(x^2 + y^2) is a perfect square
                    if (Tools.Tools.IsPerfectSquare(numeratorSqrt) && Tools.Tools.IsPerfectSquare(denominatorSqrt))
                    {
                        numeratorSqrt = (ulong)Math.Sqrt(numeratorSqrt);
                        denominatorSqrt = (ulong)Math.Sqrt(denominatorSqrt);
                        OldFraction.Simplify(ref numeratorSqrt, ref denominatorSqrt);
                        // n = 2
                        OldFraction zn2 = new OldFraction(numeratorSqrt, denominatorSqrt);
                        zn2.Simplify();
                        if (fractions.ContainsKey(zn2))
                        {
                            OldFraction sum = OldFraction.Add(x, y);
                            sum = OldFraction.Add(sum, zn2);
                            sum.Simplify();
                            if (sums.ContainsKey(sum))
                                sums[sum]++;
                            else
                                sums.Add(sum, 1);
                            //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn2=" + zn2.ToString());
                        }
                        // n = -2  -> x*y / n2
                        OldFraction zn_2 = new OldFraction(x.Numerator * y.Numerator * zn2.Denominator, x.Denominator * y.Denominator * zn2.Numerator);
                        zn_2.Simplify();
                        if (fractions.ContainsKey(zn_2))
                        {
                            OldFraction sum = OldFraction.Add(x, y);
                            sum = OldFraction.Add(sum, zn_2);
                            sum.Simplify();
                            if (sums.ContainsKey(sum))
                                sums[sum]++;
                            else
                                sums.Add(sum, 1);
                            //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn_2=" + zn_2.ToString());
                        }
                    }
                    // n = 1
                    OldFraction zn1 = OldFraction.Add(x, y);
                    zn1.Simplify();
                    if (fractions.ContainsKey(zn1))
                    {
                        OldFraction sum = OldFraction.Add(x, y);
                        sum = OldFraction.Add(sum, zn1);
                        sum.Simplify();
                        if (sums.ContainsKey(sum))
                            sums[sum]++;
                        else
                            sums.Add(sum, 1);
                        //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn1=" + zn1.ToString());
                    }
                    // n = -1  -> x*y / n1
                    OldFraction zn_1 = new OldFraction(x.Numerator * y.Numerator * zn1.Denominator, x.Denominator * y.Denominator * zn1.Numerator);
                    zn_1.Simplify();
                    if (fractions.ContainsKey(zn_1))
                    {
                        OldFraction sum = OldFraction.Add(x, y);
                        sum = OldFraction.Add(sum, zn_1);
                        sum.Simplify();
                        if (sums.ContainsKey(sum))
                            sums[sum]++;
                        else
                            sums.Add(sum, 1);
                        //Console.WriteLine("x=" + x.ToString() + "   y=" + y.ToString() + "  zn_1=" + zn_1.ToString());
                    }
                }
            OldFraction total = new OldFraction(0, 1);
            foreach (KeyValuePair<OldFraction, int> kv in sums)
            {
                total = OldFraction.Add(total, kv.Key);
                total.Simplify();
            }
            return (total.Numerator + total.Denominator).ToString(CultureInfo.InvariantCulture);
        }

        class FractionEqualityComparer : IEqualityComparer<OldFraction>
        {
            #region IEqualityComparer<Fraction> Members
            bool IEqualityComparer<OldFraction>.Equals(OldFraction x, OldFraction y)
            {
                return x.Numerator == y.Numerator && x.Denominator == y.Denominator;
            }

            int IEqualityComparer<OldFraction>.GetHashCode(OldFraction obj)
            {
                return obj.Numerator.GetHashCode() ^ obj.Denominator.GetHashCode();
            }
            #endregion
        }
    }
}
