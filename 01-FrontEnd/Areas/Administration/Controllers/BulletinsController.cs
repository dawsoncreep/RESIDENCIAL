using Common;
using Model.Domain;
using NLog;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin,SuperUser")]
    public class BulletinsController : Controller
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IBulletinesService _bulletin = DependecyFactory.GetInstance<IBulletinesService>();

        // GET: Administration/Bulletins
        public ActionResult Index()
        {
            var bulletin = _bulletin.GetAll();
            return View(bulletin);
        }


    }
}