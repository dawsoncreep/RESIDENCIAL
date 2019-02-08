using Common;
using Model.AuthorizationServer;
using Model.Domain;
using Service;
using System.Web.Http;

namespace AuthorizationServer.Api.Controllers
{
    [RoutePrefix("api/audience")]
    public class AudienceController : ApiController
    {
        private readonly IAuthorizationServerService _authorizationServerRepository = 
            DependecyFactory.GetInstance<IAuthorizationServerService>();

        // GET: Audience
        [Route("")]
        public IHttpActionResult Post(AudienceForSuscribe audienceModel)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Audience newAudience = _authorizationServerRepository.InsertOrUpdate(audienceModel);

            return Ok<Audience>(newAudience);

        }
    }
}