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
    [RoutePrefix("api/external")]
    public class ExternalController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIExternalUserService _apiExternalService;

        public ExternalController()
        {
            _apiExternalService = DependecyFactory.GetInstance<IAPIExternalUserService>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var external = _apiExternalService.GetAll();
                return Ok(external);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(External model)
        {
            try
            {
                var rh = _apiExternalService.InsertUpdate(model);
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
                var rh = _apiExternalService.GetById(id);
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
        public IHttpActionResult Delete(External model)
        {
            try
            {
                var rh = _apiExternalService.Delete(model.Id);
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
