using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Input.Data.Count(x => IsValid(x)));
        }

        private static bool IsValid(string entry)
        {
            System.Console.WriteLine(entry);

            Regex matcher = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<char>.): (?<password>.+)");

            var match = matcher.Match(entry);

            int min = int.Parse(match.Groups["min"].Value);
            int max = int.Parse(match.Groups["max"].Value);
            string c = match.Groups["char"].Value;
            string password = match.Groups["password"].Value;

            int occurences = password.Count(x => x == c[0]);

            if (occurences >= min && occurences <= max)
            {
                return true;
            }

            return false;

        }
    }
}
