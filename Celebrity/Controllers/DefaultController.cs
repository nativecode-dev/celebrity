namespace Celebrity.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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