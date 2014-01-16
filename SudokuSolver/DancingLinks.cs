using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    // http://www.ocf.berkeley.edu/~jchu/publicportal/sudoku/sudoku.paper.html
    internal class DancingLinks
    {
        public class SolutionFoundEventArgs : EventArgs
        {
            public List<int> Solution { get; private set; }
            public bool Terminate { get; set; }

            public SolutionFoundEventArgs(List<int> solution)
            {
                Solution = solution;
                Terminate = false;
            }
        }

        private class DancingLinksNode
        {
            public DancingLinksHeader Header;
            public DancingLinksNode Left;
            public DancingLinksNode Right;
            public DancingLinksNode Up;
            public DancingLinksNode Down;
            public readonly int RowID;

            public DancingLinksNode(DancingLinksHeader header, int row)
            {
                Header = header;
                Left = this;
                Right = this;
                Up = this;
                Down = this;
                RowID = row;
            }
        }

        private class DancingLinksHeader : DancingLinksNode
        {
            public int Count;

            public DancingLinksHeader()
                : base(null, -1)
            {
                Header = this;
                Count = 0;
            }
        }

        private readonly DancingLinksHeader _control;

        public DancingLinks(int[][] matrix)
        {
            _control = new DancingLinksHeader
                {
                    Header = null,
                    Up = null,
                    Down = null
                };
            for (int c = 0; c < matrix[0].Length; c++)
            {
                var header = new DancingLinksHeader
                    {
                        Left = _control.Left,
                        Right = _control
                    };
                header.Left.Right = header;
                header.Right.Left = header;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                DancingLinksHeader header = _control.Right as DancingLinksHeader;
                DancingLinksNode last = null;

                for (int j = 0; j < matrix[i].Length; j++, header = header.Right as DancingLinksHeader)
                {
                    if (matrix[i][j] == 0)
                        continue;

                    var tmp = new DancingLinksNode(header, i);

                    if (last != null)
                    {
                        tmp.Left = last;
                        tmp.Right = last.Right;
                        tmp.Left.Right = tmp;
                        tmp.Right.Left = tmp;
                    }
                    tmp.Up = header.Up;
                    tmp.Down = header;
                    tmp.Up.Down = tmp;
                    tmp.Down.Up = tmp;

                    header.Count++;
                    last = tmp;
                }
            }
        }

        public event EventHandler<SolutionFoundEventArgs> SolutionFound = delegate { };

        private DancingLinksHeader GetNextColumn()
        {
            DancingLinksHeader header = null;
            int min = int.MaxValue;

            for (var tmp = _control.Right as DancingLinksHeader; tmp != _control; tmp = tmp.Right as DancingLinksHeader)
            {
                if (min > tmp.Count)
                {
                    min = tmp.Count;
                    header = tmp;
                }
            }

            return header;
        }

        private static void Cover(DancingLinksNode node)
        {
            var header = node.Header;

            header.Left.Right = header.Right;
            header.Right.Left = header.Left;

            for (DancingLinksNode row = header.Down; row != header; row = row.Down)
            {
                for (DancingLinksNode tmp = row.Right; tmp != row; tmp = tmp.Right)
                {
                    tmp.Header.Count--;
                    tmp.Up.Down = tmp.Down;
                    tmp.Down.Up = tmp.Up;
                }
            }
        }

        private static void Uncover(DancingLinksNode node)
        {
            var header = node.Header;

            for (DancingLinksNode row = header.Up; row != header; row = row.Up)
            {
                for (DancingLinksNode tmp = row.Left; tmp != row; tmp = tmp.Left)
                {
                    tmp.Header.Count++;
                    tmp.Up.Down = tmp;
                    tmp.Down.Up = tmp;
                }
            }

            header.Left.Right = header;
            header.Right.Left = header;
        }

        private bool Search(List<int> solution)
        {
            if (_control.Right == _control)
            {
                var args = new SolutionFoundEventArgs(solution);

                SolutionFound(this, args);

                return args.Terminate;
            }

            DancingLinksHeader header = GetNextColumn();

            Cover(header);
            for (DancingLinksNode node = header.Down; node != header; node = node.Down)
            {
                solution.Add(node.RowID);
                for (DancingLinksNode tmp = node.Right; tmp != node; tmp = tmp.Right)
                    Cover(tmp);

                if (Search(solution))
                    return true;

                solution.RemoveAt(solution.Count - 1);
                for (DancingLinksNode tmp = node.Right; tmp != node; tmp = tmp.Right)
                    Uncover(tmp);
            }
            Uncover(header);

            return false;
        }

        public List<int> Search()
        {
            var solution = new List<int>();

            Search(solution);

            return solution;
        }
    }
}