using System.Collections.Generic;

namespace SudokuSolver
{
    // http://en.wikipedia.org/wiki/Exact_cover
    internal static class ExactCover
    {
        private static List<int> _solution;

        private static void FoundSingleSolution(object sender, DancingLinks.SolutionFoundEventArgs args)
        {
            _solution = args.Solution;
            args.Terminate = true;
        }

        public static List<int> GetSingleSolution(int[][] matrix)
        {
            var dlx = new DancingLinks(matrix);

            _solution = null;
            dlx.SolutionFound += FoundSingleSolution;
            dlx.Search();

            return _solution;
        }
    }
}