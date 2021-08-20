using Core.Models;
using Core.Rules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
    }
}
