using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RandomFriendlyNameGenerator.Tests
{
    [TestFixture]
    public class LengthTests
    {
        List<string> names = new List<string>() {"Helga"};
        List<string> animals = new List<string>() {"MountainGoat"};
        List<string> adjectives = new List<string>() {"Sophisticated"};
        List<string> professions = new List<string>() {"Baker"};
        List<string> nouns = new List<string>() {"Toothpick"};
        List<string> nationalities = new List<string>() {"Albanian"};

        [Test]
        public void TestPersonNamesLengthRestriction()
        {
            int restriction = 10;
            var names = NameGenerator.PersonNames.Get(1000, lengthRestriction: restriction);

            foreach (string name in names)
            {
                Console.WriteLine(name);
                Assert.That(name.Length <= restriction && name.Length > 1, $"{name} - invalid length: {name.Length}");
            }
        }

        [Test]
        public void TestIdentifiersLengthRestriction()
        {
            int restriction = 12;
            var names = NameGenerator.Identifiers.Get(1000, lengthRestriction: restriction);

            foreach (string name in names)
            {
                Console.WriteLine(name);
                Assert.That(name.Length <= restriction && name.Length > 1, $"{name} - invalid length: {name.Length}");
            }
        }
    }
}