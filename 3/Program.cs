using System;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new(Input.Grid);
            Point current = new(0, 0);

            Vector slope = new(3, 1);

            int count = 0;
            while (current.Y < map.Height)
            {
                if (map.IsTree(current))
                {
                    count++;
                }

                current = current + slope;
            }

            System.Console.WriteLine(count);

        }
    }
}
