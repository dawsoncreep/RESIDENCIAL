using Common;
using Model.Domain;
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
    [RoutePrefix("api/permission")]
    public class PermissionController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIPermissionService _apiPermissionService;


        public PermissionController() : base()
        {
            _apiPermissionService = DependecyFactory.GetInstance<IAPIPermissionService>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var permissions = _apiPermissionService.GetAll().ToList();
                return Ok(permissions);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(Permission model)
        {
            try
            {
                var rh = _apiPermissionService.InsertUpdate(model);
                return Ok(rh);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var rh = _apiPermissionService.GetById(id);
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
        public IHttpActionResult Delete(Permission model)
        {
            try
            {
                var rh = _apiPermissionService.Delete(model.Id);
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
