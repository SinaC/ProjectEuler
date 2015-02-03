using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem32 : ProblemBase
    {
        public Problem32() : base(32)
        {
        }

        public override string Solve()
        {
            // #digits multiplicand + #digits multiplier + #digits product = 9 digits
            // 1 digit * 4 digits = 4 digits (9 digits)
            // 2 digits * 3 digits = 4 or 5 digits (9 digits or 10 digits)
            List<int> panDigitalProducts = new List<int>();
            for (int a = 2; a <= 98; a++)
            {
                int start = (a >= 10) ? 123 : 1234;
                for (int b = start; b <= (10000 / a) + 1; b++)
                {
                    int product = a * b;
                    string s = a.ToString(CultureInfo.InvariantCulture) + b.ToString(CultureInfo.InvariantCulture) + product.ToString(CultureInfo.InvariantCulture);
                    if (s.Length == 9)
                    {
                        bool fIsPanDigitalProduct = Tools.Tools.IsPandigital(s);
                        if (fIsPanDigitalProduct && !panDigitalProducts.Contains(product))
                            panDigitalProducts.Add(product);
                    }
                }
            }
            return panDigitalProducts.Aggregate<int, ulong>(0, (current, panDigitalProduct) => current + (ulong) panDigitalProduct).ToString(CultureInfo.InvariantCulture);
        }
    }
}
