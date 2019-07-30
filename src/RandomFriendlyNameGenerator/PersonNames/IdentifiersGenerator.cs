using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomFriendlyNameGenerator.Data;
using RandomFriendlyNameGenerator.RandomIndex;

namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Generates non-human identifier strings
    /// </summary>
    public class IdentifiersGenerator
    {
        internal IdentifiersGenerator(List<string> adjectives, List<string> animals, List<string> firstNames, List<string> nationalities, List<string> nouns, List<string> professions)
        {
            this.adjectives = adjectives;
            this.animals = animals;
            this.firstNames = firstNames;
            this.nationalities = nationalities;
            this.nouns = nouns;
            this.professions = professions;
        }

        internal IdentifiersGenerator()
        {
            this.adjectives = Adjectives.Values;
            this.animals = Animals.Values;
            this.firstNames = FirstNames.Values;
            this.nationalities = Nationalities.Values;
            this.nouns = Nouns.Values;
            this.professions = Professions.Values;
        }

        private readonly IGenerateRandomIndex randomIndex = new RandomBasedGenerator();
        private readonly List<string> adjectives;
        private readonly List<string> animals;
        private readonly List<string> firstNames;
        private readonly List<string> nationalities;
        private readonly List<string> nouns;
        private readonly List<string> professions;

        /// <summary>
        /// Gets the specified components.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <param name="orderStyle">The order style.</param>
        /// <param name="separator">The separator between the words.</param>
        /// <param name="forceSingleLetter">if set to <c>true</c> all words of the result will start with the same letter, e.g. Irena The Idiosyncratic, Tammara The Twinkly or Quintana The Qualified</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">orderStyle - null</exception>
        public string Get(IdentifierComponents components = IdentifierComponents.Adjective | IdentifierComponents.Profession, NameOrderingStyle orderStyle = NameOrderingStyle.BobTheBuilderStyle, string separator = " ", bool forceSingleLetter = false)
        {
            char? forcedSingleLetter = Helpers.GetForcedSingleCharacter(forceSingleLetter, this.randomIndex);
            StringBuilder sb = new StringBuilder();
            switch (orderStyle)
            {
                case NameOrderingStyle.SilentBobStyle:
                    return this.GetSilentBobStyle(components, separator, sb, forcedSingleLetter);
                case NameOrderingStyle.BobTheBuilderStyle:
                    return this.GetBobTheBuilderStyle(components, separator, sb, forcedSingleLetter);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderStyle), orderStyle, null);
            }
        }

        private string GetBobTheBuilderStyle(IdentifierComponents components, string separator, StringBuilder sb, char? forcedSingleLetter)
        {
            if (components.HasFlag(IdentifierComponents.FirstName))
            {
                sb.Append(Helpers.GetToken(this.firstNames, this.randomIndex, forcedSingleLetter) + separator + "The" + separator);
            }

            if (components.HasFlag(IdentifierComponents.Adjective))
            {
                sb.Append(Helpers.GetToken(this.adjectives, this.randomIndex, forcedSingleLetter) + separator);
            }

            if (components.HasFlag(IdentifierComponents.Nationality))
            {
                sb.Append(Helpers.GetToken(this.nationalities, this.randomIndex, forcedSingleLetter) + separator);
            }

            this.GetTheNounPart(components, separator, sb, forcedSingleLetter);

            return sb.ToString().TrimEnd(separator + "The" + separator).TrimEnd(separator);

        }

        private string GetSilentBobStyle(IdentifierComponents components, string separator, StringBuilder sb, char? forcedSingleLetter)
        {
            if (components.HasFlag(IdentifierComponents.Adjective))
            {
                sb.Append(Helpers.GetToken(this.adjectives, this.randomIndex, forcedSingleLetter) + separator);
            }

            if (components.HasFlag(IdentifierComponents.Nationality))
            {
                sb.Append(Helpers.GetToken(this.nationalities, this.randomIndex, forcedSingleLetter) + separator);
            }

            this.GetTheNounPart(components, separator, sb, forcedSingleLetter);

            if (components.HasFlag(IdentifierComponents.FirstName))
            {
                sb.Append(Helpers.GetToken(this.firstNames, this.randomIndex, forcedSingleLetter) + separator);
            }
            return sb.ToString().TrimEnd(separator);

        }

        private void GetTheNounPart(IdentifierComponents components, string separator, StringBuilder sb, char? forcedSingleLetter)
        {
            var combinedNouns = new List<string>();
            
            if (components.HasFlag(IdentifierComponents.Animal))
            {
                combinedNouns.AddRange(this.animals);
            }
             if (components.HasFlag(IdentifierComponents.Noun))
            {
                combinedNouns.AddRange(this.nouns);
            }
             if (components.HasFlag(IdentifierComponents.Profession))
            {
                combinedNouns.AddRange(this.professions);
            }

            if (combinedNouns.Any())
            {
                sb.Append(Helpers.GetToken(combinedNouns, this.randomIndex, forcedSingleLetter) + separator);
            }
        }
    }
}