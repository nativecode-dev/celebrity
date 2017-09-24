namespace Celebrity.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("")]
    public class IndexController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Index()
        {
            return this.View();
        }
    }
}