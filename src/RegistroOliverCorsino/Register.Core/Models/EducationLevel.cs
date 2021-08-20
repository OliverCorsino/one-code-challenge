namespace Core.Models
{
    /// <summary>
    /// Represents the Education Level a <see cref="Models.User"/> could has.
    /// </summary>
    public sealed class EducationLevel : BaseModel
    {
        /// <summary>
        /// Represents the relationship between the <see cref="Models.User"/> entity and <see cref="EducationLevel"/> entity.
        /// </summary>
        public User User { get; set; }
    }
}