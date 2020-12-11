using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var groups = GroupParser.Parse(Input.Data);

            Console.WriteLine(groups.Sum(x => x.Persons.SelectMany(y => y.Responses).ToHashSet().Count));
        }

        private static void Part2()
        {
            var groups = GroupParser.Parse(Input.Data);

            Console.WriteLine(groups.Sum(x => x.Persons.Select(x => x.Responses).Aggregate((x, y) =>
            {
                var v = new HashSet<char>(x);
                v.IntersectWith(y);
                return v;
            }).Count));
        }
    }
}
