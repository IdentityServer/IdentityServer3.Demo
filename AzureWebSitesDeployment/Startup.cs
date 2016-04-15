using AzureWebSitesDeployment.Config;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Serilog;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using AzureWebSitesDeployment.Api;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin.Security.Google;

namespace AzureWebSitesDeployment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            app.Map("/api", apiApp =>
            {
                var config = new HttpConfiguration();
                config.Services.Replace(typeof(IHttpControllerTypeResolver),
                    new TypeResolver(typeof(IdentityController), typeof(TestController)));
                config.MapHttpAttributeRoutes();

                app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = "https://demo.identityserver.io",
                    ValidationMode = ValidationMode.ValidationEndpoint,
                    RequiredScopes = new[] { "api" },

                    DelayLoadMetadata = true
                });

                apiApp.UseWebApi(config);
            });


            var factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get())
                .UseInMemoryUsers(Users.Get());

            // turns off redirect URI validaiton - ONLY FOR DEMO PURPOSES
            factory.RedirectUriValidator = new Registration<IRedirectUriValidator, NopRedirectUriValidator>();

            var idsrvOptions = new IdentityServerOptions
            {
                SiteName = "IdentityServer3 Demo",
                Factory = factory,
                SigningCertificate = Cert.Load(),

                AuthenticationOptions = new AuthenticationOptions
                {
                    IdentityProviders = ConfigureIdentityProviders
                }
            };

            app.UseIdentityServer(idsrvOptions);            
        }

        private void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                SignInAsAuthenticationType = signInAsType,

                ClientId = "708996912208-9m4dkjb5hscn7cjrn5u0r4tbgkbj1fko.apps.googleusercontent.com",
                ClientSecret = "wdfPY6t8H8cecgjlxud__4Gh"
            });
        }
    }
}