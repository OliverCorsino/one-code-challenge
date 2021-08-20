namespace Core.Models
{
    /// <summary>
    /// Represents the different roles a <see cref="Models.User"/> could has.
    /// </summary>
    public sealed class Role : BaseModel
    {
        /// <summary>
        /// Represents the relationship between the <see cref="Models.User"/> entity and <see cref="Role"/> entity.
        /// </summary>
        public User User { get; set; }
    }
}