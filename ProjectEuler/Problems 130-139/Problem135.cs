using System;

namespace ProjectEuler
{
    public class Problem135 : ProblemBase
    {
        public Problem135() : base(135)
        {
        }

        [UnderConstruction]
        public override string Solve()
        {
            // x^2 - y^2 - z^2 = n
            // x, y and z are an arithmetic progression of reason k
            // z = z, y = z + k, x = z + 2*k
            // (z+2k)^2 - (z+k)^2 - z^2 = n
            // 3k^2 + 2kz - z^2 = n
            // (3k-z)(k+z) = n
            // max: d/dz = 2k-2z = z = k => n = 4k^2
            // min: 3k-z = 1 => z = 3k-1 => n = 4k-1

            return String.Empty;
        }
    }
}
