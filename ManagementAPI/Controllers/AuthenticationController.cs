using Application.Interfaces;
using Application.Models.Request.Credential;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public IActionResult Authenticate([FromBody] CredentialRequest credentialRequest)
        {
            var token = _authenticationService.AuthenticateCredentials(credentialRequest);

            if (token == "null")
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
