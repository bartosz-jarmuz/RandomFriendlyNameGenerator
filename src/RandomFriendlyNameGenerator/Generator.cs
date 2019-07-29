using System.Collections.Generic;
using System.Text;

namespace RandomFriendlyNameGenerator
{
    public class Generator
    {
        private static IGenerateRandomIndex firstPartRandom = new RandomBasedGenerator();
        private static IGenerateRandomIndex secondPartRandom = new RandomBasedGenerator();
        private static IGenerateRandomIndex thirdPartRandom = new RandomBasedGenerator();

        public string GetName()
        {
            return $"{GetToken(Adjectives.Values, firstPartRandom)}{GetToken(FirstNames.Values, secondPartRandom)}";
        }

        private static string GetToken(List<string> collection, IGenerateRandomIndex generator)
        {
            return collection[generator.Get(collection.Count)];
        }
    }
}
