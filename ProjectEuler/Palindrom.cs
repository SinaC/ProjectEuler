namespace ProjectEuler
{
    public class Palindrom
    {
        private int _length;
        private ulong _n, _limit;

        public Palindrom()
        {
            Init(1);
        }
        public Palindrom(int len)
        {
            Init(len);
        }

        private void Init(int len)
        {
            _length = len;
            _n = 1;
            for (int k = (_length + 1)/2; k > 1; k--)
                _n *= 10;
            _limit = _n*10;
        }

        public bool Increment()
        {
            _n++;
            if (_n < _limit) 
                return false;
            Init(_length + 1);
            return true;
        }

        public ulong GetValue()
        {
            ulong r = _n;
            ulong rem = _n;
            if (_length%2 != 0) 
                rem /= 10;
            for (int i = 1; i < _length; i += 2)
            {
                r = r*10 + (rem%10);
                rem /= 10;
            }
            return r;
        }
    }
}