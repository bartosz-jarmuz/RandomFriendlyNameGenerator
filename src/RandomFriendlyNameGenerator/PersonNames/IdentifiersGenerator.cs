using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private const NameOrderingStyle DefaultOrderStyle = NameOrderingStyle.SilentBobStyle;

        private readonly IGenerateRandomIndex randomIndex = new RandomBasedGenerator();
        private readonly List<string> adjectives;
        private readonly List<string> animals;
        private readonly List<string> firstNames;
        private readonly List<string> nationalities;
        private readonly List<string> nouns;
        private readonly List<string> professions;

        public string Get(IdentifierTemplate template, NameOrderingStyle order = DefaultOrderStyle, string separator = " ", bool forceSingleLetter = false, int lengthRestriction = 0)
        {
            
            switch (template)
            {
                case IdentifierTemplate.AnyTwoComponents:
                    return this.GetRandomTwo(order, separator, forceSingleLetter, lengthRestriction);
                case IdentifierTemplate.AnyThreeComponents:
                    return this.Get(this.GetRandomAdjective() | this.GetRandomNoun() | IdentifierComponents.FirstName, order, separator, forceSingleLetter, lengthRestriction);
                case IdentifierTemplate.BobTheBuilder:
                    return this.Get(IdentifierComponents.Profession| IdentifierComponents.FirstName, order, separator, forceSingleLetter, lengthRestriction);
                case IdentifierTemplate.PeppaPig:
                    return this.Get(IdentifierComponents.Animal| IdentifierComponents.FirstName, order, separator, forceSingleLetter, lengthRestriction);
                case IdentifierTemplate.SilentBob:
                    return this.Get(IdentifierComponents.Adjective | IdentifierComponents.FirstName, order, separator, forceSingleLetter, lengthRestriction);
                case IdentifierTemplate.GitHub:
                    return this.Get(IdentifierComponents.Adjective | IdentifierComponents.Noun, order, separator, forceSingleLetter, lengthRestriction);
                default:
                    throw new ArgumentOutOfRangeException(nameof(template), template, null);
            } 
        }

        private string GetRandomTwo(NameOrderingStyle order, string separator = " ", bool forceSingleLetter = false, int lengthRestriction = 0)
        {
            var setNumber = this.randomIndex.Get(3);
            
            switch (setNumber)
            {
                case 0:
                    return this.Get(this.GetRandomNoun() | IdentifierComponents.FirstName, order, separator, forceSingleLetter, lengthRestriction);
                case 1:
                    return this.Get(this.GetRandomAdjective()| IdentifierComponents.FirstName, order, separator, forceSingleLetter, lengthRestriction);
                case 2:
                    return this.Get(this.GetRandomAdjective() | this.GetRandomNoun(), order, separator, forceSingleLetter, lengthRestriction);
                default:
                    return this.Get(this.GetRandomAdjective() | this.GetRandomNoun(), order, separator, forceSingleLetter, lengthRestriction);
            }
        }

        private string GetRandomThree(NameOrderingStyle order, string separator = " ", bool forceSingleLetter = false, int lengthRestriction = 0)
        {
            var setNumber = this.randomIndex.Get(3);

            switch (setNumber)
            {
                case 0:
                case 1:
                    return this.Get(this.GetRandomAdjective() | IdentifierComponents.FirstName, order, separator, forceSingleLetter, lengthRestriction);
                case 2:
                    return this.Get(this.GetRandomAdjective() | this.GetRandomNoun(), order, separator, forceSingleLetter, lengthRestriction);
                default:
                    return this.Get(this.GetRandomAdjective() | this.GetRandomNoun(), order, separator, forceSingleLetter, lengthRestriction);
            }
        }

        private IdentifierComponents GetRandomAdjective()
        {
            var adjectiveOption = this.randomIndex.Get(2);


            switch (adjectiveOption)
            {
                case 0:
                    return IdentifierComponents.Adjective;
                case 1:
                    return IdentifierComponents.Nationality;
                default:
                    return IdentifierComponents.Adjective;
            }

        }

        private IdentifierComponents GetRandomNoun()
        {
            var nounOption = this.randomIndex.Get(3);

            switch (nounOption)
            {
                case 0:
                    return IdentifierComponents.Profession;
                case 1:
                    return IdentifierComponents.Animal;
                case 2:
                    return IdentifierComponents.Noun;
                default:
                    return IdentifierComponents.Noun;
            }
        }

        /// <summary>
        /// Gets an IEnumerable of random identifiers based on the settings
        /// <para>Bear in mind that enumerating the result set multiple times will yield different results</para>
        /// </summary>
        /// <param name="numberOfNamesToReturn">How many outputs to get</param>
        /// <param name="components">The components.</param>
        /// <param name="orderStyle">The order style.</param>
        /// <param name="separator">The separator between the words.</param>
        /// <param name="forceSingleLetter">if set to <c>true</c> all words of the result will start with the same letter, e.g. Irena The Idiosyncratic, Tammara The Twinkly or Quintana The Qualified</param>
        /// <param name="lengthRestriction">Maximum number of characters in the returned string</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">orderStyle - null</exception>
        public IEnumerable<string> Get(int numberOfNamesToReturn, IdentifierComponents components = IdentifierComponents.Adjective | IdentifierComponents.Profession, NameOrderingStyle orderStyle = DefaultOrderStyle, string separator = " ", bool forceSingleLetter = false, int lengthRestriction = 0)
        {
            for (int i = 0; i < numberOfNamesToReturn; i++)
            {
                yield return this.Get(components, orderStyle, separator, forceSingleLetter, lengthRestriction);
            }
        }

        /// <summary>
        /// Gets a random identifier based on the settings
        /// </summary>
        /// <param name="components">The components.</param>
        /// <param name="orderStyle">The order style.</param>
        /// <param name="separator">The separator between the words.</param>
        /// <param name="forceSingleLetter">if set to <c>true</c> all words of the result will start with the same letter, e.g. Irena The Idiosyncratic, Tammara The Twinkly or Quintana The Qualified</param>
        /// <param name="lengthRestriction">Maximum number of characters in the returned string</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">orderStyle - null</exception>
        public string Get(IdentifierComponents components = IdentifierComponents.Adjective | IdentifierComponents.Profession, NameOrderingStyle orderStyle = DefaultOrderStyle, string separator = " ", bool forceSingleLetter = false, int lengthRestriction = 0)
        {
            char? forcedSingleLetter = Helpers.GetForcedSingleCharacter(forceSingleLetter, this.randomIndex);
            int attempt = 0;

            while (true) //if there is a length restriction, retry a couple of times. If the string is still too long, just trim it
            {
                attempt++;
                var name = this.Get(components, orderStyle, separator, forcedSingleLetter);
                if (lengthRestriction <= 0)
                {
                    return name;
                }
                else if (name.Length <= lengthRestriction)
                {
                    return name;
                }

                if (attempt >= 100)
                {
                    return name.Remove(lengthRestriction);
                }
            }
        }

        private string Get(IdentifierComponents components ,NameOrderingStyle orderStyle,string separator,char? forcedSingleLetter)
        {
            StringBuilder sb = new StringBuilder();
            switch (orderStyle)
            {
                case NameOrderingStyle.SilentBobStyle:
                    return this.GetSilentBobOrder(components, separator, sb, forcedSingleLetter);
                case NameOrderingStyle.BobTheBuilderStyle:
                    return this.GetBobTheBuilderOrder(components, separator, sb, forcedSingleLetter);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderStyle), orderStyle, null);
            }
        }

        private string GetBobTheBuilderOrder(IdentifierComponents components, string separator, StringBuilder sb, char? forcedSingleLetter)
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

        private string GetSilentBobOrder(IdentifierComponents components, string separator, StringBuilder sb, char? forcedSingleLetter)
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