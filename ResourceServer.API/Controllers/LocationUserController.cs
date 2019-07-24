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
    [RoutePrefix("api/locationuser")]
    public class LocationUserController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPILocationUserService _apiLocationUserService;

        public LocationUserController()
        {
            _apiLocationUserService = DependecyFactory.GetInstance<IAPILocationUserService>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var eventTypes = _apiLocationUserService.GetAll().ToList();
                return Ok(eventTypes);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetNonRepeatedLocations")]
        public IHttpActionResult GetNonRepeatedLocations()
        {
            try
            {
                var eventTypes = _apiLocationUserService.GetNonRepeatedLocations().ToList();
                return Ok(eventTypes);

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
                var eventTypes = _apiLocationUserService.GetById(id);
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
        public IHttpActionResult InsertUpdate(LocationUser model)
        {
            try
            {
                var rh = _apiLocationUserService.InsertUpdate(model);
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
        public IHttpActionResult Delete(Location model)
        {
            try
            {
                var rh = _apiLocationUserService.Delete(model.Id);
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
