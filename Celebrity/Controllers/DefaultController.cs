namespace Celebrity.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Security;
    using Web;

    [Route("")]
    public class DefaultController : BaseController
    {
        [HttpGet]
        [HttpGet("home")]
        [AllowAnonymous]
        public ViewResult Home()
        {
            return this.View();
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("~/Home");
            }

            return this.View(this.CreateModel());
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] LoginModel login)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.Redirect("~/Login");
            }

            return this.Redirect("~/Home");
        }

        [HttpPost("logout")]
        public RedirectResult Logout()
        {
            return this.Redirect("~/Home");
        }

        private LoginModel CreateModel()
        {
            var model = new LoginModel();

            if (this.User.Identity.IsAuthenticated)
            {
                model.Login = this.User.Identity.Name;
            }

            return model;
        }
    }
}