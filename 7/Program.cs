using System;
using System.Diagnostics;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            SelfTest1();
            Part1();
            SelfTest2();
            Part2();
        }

        private static void SelfTest1()
        {
            var bags = BagParser.Parse(Input.TestData1);

            Debug.Assert(bags.Count == 9);
            Debug.Assert(bags["shiny gold"].ContainsCount.Count == 2);
            Debug.Assert(bags["shiny gold"].ContainsCount["dark olive"] == 1);
            Debug.Assert(bags["shiny gold"].ContainsCount["vibrant plum"] == 2);

            Debug.Assert(BagSolution.GetCount(bags, "shiny gold") == 4);
        }

        private static void Part1()
        {
            var bags = BagParser.Parse(Input.Data);

            Console.WriteLine(BagSolution.GetCount(bags, "shiny gold"));
        }

        private static void SelfTest2()
        {
            var bags = BagParser.Parse(Input.TestData2);

            Debug.Assert(bags.Count == 7);
            Debug.Assert(bags["shiny gold"].ContainsCount.Count == 1);
            Debug.Assert(bags["shiny gold"].ContainsCount["dark red"] == 2);

            Debug.Assert(BagSolution.GetContainingBags(bags, "shiny gold") == 126);
        }

        private static void Part2()
        {
            var bags = BagParser.Parse(Input.Data);

            Console.WriteLine(BagSolution.GetContainingBags(bags, "shiny gold"));
        }
    }
}
