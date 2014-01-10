using System;

namespace Fractions
{
    public class OldFraction
    {
        public ulong Numerator, Denominator;

        public OldFraction(ulong numerator, ulong denominator)
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

        public static OldFraction Add(OldFraction f1, OldFraction f2)
        {
            return new OldFraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
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
            return String.Format("{0}/{1}", Numerator, Denominator);
        }
    }
}
