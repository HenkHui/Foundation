using EPiServer.ContentApi.Core.Security.Internal;
using EPiServer.Core;
using System.Web.Http;

namespace Foundation.Features.ContentDeliveryApi
{
    [RoutePrefix("api/episerver/custom/v1/demo")]
    [ContentApiAuthorization]
    [ContentApiCors]
    [CorsOptionsActionFilter]
    public class CustomApiDemoController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : "anonymous";
            var startPage = ContentReference.StartPage;

            var data = new[] { "value1", "value2", user, startPage.ToString() };

            return Ok(data);
        }
    }
}