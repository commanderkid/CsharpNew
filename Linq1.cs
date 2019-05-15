ing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp13
{
    class Program
    {
        public static void Main()
        {
            // Функция тестирования ParsePoints

            foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
                Console.WriteLine(point.X + " " + point.Y);
            foreach (var point in ParsePoints(new List<string> { "+01 -0042" }))
                Console.WriteLine(point.X + " " + point.Y);
        }

        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X, Y;
        }

        public static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            List<Point> nlist = lines.
                                Select(x => x.Split(' ').
                                       Select(sx => int.
                                              Parse(sx)).
                                ToArray()).
                                Select(x => new Point(x[0], x[1])).
                                ToList();
            return nlist;
        }

    }
}
