using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RandomFriendlyNameGenerator.Data;

namespace RandomFriendlyNameGenerator.Tests
{
    [TestFixture]
    public class Showcase
    {
        [Test]
        public void GenerateNumberOfWordsSummary()
        {
            var combined = new List<string>();

            combined.AddRange(Adjectives.Values);
            Console.WriteLine($"Adjectives: {Adjectives.Values.Count}");

            combined.AddRange(Nationalities.Values);
            Console.WriteLine($"Nationalities: {Nationalities.Values.Count}");

            combined.AddRange(FemaleFirstNames.Values);
            Console.WriteLine($"FemaleFirstNames: {FemaleFirstNames.Values.Count}");

            combined.AddRange(MaleFirstNames.Values);
            Console.WriteLine($"MaleFirstNames: {MaleFirstNames.Values.Count}");

            combined.AddRange(LastNames.Values);
            Console.WriteLine($"LastNames: {LastNames.Values.Count}");

            combined.AddRange(Animals.Values);
            Console.WriteLine($"Animals: {Animals.Values.Count}");

            combined.AddRange(Nouns.Values);
            Console.WriteLine($"Nouns: {Nouns.Values.Count}");

            combined.AddRange(Professions.Values);
            Console.WriteLine($"Professions: {Professions.Values.Count}");


            var distinct = combined.Distinct();

            Console.WriteLine($"Total of {combined.Count} words. Unique words: {distinct.Count()}");
        }

        [Test]
        public void GenerateCombinationsSummary()
        {
            Console.WriteLine($"Possible first name and last names combinations: {FirstNames.Values.Count * LastNames.Values.Count:N0}");
            Console.WriteLine($"Possible first name, middle name and last names combinations: {FirstNames.Values.Count * FirstNames.Values.Count * LastNames.Values.Count:N0}");

            Console.WriteLine($"Possible first name and adjective combinations: {FirstNames.Values.Count * Adjectives.Values.Count *2:N0}"); //times 2 because it can be BobTheBuilder (BuilderBob) or PeppaPig (Peppa The Pig) naming order
            Console.WriteLine($"Possible first name and animal combinations: {FirstNames.Values.Count * Animals.Values.Count:N0}"); //times 2 because it can be BobTheBuilder (BuilderBob) or PeppaPig (Peppa The Pig) naming order
            Console.WriteLine($"Possible first name and profession combinations: {FirstNames.Values.Count * Professions.Values.Count:N0}"); //times 2 because it can be BobTheBuilder (BuilderBob) or PeppaPig (Peppa The Pig) naming order

            Console.WriteLine($"Possible first name, adjective and animal combinations: {FirstNames.Values.Count * Adjectives.Values.Count * Animals.Values.Count * 2:N0}"); //times 2 because it can be BobTheBuilder (BuilderBob) or PeppaPig (Peppa The Pig) naming order
            Console.WriteLine($"Possible first name, adjective and profession combinations: {FirstNames.Values.Count * Adjectives.Values.Count * Professions.Values.Count * 2:N0}"); //times 2 because it can be BobTheBuilder (BuilderBob) or PeppaPig (Peppa The Pig) naming order

        }

    }
}