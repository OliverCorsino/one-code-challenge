using Core.Boundaries.Persistence;
using Core.Models;
using System.Threading.Tasks;
using Validation;

namespace Core.Rules
{
    /// <summary>
    /// Represents the Business rules associated with the <see cref="User"/> entity.
    /// </summary>
    public sealed class UserRules
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the UserRules class.
        /// </summary>
        /// <param name="userRepository">An implementation of the <see cref="IUserRepository"/>.</param>
        public UserRules(IUserRepository userRepository) => _userRepository = userRepository;

        /// <summary>
        /// Retrieves an user from the database if it exists, otherwise returns nothing.
        /// </summary>
        /// <param name="identificationNumber">Represents the user identification number you are looking for.</param>
        /// <returns>an user from the database if it exists, otherwise returns nothing.</returns>
        public async Task<User> GetUserByIdentificationNumber(string identificationNumber)
        {
            Requires.NotNullOrEmpty(identificationNumber, nameof(identificationNumber));
            
            var exists = await _userRepository.ExistsAsync(x => x.IdentificationNumber.Equals(identificationNumber));
            
            if (exists)
            {
                return await _userRepository.FindAsync(x => x.IdentificationNumber.Equals(identificationNumber));
            }

            return null;
        }
    }
}
