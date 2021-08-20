using Core.Boundaries.Persistence;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Rules
{
    /// <summary>
    /// Represents the Business rules associated with the <see cref="EducationLevel"/> entity.
    /// </summary>
    public sealed class EducationLevelRules
    {
        private readonly IEducationLevelRepository _educationLevelRepository;

        /// <summary>
        /// Initializes a new instance of the EducationLevelRules class.
        /// </summary>
        /// <param name="educationLevelRepository">An implementation of the <see cref="IEducationLevelRepository"/>.</param>
        public EducationLevelRules(IEducationLevelRepository educationLevelRepository) => _educationLevelRepository = educationLevelRepository;

        /// <summary>
        /// Retrieves all the active education levels stored at the DB.
        /// </summary>
        /// <returns>A Collection with all the found education levels.</returns>
        public async Task<ICollection<EducationLevel>> GetAll() => await _educationLevelRepository.FindAllAsync(educationLevel => educationLevel.Status);
    }
}
