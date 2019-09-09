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
    [RoutePrefix("api/applicationParameters")]
    public class ApplicationParametersController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIApplicationParametersService _apiApplicationParametersService;

        public ApplicationParametersController()
        {
            _apiApplicationParametersService = DependecyFactory.GetInstance<IAPIApplicationParametersService>();
        }


        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var ApplicationParameterss = _apiApplicationParametersService.GetAll();
                return Ok(ApplicationParameterss);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(ApplicationParameters model)
        {
            try
            {
                var rh = _apiApplicationParametersService.InsertUpdate(model);
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
                var rh = _apiApplicationParametersService.GetById(id);
                return Ok(rh);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("GetByKey/{key}")]
        public IHttpActionResult GetByKey(String key)
        {
            try
            {
                var rh = _apiApplicationParametersService.GetByKey(key);
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
        public IHttpActionResult Delete(ApplicationParameters model)
        {
            try
            {
                var rh = _apiApplicationParametersService.Delete(model.Id);
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
