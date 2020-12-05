using System;
using System.Collections.Generic;
using System.IO;

namespace AoC
{
    public record Passport
    {
        public Passport(List<string> fields)
        {
            foreach (var field in fields)
            {
                string[] parts = field.Split(':');

                switch (parts[0])
                {
                    case "byr": BirthYear = parts[1]; break;
                    case "iyr": IssueYear = parts[1]; break;
                    case "eyr": ExpirationYear = parts[1]; break;
                    case "hgt": Height = parts[1]; break;
                    case "hcl": HairColor = parts[1]; break;
                    case "ecl": EyeColor = parts[1]; break;
                    case "pid": PassportId = parts[1]; break;
                    case "cid": CountryId = parts[1]; break;
                    default:
                        break;
                }
            }
        }

        public string BirthYear { get; }
        public string IssueYear { get; }
        public string ExpirationYear { get; }
        public string Height { get; }
        public string HairColor { get; }
        public string EyeColor { get; }
        public string PassportId { get; }
        public string CountryId { get; }
    }

    public static class PassportParser
    {
        public static IEnumerable<Passport> Parse(string input)
        {
            StringReader rdr = new(input);

            List<string> fields = new();

            string line;
            while ((line = rdr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    yield return new(fields);
                    fields.Clear();
                }

                string[] givenFields = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                fields.AddRange(givenFields);
            }

            if (fields.Count > 0)
            {
                yield return new(fields);
            }
        }
    }
}