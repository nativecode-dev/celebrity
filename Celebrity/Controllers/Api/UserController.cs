namespace Celebrity.Controllers.Api
{
    using System;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Models.Security;

    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService authentication;

        public UserController(IAuthenticationService authentication)
        {
            this.authentication = authentication;
        }

        [HttpGet("{userId:guid}")]
        public IActionResult Get(Guid userId)
        {
            return this.Ok();
        }

        [HttpPut]
        public IActionResult Post([FromBody] LoginModel login)
        {
            return this.Ok();
        }
    }
}