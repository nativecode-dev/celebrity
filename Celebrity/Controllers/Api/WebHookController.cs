namespace Celebrity.Controllers.Api
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/webhooks")]
    public class WebHookController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok();
        }

        [HttpGet("{webHookId:guid}")]
        public IActionResult Get(Guid webHookId)
        {
            return this.Ok();
        }
    }
}