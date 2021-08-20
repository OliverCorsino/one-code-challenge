using Core.Models;
using Core.Rules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRules _userRules;

        /// <summary>
        /// Initializes a new instance of UsersController class.
        /// </summary>
        /// <param name="userRules">Represents the object that will handle the user business rule.</param>
        public UserController(UserRules userRules)
        {
            _userRules = userRules;
        }

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
