using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC
{
    class Program
    {
        private static (int n1, int n2, char c, string password) Parse(string entry)
        {

            Regex matcher = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<char>.): (?<password>.+)");

            var match = matcher.Match(entry);

            int min = int.Parse(match.Groups["min"].Value);
            int max = int.Parse(match.Groups["max"].Value);
            string c = match.Groups["char"].Value;
            string password = match.Groups["password"].Value;

            return (min, max, c[0], password);
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(Input.Data.Count(x => IsValidPart1(x)));
            System.Console.WriteLine(Input.Data.Count(x => IsValidPart2(x)));
        }

        private static bool IsValidPart1(string entry)
        {
            (int min, int max, char c, string password) = Parse(entry);

            int occurences = password.Count(x => x == c);

            if (occurences >= min && occurences <= max)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidPart2(string entry)
        {
            (int pos1, int pos2, char c, string password) = Parse(entry);

            bool isPos1 = password[pos1 - 1] == c;
            bool isPos2 = password[pos2 - 1] == c;

            if (isPos1 == isPos2)
            {
                return false;
            }

            return true;
        }
    }
}
