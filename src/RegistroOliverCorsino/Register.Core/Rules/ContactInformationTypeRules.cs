using Core.Boundaries.Persistence;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Rules
{
    /// <summary>
    /// Represents the Business rules associated with the <see cref="ContactInformationType"/> entity.
    /// </summary>
    public sealed class ContactInformationTypeRules
    {
        private readonly IContactInformationTypeRepository _contactInformationTypeRepository;

        /// <summary>
        /// Initializes a new instance of the ContactInformationTypeRules class.
        /// </summary>
        /// <param name="contactInformationTypeRepository">An implementation of the <see cref="IContactInformationTypeRepository"/>.</param>
        public ContactInformationTypeRules(IContactInformationTypeRepository contactInformationTypeRepository) => _contactInformationTypeRepository = contactInformationTypeRepository;

        /// <summary>
        /// Retrieves all the active contact information types stored at the DB.
        /// </summary>
        /// <returns>A Collection with all the found contact information types.</returns>
        public async Task<ICollection<ContactInformationType>> GetAll() => await _contactInformationTypeRepository.FindAllAsync(contactInformationType => contactInformationType.Status);
    }
}
