namespace Register.Core.Models
{
    /// <summary>
    /// Represent a base entity with the common information needed across other entities.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Represents the entity identification or PK.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents a given description/name of the entity.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represents an entry's status
        /// </summary>
        public bool Status { get; set; }
    }
}
