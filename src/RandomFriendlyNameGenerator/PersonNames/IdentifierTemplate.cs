namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Predefined identifier styles
    /// </summary>
    public enum IdentifierTemplate
    {
        /// <summary>
        /// Random combination of any two components.
        /// <para>The possible combinations are limited to be meaningful (E.g you won't get two adjectives or two first names)</para>
        /// </summary>
        AnyTwoComponents,
       
        /// <summary>
        /// Random combination of any three components.
        /// <para>The possible combinations are limited to be meaningful (E.g you won't get two adjectives or two first names)</para>
        /// </summary>
        AnyThreeComponents,

        /// <summary>
        /// Name and profession
        /// <para>the order pattern depends on the NameOrderingStyle parameter (it can be either Bob The Builder or Builder Bob)</para>
        /// </summary>
        BobTheBuilder,

        /// <summary>
        /// Animal and name - the order pattern depends on the NameOrderingStyle parameter (it can be either Peppa The Pig or Peppa Pig)
        /// <para>the order pattern depends on the NameOrderingStyle parameter (it can be either Peppa The Pig or Peppa Pig)</para>
        /// </summary>
        PeppaPig,

        /// <summary>
        /// Adjective and name
        /// <para>the order pattern depends on the NameOrderingStyle parameter (it can be either Silent Bob or Bob The Silent)</para>
        /// </summary>
        SilentBob,

        /// <summary>
        /// Adjective and noun (like GitHub repo names suggestions, e.g. Unclean Tool, Vigorous Housewife, Undifferentiated Wok, 
        /// </summary>
        GitHub
    }
}