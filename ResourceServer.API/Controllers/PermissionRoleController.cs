using Common;
using NLog;
using Service.ExternalService;
using System;
using System.Linq;
using System.Web.Http;

namespace ResourceServer.API.Controllers
{
    [RoutePrefix("api/permissionRole")]
    public class PermissionRoleController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIPermissionRoleService _apiPermissionRoleService;

        public PermissionRoleController() : base()
        {
            _apiPermissionRoleService = DependecyFactory.GetInstance<IAPIPermissionRoleService>();
        }

        [HttpGet]
        [Route("GetByRoleId/{roleId}")]
        public IHttpActionResult GetByRoleId(Guid roleId)
        {
            try
            {
                var userPermissions = _apiPermissionRoleService.GetByRoleId(roleId).ToList();
                return Ok(userPermissions);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var rolePermissions = _apiPermissionRoleService.GetAll().ToList();
                return Ok(rolePermissions);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }

    }
}
