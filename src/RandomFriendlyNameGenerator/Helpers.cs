using System;
using System.Collections.Generic;
using System.Linq;
using RandomFriendlyNameGenerator.RandomIndex;

namespace RandomFriendlyNameGenerator
{
    internal static class Helpers
    {
        internal static char? GetForcedSingleCharacter(bool forceSingleLetter, IGenerateRandomIndex generator)
        {
            if (!forceSingleLetter)
            {
                return null;
            }
            else
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                return chars[generator.Get(chars.Length-1)];
            }
        }

        internal static string GetToken(List<string> collection, IGenerateRandomIndex generator, char? forcedSingleLetter )
        {
            if (forcedSingleLetter == null)
            {
                return collection[generator.Get(collection.Count)];
            }
            else
            {
                var subset = collection.Where(x => x.StartsWith(forcedSingleLetter.ToString(),StringComparison.OrdinalIgnoreCase)).ToList();
                if (subset.Count == 0)
                {
                    return collection[generator.Get(collection.Count)];
                }
                return subset[generator.Get(subset.Count-1)];
            }
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