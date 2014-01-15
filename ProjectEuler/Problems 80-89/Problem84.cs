using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Problem84
    {
        public string Solve()
        {
            const int limit = 10000000;
            int[] counter = new int[40];

            Count(counter, limit);

            List<Tuple<int, int>> sorted = Enumerable.Range(0, 39).Select(i => new Tuple<int, int>(i, counter[i])).OrderByDescending(t => t.Item2).ToList();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                if (sorted[i].Item1 < 10)
                    sb.Append("0");

                sb.Append(sorted[i].Item1.ToString(CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

        private static int GetDice(Random rd)
        {
            return rd.Next(4) + rd.Next(4) + 2;
        }

        private static void Count(int[] counter, int limit)
        {
            Random rd = new Random();
            int pos = 0, ccid = 0, chid = 0;

            for (int i = 0; i < limit; i++)
            {
                pos += GetDice(rd);
                pos %= 40;

                switch (pos)
                {
                    case 2:
                    case 17:
                    case 33:
                        switch (ccid)
                        {
                            case 0: pos = 0; break;
                            case 1: pos = 10; break;
                            default: break;
                        }
                        ccid++;
                        ccid %= 16;
                        break;
                    case 7:
                    case 22:
                    case 36:
                        switch (chid)
                        {
                            case 0: pos = 0; break;
                            case 1: pos = 10; break;
                            case 2: pos = 11; break;
                            case 3: pos = 24; break;
                            case 4: pos = 39; break;
                            case 5: pos = 5; break;
                            case 6:
                            case 7:
                                if (pos == 7)
                                    pos = 15;
                                if (pos == 22)
                                    pos = 25;
                                if (pos == 36)
                                    pos = 5;
                                break;
                            case 8:
                                if (pos == 22)
                                    pos = 28;
                                else
                                    pos = 12;
                                break;
                            case 9:
                                pos -= 3;
                                if (pos < 0)
                                    pos += 40;
                                break;
                            default: break;
                        }
                        chid++;
                        chid %= 16;
                        break;
                    case 30: pos = 10; break;
                    default: break;
                }

                counter[pos]++;
            }
        }
    }
}
