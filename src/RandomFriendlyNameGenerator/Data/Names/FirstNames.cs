using System.Collections.Generic;
using System.Linq;

namespace RandomFriendlyNameGenerator.Data
{
    /// <summary>
    /// Class FirstNames.
    /// </summary>
    public static class FirstNames
    {
        /// <summary>
        /// The values
        /// </summary>
        public static readonly List<string> Values =
            new List<string>(MaleFirstNames.Values.Concat(FemaleFirstNames.Values));
    }
}
