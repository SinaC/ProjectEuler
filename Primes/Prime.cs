using System;
using System.Collections.Generic;
using System.Linq;

namespace Primes
{
    public class Prime
    {
        private int _last, _step;
        private readonly int _upper;

        private readonly List<int> _nums;
        private readonly HashSet<int> _sNums;

        public int Upper { get { return _upper; } }

        public List<int> Nums { get { return _nums; } }

        public Prime(int upper)
        {
            _last = 5;
            _step = 2;
            _upper = upper;

            _nums = new List<int>(new[] { 2, 3, 5 });
            _sNums = new HashSet<int>(new[] { 2, 3, 5 });
        }

        public bool Contains(int n)
        {
            return _sNums.Contains(n);
        }

        public bool IsPrime(long n)
        {
            int sqrtn = (int)Math.Sqrt(n) + 1;

            if (sqrtn > _upper)
                throw new ArgumentException("Input n is too large");
            while (sqrtn > _last && GenerateNext() != 0)
                ; // empty statement

            if (n < _last)
                return _sNums.Contains((int)n);
            for (int i = 0; i < _nums.Count && sqrtn > _nums[i]; i++)
                if (n % _nums[i] == 0)
                    return false;

            return true;
        }

        public int GenerateNext()
        {
            while ((_last += _step) < _upper)
            {
                _step = 6 - _step;
                if (IsPrime(_last))
                {
                    _nums.Add(_last);
                    _sNums.Add(_last);
                    return _last;
                }
            }

            return 0;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int n in _nums)
                yield return n;
            while (GenerateNext() != 0)
                yield return _last;
        }

        public void GenerateAll()
        {
            byte[] flags = new byte[_upper / 2];

            for (int i = 1; i < _nums.Count; i++)
                for (int j = _nums[i] * 3; j < _upper; j += _nums[i] * 2)
                    flags[j / 2] = 1;

            for (int i = _last + 2; i < _upper; i += _step)
            {
                _step = 6 - _step;
                if (flags[i / 2] != 0)
                    continue;
                for (int j = i * 3; j < _upper; j += i * 2)
                    flags[j / 2] = 1;
            }

            for (int i = _last + 2; i < _upper; i += 2)
            {
                if (flags[i / 2] == 0)
                {
                    _nums.Add(i);
                    _sNums.Add(i);
                }
            }
            _last = _upper;
        }

        public static List<long> GetDivisors(Prime primes, long n)
        {
            List<long> ret = new List<long>() { 1 };

            foreach (var p in primes)
            {
                List<long> tmp = new List<long>(ret);
                long tmpp = 1;

                if (n == 1)
                    break;
                if (p * p > n)
                {
                    tmp.AddRange(ret.Select(it => it * n));
                    ret = tmp;
                    break;
                }
                if (n % p != 0)
                    continue;

                while (n % p == 0)
                {
                    n /= p;
                    tmpp *= p;
                    tmp.AddRange(ret.Select(it => it * tmpp));
                }
                ret = tmp;
            }

            return ret;
        }
    }

}
