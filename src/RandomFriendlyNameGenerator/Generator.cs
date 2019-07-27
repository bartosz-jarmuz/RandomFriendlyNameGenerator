using System;
using System.Collections.Generic;
using System.Text;

namespace RandomFriendlyNameGenerator
{
    public class Generator
    {
        private static Random firstPartRandom = new Random();
        private static Random secondPartRandom = new Random();
        private static Random thirdPartRandom = new Random();

        public string GetName()
        {
            return $"{Adjectives.Values[firstPartRandom.Next()]}{FemaleFirstNames.Values[firstPartRandom.Next()]}";
        }
    }
}
