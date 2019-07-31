namespace RandomFriendlyNameGenerator
{
    /// <summary>
    /// Which parts of the name should be provided
    /// </summary>
    public enum NameComponents
    {
        /// <summary>
        /// e.g. John Doe
        /// </summary>
        FirstNameLastName,

        /// <summary>
        /// e.g. John Barnaby Doe
        /// </summary>
        FirstNameMiddleNameLastName,

        /// <summary>
        /// e.g. John
        /// </summary>
        FirstNameOnly,

        /// <summary>
        /// e.g. Doe
        /// </summary>
        LastNameOnly,

        /// <summary>
        /// Doe John
        /// </summary>
        LastNameFirstName,
    }
}