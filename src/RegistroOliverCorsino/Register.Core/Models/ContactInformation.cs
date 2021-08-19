namespace Register.Core.Models
{
    /// <summary>
    /// Represents the entity for storing the contact information about an <see cref="User"/>.
    /// </summary>
    public sealed class ContactInformation : BaseModel
    {
        /// <summary>
        /// Represents which type a <see cref="ContactInformation"/> is.
        /// </summary>
        public int ContactInformationTypeId { get; set; }


        /// <summary>
        /// Represents the relationship between the <see cref="ContactInformationType"/> entity and <see cref="ContactInformation"/> entity.
        /// </summary>
        public ContactInformationType ContactInformationType { get; set; }
    }
}
