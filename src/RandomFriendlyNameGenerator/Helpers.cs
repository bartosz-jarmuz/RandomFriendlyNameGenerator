using System;
using System.Collections.Generic;
using RandomFriendlyNameGenerator.RandomIndex;

namespace RandomFriendlyNameGenerator
{
    internal static class Helpers
    {
        internal static string GetToken(List<string> collection, IGenerateRandomIndex generator)
        {
            return collection[generator.Get(collection.Count)];
        }

        public static string TrimEnd(this string input, string suffixToRemove, StringComparison comparisonType = StringComparison.Ordinal)
        {

            if (input != null && suffixToRemove != null && input.EndsWith(suffixToRemove, comparisonType))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }

            return input;
        }

    }
}