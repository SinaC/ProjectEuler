namespace ProjectEuler
{
    public class Problem245 : ProblemBase
    {
        public Problem245() : base(245)
        {
        }

        [UnderConstruction]
        public override string Solve()
        {
            //        n - phi(n)     n - phi(n)   1
            // C(n) = ----------  =  ---------- . -  with k a positive integer
            //          n - 1        n - phi(n)   k
            // ( n - phi(n) ) * k = n - 1
            // ( phi(n) - 1 ) / ( n - 1 ) = ( k - 1 ) / k
            // k * phi(n) = k (mod n-1)
            return "0";
        }
    }
}
