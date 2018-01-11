using ESPL.RedSkyTimeSheet.BL.Operations.Auth;
using System.Web;
using System.Web.Http;

namespace ESPL.RedSkyTimeSheet.Controllers.Auth
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        AuthOperations objAuth = new AuthOperations();
        public string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];

        

        [Authorize]
        [HttpGet]
        [Route("api/auth/currentusername")]
        public IHttpActionResult CurrentUserName()
        {
            return Ok(objAuth.CurrentUserName());
        }

        [Authorize]
        [HttpGet]
        [Route("api/auth/userroles")]
        public IHttpActionResult UserRoles()
        {
            return Ok(objAuth.UserRoles());
        }
    }
}
