using System.Globalization;

namespace ProjectEuler
{
    public class Problem173 : ProblemBase
    {
        public Problem173() : base(173)
        {
        }

        public override string Solve()
        {
            // Number of tiles needed for a square of side S -> 4(C-1)
            // Start with a square and add englobing square until limit is reached
            const ulong limit = 1000000;
            const ulong biggestSquare = (limit / 4) + 1;
            ulong count = 0;
            for (ulong i = 3; i <= biggestSquare; i++)
            {
                ulong tiles = 0;
                for (ulong j = i; j <= biggestSquare; j += 2)
                { // englobing square side is square side+2
                    tiles += 4 * (j - 1);
                    if (tiles <= limit)
                        count++;
                    else
                        break; // No need to continue with biggest square
                }
            }
            return count.ToString(CultureInfo.InvariantCulture);
        }
    }
}
