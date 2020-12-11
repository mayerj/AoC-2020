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
        }

        private static void Part1()
        {
            var groups = GroupParser.Parse(Input.Data);

            Console.WriteLine(groups.Sum(x => x.Persons.SelectMany(y => y.Responses).ToHashSet().Count));
        }
    }
}
