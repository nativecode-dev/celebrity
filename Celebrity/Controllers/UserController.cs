namespace Celebrity.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Models.Security;

    [Route("users")]
    public class UserController : Controller
    {
        private readonly AuthenticationService authentication;

        public UserController(AuthenticationService authentication)
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
            throw new NotSupportedException();
        }
    }
}