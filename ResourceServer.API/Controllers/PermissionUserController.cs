using Common;
using NLog;
using Service.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceServer.API.Controllers
{
    [RoutePrefix("api/permissionUser")]
    public class PermissionUserController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIPermissionUserService _apiPermissionUserService;

        public PermissionUserController() : base()
        {
            _apiPermissionUserService = DependecyFactory.GetInstance<IAPIPermissionUserService>();
        }

        [HttpGet]
        [Route("GetByUserId/{userId}")]
        public IHttpActionResult GetByUserId(Guid userId)
        {
            try
            {
                var userPermissions = _apiPermissionUserService.GetByUserId(userId).ToList();
                return Ok(userPermissions);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
