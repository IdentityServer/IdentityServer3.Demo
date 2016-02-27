using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace AzureWebSitesDeployment.Config
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.Address,
                StandardScopes.Phone,
                StandardScopes.OfflineAccess,
            };

            return scopes;
        }
    }
}