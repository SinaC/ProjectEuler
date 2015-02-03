using System;
using System.Globalization;

namespace ProjectEuler
{
    public class Problem170 : ProblemBase
    {
        public Problem170() : base(170)
        {
        }

        public override string Solve()
        {
            // Split each permutation of 012345789 in 3 or more parts (n, a, b, ... )
            // n*a concat n*b concat n*c ... is pandigital
            // n concat a concat b concat c ... is pandigital

            //// Brute-force
            //_170_PreparePermutations();
            //ulong largest = 0;
            //string[] permutations = Permutations("0123456789");
            //int n = 0;
            //List<ulong> bestSet = new List<ulong>();
            //foreach (string permutation in permutations) {
            //    n++;
            //    if (permutation[0] == '0') continue; // No leading 0
            //    List<ulong> set = new List<ulong>();
            //    _170_Extract(permutation, permutation.Length, set, ref largest, ref bestSet);
            //}
            //return largest;

            // For each pandigital starting with 98
            //      split in 2 parts
            //      a > 99
            //      b the rest
            //          for each multiple of 3 < min( a, b )/2
            //              check if a/i [+] b/i [+] i is pandigital   [+] means concatenation
            bool fFound = false;
            ulong largest = 0;
            string[] permutations = Tools.Tools.Permutations("76543210");
            int index = 0;
            while (!fFound)
            {
                string s = "98" + permutations[index];
                ulong n = Convert.ToUInt64(s);
                ulong pow10 = 1000;
                for (int p = 3; p < 10 && !fFound; p++)
                { // a must be > 99
                    ulong a = n % pow10;
                    ulong b = n / pow10;
                    for (ulong i = 3; i < Math.Min(a, b) / 2 && !fFound; i += 3)
                    {
                        if (0 == (a % i) && 0 == (b % i))
                        {
                            string concat = (a / i).ToString(CultureInfo.InvariantCulture) + (b / i).ToString(CultureInfo.InvariantCulture) + i.ToString(CultureInfo.InvariantCulture);
                            if (concat.Length == 10 && Tools.Tools.IsPandigitalCharRange(concat, '0', '9'))
                            {
                                largest = n;
                                fFound = true;
                                break;
                            }
                        }
                    }
                    pow10 *= 10;
                }
                index++;
            }
            return largest.ToString(CultureInfo.InvariantCulture);
        }

        //static List<string[]> _170_Permutations = null;
        //private void _170_PreparePermutations() {
        //    _170_Permutations = new List<string[]>();
        //    for (int n = 1; n < 10; n++) {
        //        string s = "";
        //        for (int i = 1; i < n; i++)
        //            s += i.ToString();
        //        _170_Permutations.Add( Permutations(s) );
        //    }
        //}
        //private ulong _170_BestConcat(List<ulong> set, ulong multiplier) {
        //    ulong bestConcat = 0;
        //    string[] permutations = _170_Permutations[set.Count - 1];
        //    foreach (string permutation in permutations) {
        //        string concat = "";
        //        foreach (char c in permutation) {
        //            int idx = ToInt32(c);
        //            ulong product = multiplier * set[idx];
        //            concat += product.ToString();
        //        }
        //        ulong value = Convert.ToUInt64(concat);
        //        if (value > bestConcat)
        //            bestConcat = value;
        //    }
        //    return bestConcat;
        //}
        //private void _170_Extract(string permutation, int totalLength, List<ulong> set, ref ulong largest, ref List<ulong> bestSet) {
        //    // Heuristics: multiplier < 100   other >= 100
        //    int min = 1;
        //    int max = permutation.Length;
        //    if (set.Count == 0) {
        //        max = 2;
        //        if (max > permutation.Length)
        //            max = permutation.Length;
        //    }
        //    else {
        //        min = 3;
        //        if (min > permutation.Length)
        //            min = permutation.Length;
        //    }
        //    for (int length = min; length <= max; length++) {
        //        ulong n = Convert.ToUInt64(permutation.Substring(0, length));
        //        if (set.Count == 0 && 0 != (n % 3)) continue; // multiplier must be a multiple of 3
        //        set.Add(n); // Push
        //        if (length == permutation.Length) {
        //            if (set.Count > 2) { // At least 2 numbers in product
        //                string concat = "";
        //                for (int i = 1; i < set.Count; i++) {
        //                    ulong product = set[0] * set[i];
        //                    concat += product.ToString();
        //                }
        //                // If pandigital
        //                if (concat.Length == totalLength && IsPandigitalAtoB(concat, '0', '9') ) {
        //                    ulong bestConcat = _170_BestConcat(set, set[0]);
        //                    if (bestConcat > largest) {
        //                        largest = bestConcat;
        //                        bestSet.Clear();
        //                        foreach (ulong item in set)
        //                            bestSet.Add(item);
        //                    }
        //                }
        //            }
        //        }
        //        else {
        //            if (set.Count < 3) { // Heuristics: exactly 3 items in the set
        //                // Recursive call with the remaining string
        //                string remaining = permutation.Substring(length);
        //                if (remaining[0] != '0') // No leading 0
        //                    _170_Extract(remaining, totalLength, set, ref largest, ref bestSet);
        //            }
        //        }
        //        set.RemoveAt(set.Count - 1); // Pop
        //    }
        //}
    }
}
