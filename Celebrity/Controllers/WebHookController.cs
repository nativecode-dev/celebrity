namespace Celebrity.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Web;

    [Route("api/webhooks")]
    public class WebHookController : BaseController
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