using System;
using System.Collections.Generic;
using System.IO;

namespace AoC
{
    public class Person
    {
        public HashSet<char> Responses { get; init; } = new HashSet<char>();
    }

    public class Group
    {
        public List<Person> Persons { get; init; } = new List<Person>();
    }

    public static class GroupParser
    {
        public static Group[] Parse(string input)
        {
            using StringReader rdr = new StringReader(input);

            Group current = new Group();

            List<Group> groups = new List<Group> { current };

            string line;
            while ((line = rdr.ReadLine()) != null)
            {
                line = line.Trim();

                if (string.IsNullOrEmpty(line))
                {
                    current = null;
                    continue;
                }

                if (current == null)
                {
                    current = new Group();
                    groups.Add(current);
                }

                Person person = new Person()
                {
                    Responses = new HashSet<char>(line.ToCharArray())
                };

                current.Persons.Add(person);
            }

            return groups.ToArray();
        }
    }
}