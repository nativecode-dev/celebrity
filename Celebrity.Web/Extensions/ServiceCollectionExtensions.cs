namespace Celebrity.Web.Extensions
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Core.Types;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.AspNetCore.Mvc.Cors.Internal;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Services.Options;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCelebrityMvc(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddOptions()
                .Configure<Global>(configuration.GetSection(nameof(Global)))
                .AddAuthentication(ServiceCollectionExtensions.Authentication)
                .AddOpenIdConnect(ServiceCollectionExtensions.OpenId(configuration))
                .AddCookie()
                .Services
                .AddMvc(ServiceCollectionExtensions.Mvc)
                .AddJsonOptions(ServiceCollectionExtensions.Json)
                .Services;
        }

        private static void Json(MvcJsonOptions options)
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
        }

        private static void Mvc(MvcOptions options)
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            options.Filters.Add(new AuthorizeFilter(policy));
#if DEBUG
            options.Filters.Add(new DisableCorsAuthorizationFilter());
#endif
        }

        private static void Authentication(AuthenticationOptions options)
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }

        private static Action<OpenIdConnectOptions> OpenId(IConfiguration configuration)
        {
            return options =>
            {
                var global = configuration.Get<Global>();
                configuration.GetSection(nameof(Global)).Bind(global);

                options.Authority = new UriBuilder(Uri.UriSchemeHttps, global.AuthOpenId.Domain).Uri.AbsoluteUri;
                options.CallbackPath = new PathString(global.AuthOpenId.CallbackUrl);
                options.ClaimsIssuer = global.AuthOpenId.ClaimsIssuer;
                options.ClientId = global.AuthOpenId.ClientId;
                options.ClientSecret = global.AuthOpenId.ClientSecret;
                options.ResponseType = global.AuthOpenId.ResponseType;

                options.Scope.Clear();
                options.Scope.Add(global.AuthOpenId.Scope);

                options.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProviderForSignOut = ServiceCollectionExtensions.SignOut(global),
                    OnUserInformationReceived = ServiceCollectionExtensions.User()
                };
            };
        }

        private static Func<UserInformationReceivedContext, Task> User()
        {
            return context =>
            {
                Trace.WriteLine(context.User);
                return Task.CompletedTask;
            };
        }

        private static Func<RedirectContext, Task> SignOut(Global global)
        {
            return context =>
            {
                var uri = new UriBuilderFluent()
                    .SetScheme(Uri.UriSchemeHttps)
                    .SetHost(global.AuthOpenId.Domain)
                    .SetPath("/v2/logout")
                    .SetQuery("client_id", global.AuthOpenId.ClientId);

                var redirect = context.Properties.RedirectUri;

                if (string.IsNullOrWhiteSpace(redirect) == false)
                {
                    if (redirect.StartsWith("/"))
                    {
                        uri.SetScheme(context.Request.Scheme)
                            .SetHost(context.Request.Host.Host)
                            .SetPath(redirect)
                            .SetQueryClear();
                    }

                    uri.SetQuery("returnTo", Uri.EscapeDataString(redirect));
                }

                context.Response.Redirect(uri.AbsoluteUri);
                context.HandleResponse();

                return Task.CompletedTask;
            };
        }
    }
}