using Core.Boundaries.Persistence;
using Core.Contracts;
using Core.Enums;
using Core.Models;
using System;
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
        /// <returns>An user from the database if it exists, otherwise returns nothing.</returns>
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

        public async Task<IOperationResult<User>> Save(User user)
        {
            try
            {
                Requires.NotNullOrWhiteSpace(user.IdentificationNumber, nameof(user.IdentificationNumber));
                Requires.NotNullOrWhiteSpace(user.Name, nameof(user.Name));
                Requires.NotNullOrWhiteSpace(user.LastName, nameof(user.LastName));
                Requires.NotDefault(user.DateOfBirth, nameof(user.DateOfBirth));
                Requires.Range(user.ContactInformation.Count > 0, nameof(user.ContactInformation));

                var exists = await _userRepository.ExistsAsync(x => x.IdentificationNumber.Equals(user.IdentificationNumber));

                if (exists)
                {
                    return BasicOperationResult<User>.Fail("¡El usuario que se intenta almacenar ya existe en nuestro sistema!");
                }

                user.RoleId = GetUserRole(user.DateOfBirth, user.EducationLevelId);

                IOperationResult<User> operationResult = _userRepository.Create(user);

                if (operationResult.Success)
                {
                    await _userRepository.SaveAsync();

                    return operationResult;
                }

                return operationResult;
            }
            catch (Exception e)
            {
                return BasicOperationResult<User>.Fail(e.Message); ;
            }
        }

        private int GetUserRole(DateTime dateOfBirth, int educationLevel)
        {
            int userRole;
            var today = DateTime.Today;

            int userAge = today.Year - dateOfBirth.Year;

            if (userAge < 18)
            {
                return (int)RoleAssignation.NoQualified;
            }

            switch (educationLevel)
            {
                case (int)EducationLevelAssignation.Bachelor:
                    userRole = (int)RoleAssignation.CensusTaker;
                    break;

                case (int)EducationLevelAssignation.Academic:
                    userRole = (int)RoleAssignation.Supervisor;
                    break;

                case (int)EducationLevelAssignation.Postgraduate:
                    userRole = (int)RoleAssignation.Coordinator;
                    break;
                default:
                    userRole = (int)RoleAssignation.CensusTaker;
                    break;
            }

            return userRole;
        }
    }
}
