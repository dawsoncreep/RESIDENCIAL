using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.ExternalService;
using Common;
using Model.Domain;

namespace ResourceServer.API.Controllers
{
    [RoutePrefix("api/bulletin")]
    public class BulletinController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIBulletinsService _apiBulletinService;

        public BulletinController()
        {
            _apiBulletinService = DependecyFactory.GetInstance<IAPIBulletinsService>();
        }

        [HttpGet]
        [Route("GetById/{roleId}")]
        public IHttpActionResult GetById(int Id)
        {
            try
            {
                var Bulletin = _apiBulletinService.GetById(Id);
                return Ok(Bulletin);
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
                var Bulletins = _apiBulletinService.GetAll();
                return Ok(Bulletins);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(Bulletin model)
        {
            try
            {
                var rh = _apiBulletinService.InsertUpdate(model);
                return Ok(rh);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(PermissionRole model)
        {
            try
            {
                var rh = _apiBulletinService.Delete(model.Id);
                return Ok(rh);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError();
            }
        }

    }
}