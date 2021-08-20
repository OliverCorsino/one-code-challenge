using Core.Boundaries.Persistence;
using Core.Models;

namespace Boundaries.Persistence.Repositories
{
    /// <inheritdoc cref="GenericRepository{T}"/>
    public sealed class ContactInformationTypeRepository : GenericRepository<ContactInformationType>, IContactInformationTypeRepository
    {
        private RegistrationDbContext _registrationDbContext;

        /// <summary>
        /// Initializes a new instance of a UserRepository class.
        /// </summary>
        /// <param name="registrationDbContext">Represents the registration DB context.</param>
        public ContactInformationTypeRepository(RegistrationDbContext registrationDbContext) : base(registrationDbContext) => _registrationDbContext = registrationDbContext;
    }
}
