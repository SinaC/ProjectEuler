namespace ProjectEuler
{
    public class Problem3
    {
        public ulong Solve()
        {
            const ulong limit = 600851475143;
            ulong solution = 0;
            ulong number = limit;
            ulong counter = 2;
            while(counter*counter <= number)
            {
                if ((number % counter) == 0)
                {
                    number /= counter;
                    solution = counter;
                }
                else
                    counter = (counter == 2) ? 3 : counter + 2;
            }
            if (number > solution)
                solution = number;

            return solution;
        }
        //public ulong Solve()
        //{
        //    const ulong number = 600851475143;
        //    ulong sqrtN = (ulong)(Math.Sqrt(number) + 0.5);
        //    if (0 == (sqrtN & 1))
        //        sqrtN++; // we want an odd number
        //    ulong result = 0;
        //    for (ulong i = sqrtN; i > 2; i -= 2)
        //        if (0 == (number % i))
        //            if (IsPrime(i))
        //            {
        //                result = i;
        //                break;
        //            }
        //    return result;

        //    //ulong number = 600851475143;
        //    //ulong maxFactor = (ulong)(Math.Sqrt(number) + 0.5);
        //    //ulong factor = 3; // Don't need to treat 2, number is not divisible by 2
        //    //ulong lastFactor = 0;
        //    //while (number > 1 && factor <= maxFactor) {
        //    //    if (0 == (number % factor)) {
        //    //        number /= factor;
        //    //        lastFactor = factor;
        //    //        while (0 == (number % factor))
        //    //            number /= factor;
        //    //        maxFactor = (ulong)(Math.Sqrt(number) + 0.5);
        //    //    }
        //    //    factor += 2; // odd number
        //    //}
        //    //if (1 == number)
        //    //    return lastFactor;
        //    //else
        //    //    return number;
        //}
    }
}
