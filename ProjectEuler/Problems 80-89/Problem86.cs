namespace ProjectEuler
{
    public class Problem86
    {
        public ulong Solve()
        {
            // Brute-force
            //http://oeis.org/A143715
            //sum(a=1, M, sum(b=a, M, sum(c=b, M, issquare((a+b)^2+c^2))))
            //ulong limit = 2000;
            //ulong size = (ulong)(Math.Sqrt(limit) + 0.5); // arbitrary lower limit
            //while (true) {
            //    ulong count = 0;
            //    for (ulong a = 1; a <= size; a++) {
            //        for (ulong b = a; b <= size; b++)
            //            for (ulong c = b; c <= size; c++)
            //                if (IsPerfectSquare((a + b) * (a + b) + c * c))
            //                    count++;
            //    }
            //    if (count >= limit) {
            //        //Console.WriteLine(limit + "->" + size + " [" + count + "]" + 2.125 * Math.Sqrt(limit));
            //        break;
            //    }
            //    size++;
            //}

            //const ulong limit = 1000000;
            //ulong size = 1;
            //ulong count = 0;
            //while (true) {
            //    for (ulong i = 1; i <= size; i++)
            //        for (ulong j = 1; j <= i; j++) {
            //            //a = (size + j) * (size + j) + i * i; (1)
            //            //b = (size + i) * (size + i) + j * j; (2)
            //            //a = b < a ? b : a; (3)
            //            //b = (i + j) * (i + j) + size * size; (4)
            //            //a = b < a ? b : a; (5)
            //            //b = (ulong)Math.Sqrt(a);

            //            // 1) a <= b because j <= i   b is never computed/used in (2) and (3)
            //            // 2) (size + j) * (size + j) + i * i < (i + j) * (i + j) + size * size  if i < size   b is computed only if i < size in (4)
            //            // 3) else i == size, (size + j) * (size + j) + i * i => (i + j) * (i + j) + s * s    b is never computed/used in (4) and (5)
            //            ulong squaredDist = (i + j) * (i + j) + size * size;
            //            if (IsPerfectSquare(squaredDist))
            //                count++;
            //        }
            //    if (count >= limit)
            //        break;
            //    size++;
            //}
            //return (ulong)size;

            const ulong limit = 1000000;
            ulong sum = 0;
            ulong size = 1;
            while (true)
            {
                for (ulong a = 1; a <= 2 * size; a++)
                    if (Tools.IsPerfectSquare(a * a + size * size))
                        if (a > size)
                            sum += a / 2 - (a - size - 1);
                        else
                            sum += a / 2;
                if (sum >= limit)
                    break;
                size++;
            }
            return size;
        }
    }
}
