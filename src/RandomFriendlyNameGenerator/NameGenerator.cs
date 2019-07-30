using System.Collections.Generic;
using System.Text;
using RandomFriendlyNameGenerator.RandomIndex;

namespace RandomFriendlyNameGenerator
{
    public static class NameGenerator
    {
        public static PersonNames PersonNames { get; } = new PersonNames();

        internal static string GetToken(List<string> collection, IGenerateRandomIndex generator)
        {
            return collection[generator.Get(collection.Count)];
        }
    }
}
