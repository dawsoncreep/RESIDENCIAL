using Common;
using Model.Domain;
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

        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(PermissionRole model)
        {

            try
            {
                var rh = _apiPermissionRoleService.InsertUpdate(model);
                return Ok(rh);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(PermissionRole model)
        {
            try
            {
                var rh = _apiPermissionRoleService.Delete(model.Id);
                return Ok(rh);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("GetById/{roleId}")]
        public IHttpActionResult GetById(int roleId)
        {
            try
            {
                var permissionRole = _apiPermissionRoleService.GetById(roleId);
                return Ok(permissionRole);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }

    }
}
