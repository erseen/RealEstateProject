using Emlak.Api.Models;
using Emlak.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterModel model)
        {
            var result = await _authenticationService.RegisterUser(model);
            if (!result.Succeeded)
            {
                throw new Exception("Registration error");
            }
            return StatusCode(201);
        }


        [HttpPost("login")]
        public async Task<IActionResult>Authenticate([FromBody]LoginModel model)
        {
            if (!await _authenticationService.ValidateUser(model))
                return Unauthorized();

            return Ok(new
            {
                Token=await _authenticationService.CreateToken()
            });
        }

    }
}
