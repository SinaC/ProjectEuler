using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem33
    {
        public ulong Solve()
        {
            const ulong lowerBound = 10;
            const ulong upperBound = 99;
            List<KeyValuePair<ulong, ulong>> curiousFractions = new List<KeyValuePair<ulong, ulong>>();
            for (ulong numerator = lowerBound; numerator <= upperBound; numerator++)
            { // 2 digits
                for (ulong denominator = numerator + 1; denominator <= upperBound; denominator++)
                { // 2 digits and num/den < 1
                    if ((0 != numerator % 10) || (0 != denominator % 10))
                    { // non-trivial
                        string numeratorAsString = numerator.ToString(CultureInfo.InvariantCulture);
                        string denominatorAsString = denominator.ToString(CultureInfo.InvariantCulture);
                        bool fFound = false;
                        for (int i = 0; i < numeratorAsString.Length && !fFound; i++)
                            for (int j = 0; j < denominatorAsString.Length && !fFound; j++)
                                if (numeratorAsString[i] == denominatorAsString[j])
                                {
                                    ulong reducedNumerator = Convert.ToUInt64(numeratorAsString.Clone().ToString().Remove(i, 1));//ToUInt64(numeratorAsString[1 - i]); // Only 2 characters, no substring needed
                                    ulong reducedDenominator = Convert.ToUInt64(denominatorAsString.Clone().ToString().Remove(j, 1));//ToUInt64(denominatorAsString[1 - j]); // Only 2 characters, no substring needed
                                    if (0 != reducedDenominator)
                                    {
                                        ulong simplifiedReducedNumerator, simplifiedReducedDenominator;
                                        SimplifyFraction(reducedNumerator, reducedDenominator, out simplifiedReducedNumerator, out simplifiedReducedDenominator);
                                        ulong simplifiedNumerator, simplifiedDenominator;
                                        SimplifyFraction(numerator, denominator, out simplifiedNumerator, out simplifiedDenominator);
                                        if (simplifiedReducedNumerator == simplifiedNumerator && simplifiedReducedDenominator == simplifiedDenominator)
                                        {
                                            curiousFractions.Add(new KeyValuePair<ulong, ulong>(numerator, denominator));
                                            fFound = true;
                                        }
                                    }
                                }
                    }
                }
            }
            ulong productNumerator = 1;
            ulong productDenominator = 1;
            foreach (KeyValuePair<ulong, ulong> kv in curiousFractions)
            {
                productNumerator *= kv.Key;
                productDenominator *= kv.Value;
            }
            ulong simplifiedProductNumerator, simplifiedProductDenominator;
            SimplifyFraction(productNumerator, productDenominator, out simplifiedProductNumerator, out simplifiedProductDenominator);
            return simplifiedProductDenominator;
        }

        private void SimplifyFraction(ulong numerator, ulong denominator, out ulong simplifiedNumerator, out ulong simplifiedDenominator)
        {
            ulong pgcd = Tools.PGCD(numerator, denominator);
            simplifiedNumerator = numerator / pgcd;
            simplifiedDenominator = denominator / pgcd;
        }
    }
}
