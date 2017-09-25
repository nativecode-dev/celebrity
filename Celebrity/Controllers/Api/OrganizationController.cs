namespace Celebrity.Controllers.Api
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/organizations")]
    public class OrganizationController : ControllerBase
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