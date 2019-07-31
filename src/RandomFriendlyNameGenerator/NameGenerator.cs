using System.Runtime.CompilerServices;
using System.Text;

namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Simple but flexible and powerful utility for generating random names
    /// <para>- human like, e.g. Jim Deam, Constance Calaxa, Rick Abraham Hoferle, Betsey Bataller</para>
    /// <para>- or identifiers, like Sympathetic_Alligator, Dusty Doctor, Undetected_Noodle, Electrifying Minister</para>
    /// <para>- or anything in between, with configurable number of components, separators, length and structure</para>
    /// <para>like Bob_The_Builder, Well-dressed-Entertainer, Medium-rare SeaTurtle Eldon, RoannaTheJoblessComputer</para>
    /// </summary>
    public static class NameGenerator
    {
        /// <summary>
        /// Gets the real person names like Constance Calaxa, Rick Abraham Hoferle etc
        /// </summary>
        /// <value>The person names.</value>
        public static PersonNamesGenerator PersonNames { get; } = new PersonNamesGenerator();

        /// <summary>
        /// Gets the identifiers, like Sympathetic_Alligator, Medium-rare SeaTurtle Eldon, Undetected_Noodle, RoannaTheJoblessComputer
        /// </summary>
        /// <value>The identifiers.</value>
        public static IdentifiersGenerator Identifiers { get; } = new IdentifiersGenerator();
    }
}
