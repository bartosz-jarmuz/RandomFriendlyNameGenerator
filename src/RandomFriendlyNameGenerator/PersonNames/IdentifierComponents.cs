using System;

namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Determines how many (and which) components should be included in an identifier e.g.: <para/>
    /// <para>AggressiveChinchillaBilly or</para>
    /// <para>SillyChimneySweeper or</para>
    /// <para>FrenchForkSteve etc.</para>
    /// <para>The more parts you add, the longer the identifiers will be (but they might become a bit clumsy, e.g. AbnormalChineseEarthDrillerVanessa)</para>
    /// </summary>
    [Flags]
    public enum IdentifierComponents
    {
        /// <summary>
        /// Pompous, Meandering, Former, Saddened
        /// </summary>
        Adjective =  1 << 1,
        /// <summary>
        /// Nigerian, Estonian, Gabonese,Yemenite
        /// </summary>
        Nationality = 1 << 2,

        /// <summary>
        /// Nightgown, Ink, Justification
        /// </summary>
        Noun = 1 << 3,

        /// <summary>
        /// Beaver, SavannaBaboon, Sturgeon
        /// </summary>
        Animal = 1 << 4,

        /// <summary>
        /// Optometrist,  FilmEditor, SalesEngineer, GamingDealer, Dietitian
        /// </summary>
        Profession = 1 << 5,

        /// <summary>
        /// Austin, Hildegaard, Meggie, Prunella, Gideon
        /// </summary>
        FirstName = 1 << 6,

    }
}