﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace Celebrity.Controllers
{
    [Route("webhooks")]
    public class WebHookController : Controller
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