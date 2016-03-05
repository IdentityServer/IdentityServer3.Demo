﻿using AzureWebSitesDeployment.Config;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Serilog;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using AzureWebSitesDeployment.Api;

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
                    new TypeResolver(typeof(IdentityController)));
                config.MapHttpAttributeRoutes();

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
            };

            app.UseIdentityServer(idsrvOptions);            
        }
    }
}