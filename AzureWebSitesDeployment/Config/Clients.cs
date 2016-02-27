using IdentityServer3.Core.Models;
using System.Collections.Generic;


namespace AzureWebSitesDeployment.Config
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Test Client Code Flow",
                    Enabled = true,

                    ClientId = "code",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    Flow = Flows.AuthorizationCode,
                    AllowClientCredentialsOnly = true,

                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    }
                },
                new Client
                {
                    ClientName = "Test Client Implicit Flow",
                    Enabled = true,

                    ClientId = "implicit",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    Flow = Flows.Implicit,
                    AllowClientCredentialsOnly = true,

                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    }
                },
                new Client
                {
                    ClientName = "Test Client Hybrid Flow",
                    Enabled = true,

                    ClientId = "hybrid",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    Flow = Flows.Hybrid,
                    AllowClientCredentialsOnly = true,

                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    }
                }
            };
        }
    }
}