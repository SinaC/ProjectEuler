using System.Globalization;

namespace ProjectEuler
{
    public class Problem90
    {
        public ulong Solve()
        {
            ulong count = 0;
            for (int a = 0; a <= 9; a++)
                for (int b = a + 1; b <= 9; b++)
                    for (int c = b + 1; c <= 9; c++)
                        for (int d = c + 1; d <= 9; d++)
                            for (int e = d + 1; e <= 9; e++)
                                for (int f = e + 1; f <= 9; f++)
                                    for (int g = 0; g <= 9; g++)
                                        for (int h = g + 1; h <= 9; h++)
                                            for (int i = h + 1; i <= 9; i++)
                                                for (int j = i + 1; j <= 9; j++)
                                                    for (int k = j + 1; k <= 9; k++)
                                                        for (int l = k + 1; l <= 9; l++)
                                                        {
                                                            string d1 = a.ToString(CultureInfo.InvariantCulture) + b.ToString(CultureInfo.InvariantCulture) + c.ToString(CultureInfo.InvariantCulture) + d.ToString(CultureInfo.InvariantCulture) + e.ToString(CultureInfo.InvariantCulture) + f.ToString(CultureInfo.InvariantCulture);
                                                            string d2 = g.ToString(CultureInfo.InvariantCulture) + h.ToString(CultureInfo.InvariantCulture) + i.ToString(CultureInfo.InvariantCulture) + j.ToString(CultureInfo.InvariantCulture) + k.ToString(CultureInfo.InvariantCulture) + l.ToString(CultureInfo.InvariantCulture);
                                                            if (IsValid(d1, d2))
                                                                count++;
                                                        }

            return count / 2;
        }

        private bool IsValid(string d1, string d2)
        {
            if (!((d1.Contains("0") && d2.Contains("1")) || (d2.Contains("0") && d1.Contains("1"))))
                return false;
            if (!((d1.Contains("0") && d2.Contains("4")) || (d2.Contains("0") && d1.Contains("4"))))
                return false;
            if (!((d1.Contains("0") && (d2.Contains("6") || d2.Contains("9"))) || (d2.Contains("0") && (d1.Contains("6") || d1.Contains("9")))))
                return false;
            if (!((d1.Contains("1") && (d2.Contains("6") || d2.Contains("9"))) || (d2.Contains("1") && (d1.Contains("6") || d1.Contains("9")))))
                return false;
            if (!((d1.Contains("2") && d2.Contains("5")) || (d2.Contains("2") && d1.Contains("5"))))
                return false;
            if (!((d1.Contains("3") && (d2.Contains("6") || d2.Contains("9"))) || (d2.Contains("3") && (d1.Contains("6") || d1.Contains("9")))))
                return false;
            if (!((d1.Contains("4") && (d2.Contains("6") || d2.Contains("9"))) || (d2.Contains("4") && (d1.Contains("6") || d1.Contains("9")))))
                return false;
            if (!((d1.Contains("8") && d2.Contains("1")) || (d2.Contains("8") && d1.Contains("1"))))
                return false;
            return true;
        }
    }
}
