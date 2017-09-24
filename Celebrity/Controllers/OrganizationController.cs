namespace Celebrity.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Web;

    [Route("api/organizations")]
    public class OrganizationController : BaseController
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