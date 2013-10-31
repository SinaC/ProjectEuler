namespace ProjectEuler
{
    public class Problem39
    {
        public ulong Solve()
        {
            // a^2+b^2=c^2 (1)
            // a+b+c=p -> c = p-a-b (2)
            // a+b>c  c>a  c>b
            // (2) in (1)
            // a^2+b^2 = (p-a-b)^2
            // a^2+b^2 = p^2+a^2+b^2-2ap-2pb+2ab
            // 2pb-2ab = p^2 - 2ap
            // 2b(p-a) = p(p-2a)
            // b = p(p-2a)/2(p-a)  must be integral
            const ulong limit = 1000;
            int maxSolutionCount = 0;
            ulong pWithMaxSolution = 0;
            for (ulong p = 1; p <= limit; p++)
            {
                int solutionCount = 0;
                for (ulong a = 1; a < p / 3; a++)
                { // force a to be the smallest side
                    ulong remainder = (p * (p - 2 * a)) % (2 * (p - a));
                    if (0 == remainder)
                    {
                        solutionCount++;
                        if (solutionCount > maxSolutionCount)
                        {
                            pWithMaxSolution = p;
                            maxSolutionCount = solutionCount;
                        }
                    }
                }
            }
            return pWithMaxSolution;
        }
    }
}
