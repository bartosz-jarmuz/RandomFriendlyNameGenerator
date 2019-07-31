using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("RandomFriendlyNameGenerator.Tests")]

namespace RandomFriendlyNameGenerator
{
    public static class NameGenerator
    {
        public static PersonNamesGenerator PersonNames { get; } = new PersonNamesGenerator();
        public static IdentifiersGenerator Identifiers { get; } = new IdentifiersGenerator();
    }
}
