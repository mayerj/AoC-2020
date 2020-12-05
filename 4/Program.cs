using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            SelfTest();
            Part1();
            Part2();
        }
        private static bool Part1Validity(Passport passport)
        {
            return new[] { passport.BirthYear, passport.ExpirationYear, passport.EyeColor, passport.HairColor, passport.Height, passport.IssueYear, passport.PassportId }.All(x => !string.IsNullOrWhiteSpace(x));
        }

        private static void SelfTest()
        {
            Run(nameof(SelfTest), Input.TestData, Part1Validity);
        }

        private static void Run(string part, string input, Func<Passport, bool> isValid)
        {
            var passports = PassportParser.Parse(input);

            System.Console.WriteLine($"{part} {passports.Count(isValid)}");
        }

        private static void Part1()
        {
            Run(nameof(Part1), Input.Data, Part1Validity);
        }

        private static void Part2()
        {
            Run(nameof(Part2), Input.Data, Part2Validity);
        }

        private static bool Part2Validity(Passport passport)
        {
            if (!Part1Validity(passport)) return false;

            static bool ValidateYear(string year, int minimum, int maximum)
            {
                if (!int.TryParse(year, out var yearNumber))
                {
                    return false;
                }

                return yearNumber >= minimum && yearNumber <= maximum;
            }

            static bool ValidateHeight(string height, params (string unit, int min, int max)[] options)
            {
                Regex regex = new(@"(?<num>\d+).+");

                var match = regex.Match(height);
                if (!match.Success)
                {
                    return false;
                }

                string numAsString = match.Groups["num"].Value;

                if (!int.TryParse(numAsString, out var num))
                {
                    return false;
                }

                foreach (var (unit, min, max) in options)
                {
                    if (!height.EndsWith(unit))
                    {
                        continue;
                    }

                    if (num >= min && num <= max)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            static bool ValidateHairColor(string hairColor)
            {
                return hairColor.Length == 7 && hairColor[0] == '#' && hairColor.Skip(1).All(x => (x >= '0' && x <= '9') || (x >= 'a' && x <= 'f'));
            }

            static bool ValidateEyeColor(string eyeColor)
            {
                return eyeColor switch
                {
                    "amb" => true,
                    "blu" => true,
                    "brn" => true,
                    "gry" => true,
                    "grn" => true,
                    "hzl" => true,
                    "oth" => true,
                    _ => false,
                };
            }

            static bool ValidatePassportId(string passportId)
            {
                return passportId.Length == 9 && passportId.All(x => char.IsNumber(x));
            }

            bool[] predicates = new[]
            {
                ValidateYear(passport.BirthYear, 1920, 2002),
                ValidateYear(passport.IssueYear, 2010, 2020),
                ValidateYear(passport.ExpirationYear, 2020, 2030),
                ValidateHeight(passport.Height, ("cm", 150, 193), ("in", 59, 76)),
                ValidateHairColor(passport.HairColor),
                ValidateEyeColor(passport.EyeColor),
                ValidatePassportId(passport.PassportId),
            };

            return predicates.All(x => x);
        }
    }
}
