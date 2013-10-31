namespace ProjectEuler
{
    public class Problem94
    {
        public ulong Solve()
        {
            // Brute-force
            // perimeter = 2*a+b with b=a+1 or b=a-1
            // area = 1/4 * ( 3a # 1 ) * sqrt( ( a # 1 )^2 * ( a | 1 ) )  with # representing + (b=a+1) or - (b=a-1) and  | representing - (b=a+1) or + (b=a-1)
            const ulong perimeterLimit = 1000000000;
            const ulong sideLimit = 1 + (1000000000 / 3);
            ulong count = 1;
            ulong sum = 0;
            for (ulong a = 3; a <= sideLimit; a += 2)
            {
                //if (a % 1000000 == 0)
                //    Console.WriteLine("a:" + a + " count:" + count + " sum: "+sum);
                ulong b1 = a + 1;
                ulong perimeter1 = 2 * a + b1;
                ulong toTest1 = (4 * a * a - b1 * b1); // a^2 - (b/2)^2 = height of the triangle with base b
                if (0 == (toTest1 % 4))
                {
                    bool fIntegral1 = Tools.IsPerfectSquare(toTest1 / 4);
                    if (perimeter1 <= perimeterLimit && fIntegral1)
                    {
                        //Console.WriteLine("+1 --> a=" + a + " b=" + b1 + " p=" + perimeter1);
                        sum += perimeter1;
                        count++;
                        continue; // no need to test second case
                    }
                }
                ulong b2 = a - 1;
                ulong perimeter2 = 2 * a + b2;
                ulong toTest2 = (4 * a * a - b2 * b2); // a^2 - (b/2)^2 = height of the triangle with base b
                if (0 == (toTest2 % 4))
                {
                    bool fIntegral2 = Tools.IsPerfectSquare(toTest2 / 4);
                    if (perimeter2 <= perimeterLimit && fIntegral2)
                    {
                        //Console.WriteLine("-1 --> a=" + a + " b=" + b2 + " p=" + perimeter2);
                        sum += perimeter2;
                        count++;
                    }
                }
            }
            return sum;
            // Fast method: http://oeis.org/A120893
        }
    }
}
