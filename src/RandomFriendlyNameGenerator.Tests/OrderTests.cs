using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace RandomFriendlyNameGenerator.Tests
{

    [TestFixture]
    public class OrderTests
    {
        List<string> names = new List<string>(){"Helga"};
        List<string> animals = new List<string>(){"MountainGoat"};
        List<string> adjectives = new List<string>(){"Sophisticated"};
        List<string> professions = new List<string>(){"Baker"};
        List<string> nouns = new List<string>(){"Toothpick"};
        List<string> nationalities = new List<string>(){"Albanian"};


        [Test]
        public void  TestBobTheBuilderStyle()
        {
            var generator = new IdentifiersGenerator(this.adjectives, this.animals, this.names, this.nationalities, this.nouns, this.professions);

            Assert.AreEqual("Helga", generator.Get(IdentifierComponents.FirstName , NameOrderingStyle.BobTheBuilderStyle));
            Assert.AreEqual("Helga The Toothpick", generator.Get(IdentifierComponents.FirstName | IdentifierComponents.Noun, NameOrderingStyle.BobTheBuilderStyle));
            Assert.AreEqual("Helga The MountainGoat", generator.Get(IdentifierComponents.FirstName | IdentifierComponents.Animal, NameOrderingStyle.BobTheBuilderStyle));
            Assert.AreEqual("Helga The Sophisticated MountainGoat", generator.Get(IdentifierComponents.Adjective | IdentifierComponents.FirstName | IdentifierComponents.Animal, NameOrderingStyle.BobTheBuilderStyle));
            Assert.AreEqual("Helga The Sophisticated Albanian MountainGoat", generator.Get(IdentifierComponents.Adjective | IdentifierComponents.Nationality | IdentifierComponents.FirstName | IdentifierComponents.Animal, NameOrderingStyle.BobTheBuilderStyle));
        }

        [Test]
        public void TestSilentBobStyle()
        {
            var generator = new IdentifiersGenerator(this.adjectives, this.animals, this.names, this.nationalities, this.nouns, this.professions);

            Assert.AreEqual("Helga", generator.Get(IdentifierComponents.FirstName, NameOrderingStyle.SilentBobStyle));
            Assert.AreEqual("Toothpick Helga", generator.Get(IdentifierComponents.FirstName | IdentifierComponents.Noun, NameOrderingStyle.SilentBobStyle));
            Assert.AreEqual("MountainGoat Helga", generator.Get(IdentifierComponents.FirstName | IdentifierComponents.Animal, NameOrderingStyle.SilentBobStyle));
            Assert.AreEqual("Sophisticated MountainGoat Helga", generator.Get(IdentifierComponents.Adjective | IdentifierComponents.FirstName | IdentifierComponents.Animal, NameOrderingStyle.SilentBobStyle));
            Assert.AreEqual("Sophisticated Albanian MountainGoat Helga", generator.Get(IdentifierComponents.Adjective | IdentifierComponents.Nationality |IdentifierComponents.FirstName | IdentifierComponents.Animal, NameOrderingStyle.SilentBobStyle));
        }

        [Test]
        public void TestVariousPossibleNouns()
        {
            var generator = new IdentifiersGenerator(this.adjectives, this.animals, this.names, this.nationalities, this.nouns, this.professions);
            bool nounDone = false;
            bool professionDone = false;
            bool animalDone = false;
            for (int i = 0; i < 1000; i++)
            {
                var result = generator.Get(
                    IdentifierComponents.Adjective | IdentifierComponents.Nationality | IdentifierComponents.FirstName |
                    IdentifierComponents.Profession | IdentifierComponents.Noun | IdentifierComponents.Animal,
                    NameOrderingStyle.SilentBobStyle);
                if (result == "Sophisticated Albanian MountainGoat Helga")
                {
                    animalDone = true;
                }
                else if (result == "Sophisticated Albanian Toothpick Helga")
                {
                    nounDone = true;
                }
                else if (result == "Sophisticated Albanian Baker Helga")
                {
                    professionDone = true;
                }

                if (nounDone && professionDone && animalDone)
                {
                    return;
                }
            }
            Assert.Fail($"Noun: {nounDone}. Profession: {professionDone}. Animal {animalDone}");
            
        }
    }
}