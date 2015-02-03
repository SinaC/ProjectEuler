using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem96 : ProblemBase
    {
        public Problem96()
            : base(96)
        {
        }

        public override string Solve()
        {
            List<int[][]> puzzles = new List<int[][]>();
            for (int i = 1; i < Lines.Count(); i += 10) // 9 lines for puzzle + 1 for header
            {
                // take 9 lines of puzzle, for each line get each column and convert to digit
                int[][] puzzle = Lines.Skip(i).Take(9).Select(x => x.Trim().Select(c => c - '0').ToArray()).ToArray();
                puzzles.Add(puzzle);
            }

            int counter = 0;

            foreach (int[][] puzzle in puzzles)
            {
                SudokuSolver.SudokuSolver.Solve(puzzle);
                counter += puzzle[0][0]*100 + puzzle[0][1]*10 + puzzle[0][2];
            }

            return counter.ToString(CultureInfo.InvariantCulture);
        }
    }
}