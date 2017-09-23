namespace Celebrity.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("organizations")]
    public class OrganizationController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok();
        }

        [HttpGet("{organizationId:guid}")]
        public IActionResult Get(Guid organizationId)
        {
            return this.Ok();
        }
    }
}