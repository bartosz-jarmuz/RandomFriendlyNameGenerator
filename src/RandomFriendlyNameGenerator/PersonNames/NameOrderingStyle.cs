namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Determines the order in which the name part should occur in the phrase
    /// </summary>
    public enum NameOrderingStyle
    {
        /// <summary>
        /// <para>The Silent Bob style - name comes last, then the noun, profession or animal</para>
        /// <para>e.g. Crouching Journalist Hildegaard</para>
        /// <para>or Sophisticated Albanian MountainGoat Helga</para>
        /// </summary>
        SilentBobStyle,

        /// <summary>
        /// <para>The Bob The Builder style - name comes first, then a 'The' article, and then the noun, profession or animal</para>
        /// <para>e.g. Hildegaard The Crouching Journalist</para>
        /// <para>or Helga The Sophisticated Albanian MountainGoat</para>
        /// </summary>
        BobTheBuilderStyle,

    }
}