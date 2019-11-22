using Common;
using Model.Custom;
using Model.Domain;
using NLog;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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

            return View(model);
        }

        
        public JsonResult Details(int Id)
        {

            ExternalBinnacle extBin =  _externalBinnacle.GetById(Id);

            string html = RenderPartialToString("BinnaclePhotos", extBin, this.ControllerContext);

            return new JsonResult() {Data = RenderPartialToString("BinnaclePhotos", extBin, this.ControllerContext),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static string RenderPartialToString(string viewName, object model, ControllerContext ControllerContext)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");
            ViewDataDictionary ViewData = new ViewDataDictionary();
            TempDataDictionary TempData = new TempDataDictionary();
            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }

        }
    }
}