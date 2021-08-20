namespace Core.Models
{
    /// <summary>
    /// Represents the entity for storing the contact information about an <see cref="Models.User"/>.
    /// </summary>
    public sealed class ContactInformation : BaseModel
    {
        /// <summary>
        /// Represents which type a <see cref="ContactInformation"/> is.
        /// </summary>
        public int ContactInformationTypeId { get; set; }

        /// <summary>
        /// Represents the foreign key for the relationship with the <see cref="Models.User"/> entity.
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// Represents the relationship between the <see cref="Models.ContactInformationType"/> entity and <see cref="ContactInformation"/> entity.
        /// </summary>
        public ContactInformationType ContactInformationType { get; set; }

        /// <summary>
        /// Represents the relationship between the <see cref="Models.User"/> entity and <see cref="ContactInformation"/> entity.
        /// </summary>
        public User User { get; set; }
    }
}
