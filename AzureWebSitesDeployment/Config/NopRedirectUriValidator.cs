using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using System.Threading.Tasks;

namespace AzureWebSitesDeployment.Config
{
    // effectively turns off redirect URI validation - NOT RECOMMENDED 
    public class NopRedirectUriValidator : IRedirectUriValidator
    {
        public Task<bool> IsPostLogoutRedirectUriValidAsync(string requestedUri, Client client)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsRedirectUriValidAsync(string requestedUri, Client client)
        {
            return Task.FromResult(true);
        }
    }
}