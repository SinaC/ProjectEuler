using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler
{
    public class Problem61 : ProblemBase
    {
        public Problem61() : base(61)
        {
        }

        public override string Solve()
        {
            const ulong lowerBound = 1000; // 4 digits
            const ulong upperBound = 9999; // 4 digits

            List<ulong> triangles = BuildPolygonalList(lowerBound, upperBound, Tools.Tools.TriangleIndex, Tools.Tools.Triangle);
            List<ulong> squares = BuildPolygonalList(lowerBound, upperBound, Tools.Tools.SquareIndex, Tools.Tools.Square);
            List<ulong> pentagonals = BuildPolygonalList(lowerBound, upperBound, Tools.Tools.PentagonalIndex, Tools.Tools.Pentagonal);
            List<ulong> hexagonals = BuildPolygonalList(lowerBound, upperBound, Tools.Tools.HexagonalIndex, Tools.Tools.Hexagonal);
            List<ulong> heptagonals = BuildPolygonalList(lowerBound, upperBound, Tools.Tools.HeptagonalIndex, Tools.Tools.Heptagonal);
            List<ulong> octogonals = BuildPolygonalList(lowerBound, upperBound, Tools.Tools.OctogonalIndex, Tools.Tools.Octogonal);

            // abcd -> cdef -> efgh -> ghij -> ijkl -> klab
            // loop among octogonals ==> abcd
            // search in other collections for cdef
            // search in other collections for efgh
            // search in other collections for ghij
            // search in other collections for ijkl
            // search in last collection for klab
            ulong sum = 0;
            foreach (ulong octogonal in octogonals)
            {
                //Console.WriteLine("======");
                List<List<ulong>> collectionsLeft = new List<List<ulong>>(new [] { heptagonals, hexagonals, pentagonals, squares, triangles });
                ulong[] items = new ulong[collectionsLeft.Count + 1];
                items[0] = octogonal;
                bool fFound = Sub(octogonal, collectionsLeft, octogonal/*, 1*/, ref items);
                if (fFound)
                {
                    //foreach (ulong item in items)
                    //{
                    //    //Console.Write(item + "->");
                    //    sum += item;
                    //}
                    sum = items.Aggregate(sum, (current, item) => current + item);
                    break;
                }
            }
            return sum.ToString(CultureInfo.InvariantCulture);
        }

        private static List<ulong> BuildPolygonalList(ulong lowerBound, ulong upperBound, Func<ulong, double> getIndexFunc, Func<ulong, ulong> getPolygonalFunc)
        {
            List<ulong> list = new List<ulong>();
            ulong lowerLimit = (ulong)getIndexFunc(lowerBound);
            ulong upperLimit = (ulong)Math.Ceiling(getIndexFunc(upperBound));
            for (ulong i = lowerLimit; i <= upperLimit; i++)
            {
                ulong number = getPolygonalFunc(i);
                if (number > upperBound)
                    break;
                if (number >= lowerBound)
                    list.Add(number);
            }

            return list;
        }

        private static bool Sub(ulong number, IReadOnlyCollection<List<ulong>> collectionsLeft, ulong startItem/*, ulong depth*/, ref ulong[] items)
        {
            bool fStop = false;
            foreach (List<ulong> collection in collectionsLeft)
            {
                foreach (ulong polygonal in collection)
                {
                    if ((number % 100) == (polygonal / 100))
                    { // 2 last matches 2 first
                        items[items.Length - collectionsLeft.Count] = polygonal;
                        //Console.WriteLine("".PadLeft((int)(depth*3)) + " " + number+"-->"+polygonal+"["+collection.Count+"]");
                        if (collectionsLeft.Count == 1 && (polygonal % 100) == (startItem / 100))
                        {  // 2 last matches 2 first
                            fStop = true;
                            break;
                        }
                        List<List<ulong>> left = collectionsLeft.Where(c => c != collection).ToList();
                        fStop = Sub(polygonal, left, startItem/*, depth + 1*/, ref items);
                        if (fStop)
                            break;
                    }
                }
                if (fStop)
                    break;
            }
            return fStop;
        }
    }
}
