using Core.Models;
using Core.Rules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/contact-information-types")]
    [ApiController]
    public class ContactInformationTypesController : ControllerBase
    {
        private readonly ContactInformationTypeRules _contactInformationTypeRules;

        /// <summary>
        /// Initializes a new instance of EducationLevelsController class.
        /// </summary>
        /// <param name="contactInformationTypeRules">Represents the object that will handle the contact information business rule.</param>
        public ContactInformationTypesController(ContactInformationTypeRules contactInformationTypeRules) => _contactInformationTypeRules = contactInformationTypeRules;

        /// <summary>
        /// Retrieves all the active contact information types stored at the DB.
        /// </summary>
        /// <returns>A Collection with all the found contact information types.</returns>
        [HttpGet("")]
        public async Task<ActionResult<ICollection<ContactInformationType>>> GetAll()
        {
            try
            {
                ICollection<ContactInformationType> educationLevels = await _contactInformationTypeRules.GetAll();

                return Ok(educationLevels);
            }
            catch (Exception)
            {
                return BadRequest("There was an error processing your request. Please try again or contact our help desk.");
            }
        }
    }
}
