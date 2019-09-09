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
    [RoutePrefix("api/externaltype")]
    public class ExternalTypeController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIExternalTypeService _apiExternalTypeService;

        public ExternalTypeController()
        {
            _apiExternalTypeService = DependecyFactory.GetInstance<IAPIExternalTypeService>();
        }


        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var externalTypes = _apiExternalTypeService.GetAll();
                return Ok(externalTypes);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(ExternalType model)
        {
            try
            {
                var rh = _apiExternalTypeService.InsertUpdate(model);
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
                var rh = _apiExternalTypeService.GetById(id);
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
        public IHttpActionResult Delete(ExternalType model)
        {
            try
            {
                var rh = _apiExternalTypeService.Delete(model.Id);
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
