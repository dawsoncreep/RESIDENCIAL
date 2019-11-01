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
    [Authorize]
    [RoutePrefix("api/BinnacleType")]
    public class BinnacleTypeController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIBinnacleTypeService _apiBinnacleTypeService;

        public BinnacleTypeController()
        {
            _apiBinnacleTypeService = DependecyFactory.GetInstance<IAPIBinnacleTypeService>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_apiBinnacleTypeService.GetAll());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(BinnacleType model)
        {
            try
            {
                return Ok(_apiBinnacleTypeService.InsertUpdate(model));
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
                return Ok(_apiBinnacleTypeService.GetById(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }

        }


        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(Tag model)
        {
            try
            {
                return Ok(_apiBinnacleTypeService.Delete(model.Id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }

        }
    }
}