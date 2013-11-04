using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem118
    {
        public ulong Solve()
        {
            // Generate every pandigital permutations
            // Foreach permutation, try to extract prime starting from front
            // If able to extract prime till the end of the permutation, store in a set as string in a dictionary
            Dictionary<string, int> results = new Dictionary<string, int>();
            string[] permutations = Tools.Permutations("123456789");
            foreach (string permutation in permutations)
            {
                List<ulong> set = new List<ulong>();
                _118_Extract(permutation, set, results);
            }
            return (ulong) results.Count;
        }

        private void _118_Extract(string permutation, List<ulong> set, Dictionary<string, int> results)
        {
            for (int length = 1; length <= permutation.Length; length++)
            {
                ulong n = Convert.ToUInt64(permutation.Substring(0, length));
                if (!Primes.Check.IsPrime(n))
                    continue; // If it's not a prime, take a bigger substring
                set.Add(n); // Push
                if (length == permutation.Length)
                {
                    // Sort set
                    List<ulong> sorted = new List<ulong>(set);
                    sorted.Sort();
                    // Create string correponding to set
                    string sortedAsString = sorted.Aggregate("", (current, item) => current + ("(" + item.ToString(CultureInfo.InvariantCulture) + ")"));
                    // Insert string if not already found
                    if (!results.ContainsKey(sortedAsString))
                        results.Add(sortedAsString, 1);
                    else
                        results[sortedAsString]++; // Or increment occurence
                }
                else
                {
                    // Recursive call with the remaining string
                    string remaining = permutation.Substring(length);
                    _118_Extract(remaining, set, results);
                }
                set.RemoveAt(set.Count - 1); // Pop
            }
        }
    }
}
