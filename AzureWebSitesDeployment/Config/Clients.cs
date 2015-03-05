using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace AzureWebSitesDeployment
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    /////////////////////////////
                    // OIDC conformance tests
                    /////////////////////////////

                    ClientName = "Test Client Code Flow",
                    Enabled = true,

                    ClientId = "codeclient",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("secret".Sha256())
                    },

                    Flow = Flows.AuthorizationCode,

                    RedirectUris = new List<string>
                    {
                        "https://oictest.umdc.umu.se:8096/authz_cb",
                        "https://localhost:44327/account/callback"
                    }
                },
                new Client
                {
                    ClientName = "Test Client Implicit Flow",
                    Enabled = true,

                    ClientId = "implicitclient",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("secret".Sha256())
                    },
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://oictest.umdc.umu.se:8097/authz_cb",
                    }
                },
                new Client
                {
                    ClientName = "Test Client Hybrid Flow",
                    Enabled = true,

                    ClientId = "hybridclient",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("secret".Sha256())
                    },
                    Flow = Flows.Hybrid,

                    RedirectUris = new List<string>
                    {
                        "https://oictest.umdc.umu.se:8098/authz_cb",
                    }
                },


                /////////////////////////////
                // Microsoft EasyAuth Demos
                /////////////////////////////

                new Client
                {
                    ClientName = "EasyAuth Local Test",
                    Enabled = true,

                    ClientId = "fe322c4b-a30f-4a73-b2a5-6dc930f68d52",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:44308/",
                        "https://localhost:44308"
                    }
                },
                new Client
                {
                    ClientName = "EasyAuth NodeJs Test",
                    Enabled = true,

                    ClientId = "e05c0797-2f6e-4781-8663-5803f3420cba",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://easyauth-nodejs-msft.azurewebsites.net/",
                        "https://easyauth-nodejs-msft.azurewebsites.net",
                    }
                },
                new Client
                {
                    ClientName = "EasyAuth AspNet Test",
                    Enabled = true,

                    ClientId = "b9b637f1-839c-423c-b340-a22e2b778ad8",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://easyauth-aspnet-msft.azurewebsites.net/",
                        "https://easyauth-aspnet-msft.azurewebsites.net",
                    }
                },
            };
        }
    }
}