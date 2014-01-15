using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem54
    {
        public ulong Solve(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string data = reader.ReadToEnd();
                //_hands = (from line in data.Split('\n')
                //          select line.Trim().Split(' ').ToArray()).ToList();
                _hands = data.Split('\n').Where(x => x.Length > 0).Select(x => x.Trim().Split(' ').ToArray()).ToList();
            }
            ulong ret = 0;

            foreach (string[] hand in _hands)
            {
                Tuple<List<KeyValuePair<int, int>>, bool> tmp = GetCardNumbers(hand.Take(5));
                Tuple<int, int> score1 = GetScore(tmp.Item1, tmp.Item2);

                tmp = GetCardNumbers(hand.Skip(5));
                Tuple<int, int> score2 = GetScore(tmp.Item1, tmp.Item2);

                if (score1.Item1 > score2.Item1 || (score1.Item1 == score2.Item1 && score1.Item2 > score2.Item2))
                    ret++;
            }

            return ret;
        }

        private List<string[]> _hands;

        private static readonly Dictionary<char, int> ValueDict = new Dictionary<char, int>
            {
                {'2', 1},
                {'3', 2},
                {'4', 3},
                {'5', 4},
                {'6', 5},
                {'7', 6},
                {'8', 7},
                {'9', 8},
                {'T', 9},
                {'J', 10},
                {'Q', 11},
                {'K', 12},
                {'A', 13},
            };

        private static Tuple<List<KeyValuePair<int, int>>, bool> GetCardNumbers(IEnumerable<string> hand)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();
            HashSet<char> colors = new HashSet<char>();

            foreach (string card in hand)
            {
                if (nums.ContainsKey(ValueDict[card[0]]))
                    nums[ValueDict[card[0]]]++;
                else
                    nums.Add(ValueDict[card[0]], 1);

                colors.Add(card[1]);
            }

            List<KeyValuePair<int, int>> ret = nums.ToList();
            ret.Sort((x, y) =>
                {
                    int tmp = x.Value.CompareTo(y.Value);
                    if (tmp != 0)
                        return -tmp;
                    else
                        return y.Key.CompareTo(x.Key);
                });

            return new Tuple<List<KeyValuePair<int, int>>, bool>(ret, colors.Count == 1);
        }

        private static Tuple<int, int> GetScore(List<KeyValuePair<int, int>> nums, bool isFlush)
        {
            // Royal Flush/Straight Flush
            if (isFlush && nums.Count == 5 && nums[0].Key == nums[4].Key + 4)
                return new Tuple<int, int>(10, nums[0].Key);

            // Four of a Kind
            foreach (KeyValuePair<int,int> num in nums)
                if (num.Value == 4)
                    return new Tuple<int, int>(9, num.Key);

            // Full House
            if (nums[0].Value == 3 && nums[1].Value == 2)
                return new Tuple<int, int>(8, nums[0].Key);
            if (nums[0].Value == 2 && nums[1].Value == 3)
                return new Tuple<int, int>(8, nums[1].Key);

            // Flush
            if (isFlush)
                return new Tuple<int, int>(7, nums[0].Key);

            // Straight
            if (nums.Count == 5 && nums[0].Key == nums[4].Key + 4)
                return new Tuple<int, int>(6, nums[0].Key);

            // Three of a Kind
            foreach (KeyValuePair<int, int> num in nums)
                if (num.Value == 3)
                    return new Tuple<int, int>(5, num.Key);

            // Two Pairs
            if (nums.Count == 3)
                if (nums[0].Value == 2)
                    return new Tuple<int, int>(4, nums[0].Key);
                else
                    return new Tuple<int, int>(4, nums[1].Key);

            // One Pair
            foreach (KeyValuePair<int, int> num in nums)
                if (num.Value == 2)
                    return new Tuple<int, int>(3, num.Key);

            // High Card
            return new Tuple<int, int>(2, nums[0].Key);
        }
    }
}