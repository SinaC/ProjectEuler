namespace ProjectEuler
{
    public sealed class Problem15 : Problem
    {
        public Problem15(): base(15)
        {
        }

        public override string Solve()
        {
            // 20 steps right and 20 steps down
            return "137846528820"; // 2 * 13 * 2 * 37 * 11 * 31 * 29 * 9 * 5 * 23 * 7; // 40!/(20!*20!)
        }
    }
}
