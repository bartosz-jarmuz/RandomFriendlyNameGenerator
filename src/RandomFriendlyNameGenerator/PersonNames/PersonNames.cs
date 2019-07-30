using System;
using RandomFriendlyNameGenerator.Data;
using RandomFriendlyNameGenerator.RandomIndex;

namespace RandomFriendlyNameGenerator
{
    public class PersonNames
    {
        private readonly IGenerateRandomIndex randomIndex = new RandomBasedGenerator();

        public string Get(NameGender gender = NameGender.Any, NameComponents components = NameComponents.FirstNameLastName, string separator = " ")
        {
            string firstName = this.GetFirstName(components, this.DetermineGender(gender));
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
                return this.GetName(gender);
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

        private string GetFirstName(NameComponents components, NameGender gender)
        {
            if (components != NameComponents.LastNameOnly)
            {
                return this.GetName(gender);
            }

            return "";
        }

        private string GetName(NameGender gender)
        {
            switch (gender)
            {
                case NameGender.Any:
                    return $"{NameGenerator.GetToken(FirstNames.Values, this.randomIndex)}";
                case NameGender.Female:
                    return $"{NameGenerator.GetToken(FemaleFirstNames.Values, this.randomIndex)}";
                case NameGender.Male:
                    return $"{NameGenerator.GetToken(MaleFirstNames.Values, this.randomIndex)}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(gender), gender, null);
            }
        }

        private string GetLastName(NameComponents components)
        {
            if (components != NameComponents.FirstNameOnly)
            {
                return NameGenerator.GetToken(LastNames.Values, this.randomIndex);
            }

            return "";
        }
    }
}