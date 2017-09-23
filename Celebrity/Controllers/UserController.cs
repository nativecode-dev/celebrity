using System;
using Microsoft.AspNetCore.Mvc;

namespace Celebrity.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        [HttpGet("{userId:guid}")]
        public IActionResult Get(Guid userId)
        {
            return this.Ok();
        }
    }
}