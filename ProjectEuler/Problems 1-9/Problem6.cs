namespace ProjectEuler
{
    public class Problem6
    {
        public ulong Solve()
        {
            // a/ sum(i:1->n,i)^2 = (n*(n+1)/2)^2 = n^2*(n+1)^2 /4 
            // b/ sum(i:1->n,i^2) = n*(n+1)*(2*n+1)/6 
            // a - b = 1/12*(3*n^4+2*n^3-3*n^2-2*n)
            const ulong limit = 100;
            const ulong sumSquared = (limit * limit * (limit + 1) * (limit + 1)) / 4;
            const ulong sumSquare = (limit * (limit + 1) * (2 * limit + 1)) / 6;
            return sumSquared - sumSquare;
        }
    }
}
