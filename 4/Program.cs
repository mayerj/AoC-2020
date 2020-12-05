using System;
using System.Linq;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            SelfTest();
            Part1();
        }

        private static void SelfTest()
        {
            var passports = PassportParser.Parse(Input.TestData);

            static bool IsValid(Passport passport)
            {
                return new[] { passport.BirthYear, passport.ExpirationYear, passport.EyeColor, passport.HairColor, passport.Height, passport.IssueYear, passport.PassportId }.All(x => !string.IsNullOrWhiteSpace(x));
            }

            System.Console.WriteLine(passports.Count(IsValid));
        }

        private static void Part1()
        {
            var passports = PassportParser.Parse(Input.Data);

            static bool IsValid(Passport passport)
            {
                return new[] { passport.BirthYear, passport.ExpirationYear, passport.EyeColor, passport.HairColor, passport.Height, passport.IssueYear, passport.PassportId }.All(x => !string.IsNullOrWhiteSpace(x));
            }

            System.Console.WriteLine(passports.Count(IsValid));
        }
    }
}
