using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomFriendlyNameGenerator
{
    static class FirstNames
    {
        public static readonly List<string> Values =
            new List<string>(MaleFirstNames.Values.Concat(FemaleFirstNames.Values));
    }
}
