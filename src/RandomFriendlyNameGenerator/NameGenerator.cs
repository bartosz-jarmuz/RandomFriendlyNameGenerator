using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("RandomFriendlyNameGenerator.Tests")]

namespace RandomFriendlyNameGenerator
{
    public static class NameGenerator
    {
        public static PersonNames PersonNames { get; } = new PersonNames();
        public static IdentifiersGenerator Identifiers { get; } = new IdentifiersGenerator();

      

    }
}
