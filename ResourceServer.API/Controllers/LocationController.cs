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
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPILocationService _apiLocationService;

        public LocationController()
        {
            _apiLocationService = DependecyFactory.GetInstance<IAPILocationService>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var eventTypes = _apiLocationService.GetAll().ToList();
                return Ok(eventTypes);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(Location model)
        {
            try
            {
                var rh = _apiLocationService.InsertUpdate(model);
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
                var rh = _apiLocationService.GetById(id);
                return Ok(rh);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("GetByUserName/{userName}")]
        public IHttpActionResult GetByUserName(String userName)
        {
            ResponseHelper<IEnumerable<Location>> rh =
                    new ResponseHelper<IEnumerable<Location>>();
            try
            {
                rh = _apiLocationService.GetByUserName(userName);
                return Ok(rh);

            }
            catch (Exception ex)
            {
                rh.SetResponse(false, m: ex.Message);
                logger.Error(ex);
                return InternalServerError();
            }

        }


        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(Location model)
        {
            try
            {
                var rh = _apiLocationService.Delete(model.Id);
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
