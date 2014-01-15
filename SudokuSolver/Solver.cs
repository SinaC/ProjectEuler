using System;

namespace SudokuSolver
{
    //http://en.wikipedia.org/wiki/Sudoku_algorithms
    public static class SudokuSolver
    {
        public static void Solve(int[][] puzzle)
        {
            int size = puzzle.Length;
            int subsize = (int) Math.Sqrt(size);

            if (size != puzzle[0].Length || subsize*subsize != size)
                throw new ArgumentException("invalid sudoku size");

            var matrix = new int[size*size*size][];

            for (int id = 0; id < size*size*size; id++)
            {
                int r = id/size/size, c = id/size%size, v = id%size;

                matrix[id] = new int[size*size*4];

                // Fixed-Value Contrains
                if (puzzle[r][c] != 0 && puzzle[r][c] != v + 1)
                    continue;

                // Row-Column Constrains
                matrix[id][r*size + c] = 1;

                // Row-Number Constrains
                matrix[id][size*size + r*size + v] = 1;

                // Column-Number Constrains
                matrix[id][size*size*2 + c*size + v] = 1;

                // Box-Number Constrains
                matrix[id][size*size*3 + ((r/subsize)*subsize + (c/subsize))*size + v] = 1;
            }

            var solutions = ExactCover.GetSingleSolution(matrix);

            if (solutions.Count != size*size)
                throw new InvalidOperationException("unsolvable puzzle");

            foreach (var id in solutions)
            {
                int r = id/size/size, c = id/size%size, v = id%size;

                puzzle[r][c] = v + 1;
            }
        }
    }
}