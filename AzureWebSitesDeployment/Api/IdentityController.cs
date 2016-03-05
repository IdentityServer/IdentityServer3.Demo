using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace AzureWebSitesDeployment.Api
{
    [Route("identity")]
    public class IdentityController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            if (caller.Identity.IsAuthenticated)
            {
                return Json(from c in caller.Claims select new { c.Type, c.Value });
            }
            else
            {
                return Json(new { caller = "anonymous" });
            }
        }
    }
}