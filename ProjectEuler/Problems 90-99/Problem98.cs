using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem98 : ProblemBase
    {
        public Problem98() : base(98)
        {
        }

        public override string Solve()
        {
            int result = 0;

            List<int> squareList = new List<int>();
            for (int i = 2; i < 31700; i++)
                squareList.Add(i * i);
            int[] squares = squareList.ToArray();

            string[] words = Data.Replace("\"", "").Split(',');
            char[][] sorted = new char[words.Length][];

            //Find anagrams
            for (int i = 0; i < words.Length; i++)
            {
                sorted[i] = words[i].ToCharArray();
                Array.Sort(sorted[i]);
            }

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {

                    if (sorted[i].Length != sorted[j].Length) continue;
                    bool isEqual = true;
                    for (int k = 0; k < sorted[i].Length; k++)
                    {
                        isEqual = sorted[i][k] == sorted[j][k];
                        if (!isEqual) break;
                    }

                    if (isEqual)
                    {

                        int pairvalue = SquareAnagram(squares, words[i], words[j]);

                        if (pairvalue > result)
                            result = pairvalue;
                        //Console.WriteLine("{0} and {1} are anagrams and gives {2}", words[i], words[j], pairvalue);
                    }
                }
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        private static int SquareAnagram(int[] squares, string word1, string word2)
        {
            int max = 0;
            char[] w1Array = word1.ToCharArray();
            char[] w2Array = word2.ToCharArray();

            for (int i = 0; i < squares.Length; i++)
            {
                int squareLength = squares[i].ToString(CultureInfo.InvariantCulture).Length;

                //Too short, keep looking
                if (squareLength < word1.Length)
                    continue;

                //Too int, stop search
                if (squareLength > word1.Length)
                    break;

                bool match = true;

                int square = squares[i];
                Dictionary<char, int> map = new Dictionary<char, int>();

                //Make a map out of the first word
                for (int j = w1Array.Length - 1; j >= 0; j--)
                {
                    int digit = square % 10;
                    square /= 10;

                    //A repeated letter is found which doesn't match the square pattern
                    if (map.ContainsKey(w1Array[j]))
                        if (map[w1Array[j]] == digit)
                            continue;
                        else
                        {
                            match = false;
                            break;
                        }

                    //The value is already used
                    if (map.ContainsValue(digit))
                    {
                        match = false;
                        break;
                    }

                    map.Add(w1Array[j], digit);
                }

                if (!match) 
                    continue;

                //Check if the map can be used for word 2
                int w2Value = 0;
                if (map[w2Array[0]] == 0)
                    match = false;
                else
                    w2Value = w2Array.Aggregate(w2Value, (current, t) => current*10 + map[t]);
                if (!match) 
                    continue;
                if (Array.BinarySearch(squares, w2Value) > -1)
                {
                    int maxpair = Math.Max(w2Value, squares[i]);
                    max = Math.Max(max, maxpair);
                }
            }
            return max;
        }
    }
}
