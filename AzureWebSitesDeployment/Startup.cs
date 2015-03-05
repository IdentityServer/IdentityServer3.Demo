using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Logging;

namespace AzureWebSitesDeployment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            // uncomment to enable HSTS headers for the host
            // see: https://developer.mozilla.org/en-US/docs/Web/Security/HTTP_strict_transport_security
            //app.UseHsts();

            var factory = InMemoryFactory.Create(
                users:   Users.Get(),
                clients: Clients.Get(),
                scopes:  Scopes.Get());

            var idsrvOptions = new IdentityServerOptions
            {
                SiteName = "IdentityServer3 Demo",
                Factory = factory,
                SigningCertificate = Cert.Load(),

                CorsPolicy = CorsPolicy.AllowAll,

                //AuthenticationOptions = new AuthenticationOptions
                //{
                //    IdentityProviders = ConfigureIdentityProviders
                //}
            };

            app.UseIdentityServer(idsrvOptions);
            
            // only for showing the getting started index page
            app.UseStaticFiles();
        }

        public static void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            var google = new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                Caption = "Google",
                SignInAsAuthenticationType = signInAsType,

                ClientId = "767400843187-8boio83mb57ruogr9af9ut09fkg56b27.apps.googleusercontent.com",
                ClientSecret = "5fWcBT0udKY7_b6E3gEiJlze"
            };
            app.UseGoogleAuthentication(google);

            var aad = new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "aad",
                Caption = "Azure AD",
                SignInAsAuthenticationType = signInAsType,

                Authority = "https://login.windows.net/4ca9cb4c-5e5f-4be9-b700-c532992a3705",
                ClientId = "65bbbda8-8b85-4c9d-81e9-1502330aacba",
                RedirectUri = "https://identity.thinktecture.com/aadcb"
            };

            app.UseOpenIdConnectAuthentication(aad);
        }
    }
}