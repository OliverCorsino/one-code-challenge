using Core.Boundaries.Persistence;
using Core.Models;

namespace Boundaries.Persistence.Repositories
{
    public sealed class UserRepository : GenericRepository<User>, IUserRepository
    {
        private RegistrationDbContext _registrationDbContext;

        /// <summary>
        /// Initializes a new instance of a UserRepository class.
        /// </summary>
        /// <param name="registrationDbContext">Represents the registration DB context.</param>
        public UserRepository(RegistrationDbContext registrationDbContext) : base(registrationDbContext) => _registrationDbContext = registrationDbContext;
    }
}
