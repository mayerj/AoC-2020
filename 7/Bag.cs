using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC
{
    public record Bag(string BagColor, bool IsEmpty, Dictionary<string, int> ContainsCount);

    public static class BagSolution
    {
        public static int GetCount(Dictionary<string, Bag> bags, string given)
        {
            HashSet<string> totalParents = new();

            HashSet<string> alreadyChecked = new();
            Queue<string> toCheck = new();
            toCheck.Enqueue(given);

            while (toCheck.Count != 0)
            {
                string current = toCheck.Dequeue();

                var parents = GetParentBags(bags, current);

                totalParents.UnionWith(parents);

                foreach (string bag in parents)
                {
                    if (!alreadyChecked.Add(bag))
                    {
                        continue;
                    }

                    toCheck.Enqueue(bag);
                }
            }

            return totalParents.Count;
        }

        private static HashSet<string> GetParentBags(Dictionary<string, Bag> bags, string given)
        {
            return bags.Values.Where(x => x.ContainsCount.ContainsKey(given)).Select(x => x.BagColor).ToHashSet();
        }
    }

    public static class BagParser
    {
        public static Dictionary<string, Bag> Parse(string input)
        {
            Dictionary<string, Bag> result = new();

            Regex parser = new(@"(?<color>.+) (?<bags>bags) contain ((?<none>no other bags)|(?<data>.+))");
            Regex countParser = new(@"(?<count>\d+) (?<color>.+) bags*");

            foreach (string line in input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var match = parser.Match(line);
                Debug.Assert(match.Success);
                Debug.Assert(match.Groups["color"].Success);
                Debug.Assert(match.Groups["none"].Success || match.Groups["data"].Success);

                string bagColor = match.Groups["color"].Value;

                bool isEmpty = match.Groups["none"].Success;

                string other = match.Groups["data"].Value;

                Dictionary<string, int> containsCount = new();
                if (!isEmpty)
                {
                    foreach (string subbag in other.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        var countMatch = countParser.Match(subbag);
                        Debug.Assert(countMatch.Success);

                        containsCount[countMatch.Groups["color"].Value.Trim()] = int.Parse(countMatch.Groups["count"].Value);
                    }
                }

                result[bagColor] = new Bag(bagColor, isEmpty, containsCount);
            }

            return result;
        }
    }
}