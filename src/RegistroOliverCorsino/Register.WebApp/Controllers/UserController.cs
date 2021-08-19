using Microsoft.AspNetCore.Mvc;

namespace Register.WebApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{identificationNumber}")]
        public bool ValidateUser(string identificationNumber)
        {
            return true;
        }
    }
}
