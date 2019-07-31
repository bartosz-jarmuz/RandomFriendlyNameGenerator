namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Specifies the settings for the generator
    /// </summary>
    public class GeneratorOptions
    {
        /// <summary>
        /// The default options set
        /// </summary>
        public static GeneratorOptions Default = new GeneratorOptions();
        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        public string Separator { get; set; } = " ";
      
        /// <summary>
        /// Gets or sets a value indicating whether [force single character].
        /// </summary>
        /// <value><c>true</c> if [force single character]; otherwise, <c>false</c>.</value>
        public bool ForceSingleCharacter { get; set; } = false;
       
        /// <summary>
        /// Gets or sets the name length restriction.
        /// </summary>
        /// <value>The name length restriction.</value>
        public int NameLengthRestriction{ get; set; } = 0;
    }
}