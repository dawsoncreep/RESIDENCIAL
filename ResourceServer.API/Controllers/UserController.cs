using Common;
using NLog;
using Service.ExternalService;
using System;
using System.Linq;
using System.Web.Http;

namespace ResourceServer.API.Controllers
{
    

    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IAPIUserService _apiUserService;


        public UserController() : base()
        {
            _apiUserService = DependecyFactory.GetInstance<IAPIUserService>();
        }

        [HttpGet]
        [Route("Get/{userName}")]
        public IHttpActionResult Get(string userName)
        {
            try
            {
                var user = _apiUserService.Get(userName);
                return Ok(user);
                
            }
            catch(Exception ex)
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

                var user = _apiUserService.Get(new Guid(id));
                return Ok(user);
                
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
                var users = _apiUserService.GetAll().ToList();
                return Ok(users);
                
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
