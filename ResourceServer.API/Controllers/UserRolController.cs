using Common;
using Model.Auth;
using NLog;
using Service.ExternalService;
using System;
using System.Linq;
using System.Web.Http;

namespace ResourceServer.API.Controllers
{

    [RoutePrefix("api/userRole")]
    public class UserRolController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIUserRoleService _apiUserRoleService;

        public UserRolController() : base()
        {
            _apiUserRoleService = DependecyFactory.GetInstance<IAPIUserRoleService>();
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(ApplicationUserRole model)
        {
            try
            {
                var rh = _apiUserRoleService.DeleteUserRole(model);
                return Ok(rh);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }

        }
    }
}
