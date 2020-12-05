using System;
using System.Linq;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new(Input.Grid);

            Console.WriteLine(ComputeTreeCount(map, new(3, 1)));
            Part2(map);
        }

        private static void Part2(Map map)
        {
            var toCheck = new Vector[] { new(1, 1), new(3, 1), new(5, 1), new(7, 1), new(1, 2) };

            Console.WriteLine(toCheck.Select(x => ComputeTreeCount(map, x)).Aggregate((x, y) => x * y));
        }

        private static int ComputeTreeCount(Map map, Vector slope)
        {
            Point current = new(0, 0);

            int count = 0;
            while (current.Y < map.Height)
            {
                if (map.IsTree(current))
                {
                    count++;
                }

                current = current + slope;
            }
            return count;
        }
    }
}
