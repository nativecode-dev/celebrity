using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Celebrity.Controllers
{
    [Route("")]
    public class DefaultController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return this.Ok();
        }
    }
}