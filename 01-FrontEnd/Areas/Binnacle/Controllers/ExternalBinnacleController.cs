using Common;
using Model.Custom;
using NLog;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Areas.Binnacle.Controllers
{
    [Authorize(Roles = "Admin,SuperUser")]
    public class ExternalBinnacleController : Controller
    {

        private readonly IExternalBinnacleService _externalBinnacle = DependecyFactory.GetInstance<IExternalBinnacleService>();
        private readonly IExternalTypeService _externalType = DependecyFactory.GetInstance<IExternalTypeService>();
        private static ILogger logger = LogManager.GetCurrentClassLogger();


        public ExternalBinnacleController()
        {
            ViewBag.ItemToDelete = Resources.Resources.ExternalBinnacle;
            ViewBag.Controller = "ExternalBinnacle";
            ViewBag.Area = "Binnacle";
        }

        // GET: Binnacle/ExternalBinnacle
        public ActionResult Index()
        {
            ExternalBinnacleForGridView model = new ExternalBinnacleForGridView();
            model.lstExternalType = _externalType.GetAll().ToList();

            return View();
        }
    }
}