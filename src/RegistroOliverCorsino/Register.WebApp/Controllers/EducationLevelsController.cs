using Core.Models;
using Core.Rules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/education-levels")]
    [ApiController]
    public class EducationLevelsController : ControllerBase
    {
        private readonly EducationLevelRules _educationLevelRules;

        /// <summary>
        /// Initializes a new instance of EducationLevelsController class.
        /// </summary>
        /// <param name="educationLevelRules">Represents the object that will handle the education level business rule.</param>
        public EducationLevelsController(EducationLevelRules educationLevelRules) => _educationLevelRules = educationLevelRules;

        /// <summary>
        /// Retrieves all the active education levels stored at the DB.
        /// </summary>
        /// <returns>A Collection with all the found education levels.</returns>
        [HttpGet("")]
        public async Task<ActionResult<ICollection<EducationLevel>>> GetAll()
        {
            try
            {
                ICollection<EducationLevel> educationLevels = await _educationLevelRules.GetAll();

                return Ok(educationLevels);
            }
            catch (Exception)
            {
                return BadRequest("There was an error processing your request. Please try again or contact our help desk.");
            }
        }
    }
}
