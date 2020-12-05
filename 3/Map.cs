using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{

    public record Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);

        public static Point operator +(Point p, Vector vector)
        {
            return new(p.X + vector.Dx, p.Y + vector.Dy);
        }
    }

    public record Vector
    {
        public int Dx { get; }
        public int Dy { get; }

        public Vector(int dx, int dy) => (Dx, Dy) = (dx, dy);
    }

    public class Map
    {
        private readonly char[][] _map;
        public Map(char[][] grid)
        {
            _map = grid;
        }

        public int Height => _map.Length;

        public bool IsTree(Point point)
        {
            return _map[point.Y][point.X % _map[point.Y].Length] == '#';
        }
    }
}
