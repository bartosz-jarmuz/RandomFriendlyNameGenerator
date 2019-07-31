using System;
using System.Collections.Generic;
using RandomFriendlyNameGenerator.Data;
using RandomFriendlyNameGenerator.RandomIndex;

namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Generates human-like names based on random first names and last names combinations from all countries.
    /// </summary>
    public class PersonNamesGenerator
    {
        private readonly IGenerateRandomIndex randomIndex = new RandomBasedGenerator();

        internal PersonNamesGenerator()
        {
            this.femaleFirstNames = FemaleFirstNames.Values;
            this.maleFirstNames = MaleFirstNames.Values;
            this.allFirstNames = FirstNames.Values;
            this.lastNames = LastNames.Values;
        }

        private readonly List<string> femaleFirstNames;
        private readonly List<string> maleFirstNames;
        private readonly List<string> allFirstNames;
        private readonly List<string> lastNames;

        /// <summary>
        /// Gets an IEnumerable of random name based on the specified settings.
        /// <para>Enumerating the same result set multiple times will yield different results</para>
        /// </summary>
        /// <param name="numberOfNamesToReturn"></param>
        /// <param name="gender">The gender.</param>
        /// <param name="components">The components.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="forceSingleLetter">if set to <c>true</c> [force single letter].</param>
        /// <param name="lengthRestriction">Maximum number of characters in the returned string</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">components - null</exception>
        public IEnumerable<string> Get(int numberOfNamesToReturn, NameGender gender = NameGender.Any,
            NameComponents components = NameComponents.FirstNameLastName, string separator = " ",
            bool forceSingleLetter = false, int lengthRestriction = 0)
        {
            for (int i = 0; i < numberOfNamesToReturn; i++)
            {
                yield return this.Get(gender, components, separator, forceSingleLetter, lengthRestriction);
            }
        }

        /// <summary>
        /// Gets a random name based on the specified settings
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <param name="components">The components.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="forceSingleLetter">if set to <c>true</c> [force single letter].</param>
        /// <param name="lengthRestriction">Maximum number of characters in the returned string</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">components - null</exception>
        public string Get(NameGender gender = NameGender.Any,
            NameComponents components = NameComponents.FirstNameLastName, string separator = " ",
            bool forceSingleLetter = false, int lengthRestriction = 0)
        {
            char? forcedSingleLetter = Helpers.GetForcedSingleCharacter(forceSingleLetter, this.randomIndex);
            gender = this.DetermineGender(gender);
            int attempt = 0;

            while (true) //if there is a length restriction, retry a couple of times. If the string is still too long, just trim it
            {
                attempt++;
                var name = this.Get(gender, components, separator, forcedSingleLetter);
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

        private string Get(NameGender gender, NameComponents components, string separator, char? forcedSingleLetter)
        {

            string firstName = components != NameComponents.LastNameOnly
                ? this.GetName(gender, forcedSingleLetter)
                : "";
            string lastName = components != NameComponents.FirstNameOnly
                ? Helpers.GetToken(this.lastNames, this.randomIndex, forcedSingleLetter)
                : "";
            string middleName = components == NameComponents.FirstNameMiddleNameLastName
                ? this.GetName(gender, forcedSingleLetter)
                : "";

            switch (components)
            {
                case NameComponents.FirstNameLastName:
                    return  $"{firstName}{separator}{lastName}";
                case NameComponents.FirstNameMiddleNameLastName:
                    return  $"{firstName}{separator}{middleName}{separator}{lastName}";
                case NameComponents.FirstNameOnly:
                    return firstName;
                case NameComponents.LastNameOnly:
                    return lastName;
                case NameComponents.LastNameFirstName:
                    return $"{lastName}{separator}{firstName}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(components), components, null);
            }
        }

        private NameGender DetermineGender(NameGender gender)
        {
            if (gender != NameGender.Any)
            {
                return gender;
            }
            else
            {
                var diceRoll = this.randomIndex.Get(2);
                if (diceRoll == 0)
                {
                    return NameGender.Female;
                }
                else
                {
                    return NameGender.Male;
                }
            }
        }

        private string GetName(NameGender gender, char? forcedSingleLetter)
        {
            switch (gender)
            {
                case NameGender.Any:
                    return $"{Helpers.GetToken(this.allFirstNames, this.randomIndex, forcedSingleLetter)}";
                case NameGender.Female:
                    return $"{Helpers.GetToken(this.femaleFirstNames, this.randomIndex, forcedSingleLetter)}";
                case NameGender.Male:
                    return $"{Helpers.GetToken(this.maleFirstNames, this.randomIndex, forcedSingleLetter)}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(gender), gender, null);
            }
        }
    }
}