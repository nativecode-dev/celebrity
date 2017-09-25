namespace Celebrity.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Web;

    public class AccountController : BaseController
    {
        private const string AuthProviderName = "Cookies";

        [AllowAnonymous]
        [HttpGet("login")]
        public async Task Login(string returnUri = "/")
        {
            await this.HttpContext
                .ChallengeAsync(
                    AccountController.AuthProviderName,
                    AccountController.CreateAuthenticationProperties(returnUri)
                )
                .ConfigureAwait(false);
        }

        [AllowAnonymous]
        [HttpPost("authorized")]
        public Task Authorized()
        {
            return Task.CompletedTask;
        }

        [HttpPost("logout")]
        public async Task Logout()
        {
            try
            {
                await this.HttpContext
                    .SignOutAsync(
                        AccountController.AuthProviderName,
                        AccountController.CreateAuthenticationProperties(this.Url.Action("Home", "Default"))
                    )
                    .ConfigureAwait(false);
            }
            finally
            {
                await this.HttpContext
                    .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
                    .ConfigureAwait(false);
            }
        }

        private static AuthenticationProperties CreateAuthenticationProperties(string redirectUri)
        {
            return new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow,
                RedirectUri = redirectUri
            };
        }
    }
}