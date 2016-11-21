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
                    ClientName = "Native Client (Hybrid Flow with PKCE)",
                    ClientId = "native",

                    Flow = Flows.HybridWithProofKey,
                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    },

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowAccessToAllScopes = true
                },
                
                new Client
                {
                    ClientName = "Native Client (Code Flow with PKCE)",
                    ClientId = "native.code",

                    Flow = Flows.AuthorizationCodeWithProofKey,
                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    },

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowAccessToAllScopes = true
                },
                
                new Client
                {
                    ClientName = "Authorization Code Client",
                    ClientId = "code",

                    Flow = Flows.AuthorizationCode,
                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    },

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowAccessToAllScopes = true
                },

                new Client
                {
                    ClientName = "Implicit Flow Client",
                    ClientId = "implicit",
                    
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    },

                    AllowAccessToAllScopes = true
                },
                
                new Client
                {
                    ClientName = "Hybrid Flow Client",
                    ClientId = "hybrid",
                    
                    Flow = Flows.Hybrid,
                    RedirectUris = new List<string>
                    {
                        "https://someUri",
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowAccessToAllScopes = true
                },
                
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    Flow = Flows.ClientCredentials,
                    AllowAccessToAllScopes = true
                },
            };
        }
    }
}
