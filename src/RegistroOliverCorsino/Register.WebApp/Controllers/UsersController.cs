using Core.Models;
using Core.Rules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Core.Contracts;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRules _userRules;

        /// <summary>
        /// Initializes a new instance of UsersController class.
        /// </summary>
        /// <param name="userRules">Represents the object that will handle the user business rule.</param>
        public UsersController(UserRules userRules) => _userRules = userRules;

        /// <summary>
        /// Retrieves an user from the database if it exists, otherwise returns nothing.
        /// </summary>
        /// <param name="identificationNumber">Represents the user identification number you are looking for.</param>
        /// <returns>An user from the database if it exists, otherwise returns nothing.</returns>
        [HttpGet("{identificationNumber}")]
        public async Task<ActionResult<User>> GetUserByIdentificationNumber(string identificationNumber)
        {
            try
            {
                User user = await _userRules.GetUserByIdentificationNumber(identificationNumber);

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest("There was an error processing your request. Please try again or contact our help desk.");
            }
        }

        /// <summary>
        /// Saves a new user into the DB
        /// </summary>
        /// <param name="userViewModel">Represents the new user added to the system.</param>
        /// <returns>The saved user.</returns>
        [HttpPost("")]
        public async Task<ActionResult<User>> Save(UserViewModel userViewModel)
        {
            var user = new User
            {
                ContactInformation = userViewModel.ContactInformations,
                IdentificationNumber = userViewModel.IdentificationNumber,
                DateOfBirth = userViewModel.DateOfBirth,
                EducationLevelId = userViewModel.EducationLevelId,
                LastName = userViewModel.LastName,
                Name = userViewModel.Name
            };

            IOperationResult<User> operationResult = await _userRules.Save(user);

            if (operationResult.Success)
            {
                return Ok(operationResult.Entity);
            }

            return BadRequest(operationResult.Message);
        }


    }
}
