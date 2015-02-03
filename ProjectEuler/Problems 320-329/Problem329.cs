using System;
using System.Collections.Generic;
using Fractions;

namespace ProjectEuler
{
    //http://wiki.san-ss.com.ar/project-euler-problem-329
    public class Problem329 : ProblemBase
    {
        private readonly Dictionary<Tuple<int, string>, Fraction> _memoization = new Dictionary<Tuple<int, string>, Fraction>(new EqualityComparer());

        public Problem329() : base(329)
        {
        }

        public override string Solve()
        {
            //_memoization
            bool[] sieve = Tools.Tools.BuildSieve(501);
            for (int i = 1; i <= 500; i++)
            {
                if (!sieve[i])
                {
                    _memoization.Add(new Tuple<int, string>(i, "P"), new Fraction(2, 3));
                    _memoization.Add(new Tuple<int, string>(i, "N"), new Fraction(1, 3));
                }
                else
                {
                    _memoization.Add(new Tuple<int, string>(i, "P"), new Fraction(1, 3));
                    _memoization.Add(new Tuple<int, string>(i, "N"), new Fraction(2, 3));
                }
            }

            Fraction result = new Fraction(0, 1);
            const string sequence = "PPPPNNPPPNPPNPN";
            for (int i = 1; i <= 500; i++)
            {
                Fraction p = Probability(i, sequence);
                result += p;
            }

            result /= 500;
            Fraction.ReduceFraction(ref result);
            return result;
        }

        public class EqualityComparer : IEqualityComparer<Tuple<int, string>>
        {
            public bool Equals(Tuple<int, string> x, Tuple<int, string> y)
            {
                return x.Item1 == y.Item1 && x.Item2 == y.Item2;
            }

            public int GetHashCode(Tuple<int, string> x)
            {
                return x.Item1 ^ x.Item2.GetHashCode();
            }
        }

        private Fraction Probability(int i, string sequence)
        {
            Tuple<int, string> tuple = new Tuple<int, string>(i, sequence);
            Fraction prob;
            if (_memoization.TryGetValue(tuple, out prob))
                return prob;
            if (i == 1)
                prob = _memoization[new Tuple<int, string>(i, sequence.Substring(0, 1))]*Probability(i + 1, sequence.Substring(1));
            else if (i == 500)
                prob = _memoization[new Tuple<int, string>(i, sequence.Substring(0, 1))]*Probability(i - 1, sequence.Substring(1));
            else
                prob = _memoization[new Tuple<int, string>(i, sequence.Substring(0, 1))]*(Probability(i + 1, sequence.Substring(1))*new Fraction(1, 2) + Probability(i - 1, sequence.Substring(1))*new Fraction(1, 2));

            _memoization.Add(tuple, prob);
            return prob;
        }
    }
}