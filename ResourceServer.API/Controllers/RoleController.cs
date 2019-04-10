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
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIRoleService _apiRoleService;


        public RoleController() : base()
        {
            _apiRoleService = DependecyFactory.GetInstance<IAPIRoleService>();
        }

        [HttpGet]
        [Route("Get/{roleName}")]
        public IHttpActionResult Get(string roleName)
        {
            try
            {
                var role = _apiRoleService.Get(roleName);
                return Ok(role);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetById(String id)
        {
            try
            {

                var role = _apiRoleService.Get(new Guid(id));
                return Ok(role);

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
                var roles = _apiRoleService.GetAll().ToList();
                return Ok(roles);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
