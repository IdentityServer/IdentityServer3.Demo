using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace AzureWebSitesDeployment.Api
{
    [Route("test")]
    [Authorize]
    [HostAuthentication("Bearer")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;
            return Json(from c in caller.Claims select new { c.Type, c.Value });
        }
    }
}