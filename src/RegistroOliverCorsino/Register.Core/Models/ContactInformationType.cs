namespace Core.Models
{
    /// <summary>
    /// Represents the entity for storing the contact information type.
    /// </summary>
    public sealed class ContactInformationType : BaseModel
    {
        /// <summary>
        /// Represents the relationship between the <see cref="ContactInformationType"/> entity and <see cref="Models.ContactInformation"/> entity.
        /// </summary>
        public ContactInformation ContactInformation { get; set; }
    }
}
