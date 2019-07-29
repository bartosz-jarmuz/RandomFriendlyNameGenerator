using System;
using System.Collections.Generic;
using System.Text;
using RandomFriendlyNameGenerator.RandomIndex;

namespace RandomFriendlyNameGenerator
{
    public enum NameGender
    {
        Any,
        Female,
        Male,
    }

    public enum NameComponents
    {
        FirstNameLastName,
        FirstNameMiddleNameLastName,
        FirstNameOnly,
        LastNameOnly,
        LastNameFirstName,
    }

    public class Generator
    {
        private static IGenerateRandomIndex firstPartRandom = new RandomBasedGenerator();
        private static IGenerateRandomIndex secondPartRandom = new RandomBasedGenerator();
        private static IGenerateRandomIndex randomIndex = new RandomBasedGenerator();

        public string GetHumanName(NameGender gender = NameGender.Any, NameComponents components = NameComponents.FirstNameLastName, string separator = " ")
        {
            string firstName = this.GetFirstName(components, this.DetermineGender(gender)) ;
            string lastName = this.GetLastName(components);
            string middleName = this.GetMiddleName(components, this.DetermineGender(gender));
            switch (components)
            {
                case NameComponents.FirstNameLastName:
                    return $"{firstName}{separator}{lastName}";
                case NameComponents.FirstNameMiddleNameLastName:
                    return $"{firstName}{separator}{middleName}{separator}{lastName}";
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

        private string GetMiddleName(NameComponents components, NameGender gender)
        {
            if (components == NameComponents.FirstNameMiddleNameLastName)
            {
                return GetName(gender);
            }

            return "";
        }

        private NameGender DetermineGender(NameGender gender)
        {
            if (gender != NameGender.Any)
            {
                return gender;
            }
            else
            {
                var diceRoll = randomIndex.Get(2);
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

        private string GetFirstName(NameComponents components, NameGender gender)
        {
            if (components != NameComponents.LastNameOnly)
            {
                return GetName(gender);
            }

            return "";
        }

        private static string GetName(NameGender gender)
        {
            switch (gender)
            {
                case NameGender.Any:
                    return $"{GetToken(FirstNames.Values, firstPartRandom)}";
                case NameGender.Female:
                    return $"{GetToken(FemaleFirstNames.Values, firstPartRandom)}";
                case NameGender.Male:
                    return $"{GetToken(MaleFirstNames.Values, firstPartRandom)}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(gender), gender, null);
            }
        }

        private string GetLastName(NameComponents components)
        {
            if (components != NameComponents.FirstNameOnly)
            {
                return GetToken(LastNames.Values, randomIndex);
            }

            return "";
        }

        private static string GetToken(List<string> collection, IGenerateRandomIndex generator)
        {
            return collection[generator.Get(collection.Count)];
        }
    }
}
