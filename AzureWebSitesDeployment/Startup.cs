﻿using AzureWebSitesDeployment.Config;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;

namespace AzureWebSitesDeployment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
            };

            app.UseIdentityServer(idsrvOptions);            
        }
    }
}