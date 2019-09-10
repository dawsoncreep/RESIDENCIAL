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
    [RoutePrefix("api/tag")]
    public class TagController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPITagService _apitagService;

        public TagController()
        {
            _apitagService = DependecyFactory.GetInstance<IAPITagService>();
        }


        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var tags = _apitagService.GetAll();
                return Ok(tags);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("InsertUpdate")]
        public IHttpActionResult InsertUpdate(Tag model)
        {
            try
            {
                var rh = _apitagService.InsertUpdate(model);
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
                var rh = _apitagService.GetById(id);
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
        public IHttpActionResult Delete(Tag model)
        {
            try
            {
                var rh = _apitagService.Delete(model.Id);
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
