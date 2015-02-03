using System;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public sealed class Problem22 : ProblemBase
    {
        public Problem22()
            : base(22)
        {
        }

        public override string Solve()
        {
            //List<string> names = new List<string>(Data.Split(','));
            //names.Sort();
            //ulong sum = 0;
            //for (int i = 0; i < names.Count; i++)
            //{
            //    ulong nameValue = names[i].Where(c => c != '"').Aggregate<char, ulong>(0, (current, c) => current + (Convert.ToUInt64(c) - 'A'+1));
            //    sum += nameValue*((ulong) i + 1);
            //}
            //return sum.ToString(CultureInfo.InvariantCulture);
            return Data
                .Split(',')
                .OrderBy(x => x)
                .Select((x, index) => (index+1)*x.Where(c => c != '"').Aggregate(0, (current, c) => current + (Convert.ToInt32(c) - 'A' + 1)))
                .Aggregate(0, (n,item) => n+item).ToString(CultureInfo.InvariantCulture);
        }
    }
}