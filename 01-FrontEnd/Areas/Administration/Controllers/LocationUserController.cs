using Common;
using Model.Custom;
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
    public class LocationUserController : Controller
    {

        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly ILocationService _locationService = DependecyFactory.GetInstance<ILocationService>();
        private readonly IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private readonly ILocationUserService _locationUserService = DependecyFactory.GetInstance<ILocationUserService>();

        // GET: Administration/LocationUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            LocationUserForGridView model = new LocationUserForGridView();
            model.lstLocation = _locationService.GetAll();
            model.lstAplicationUser = _userService.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationUserForGridView model)
        {
            try
            {
                var rh = _locationUserService.
                     InsertUpdate(model.ToLocationUser());
                return RedirectToAction("Index", "LocationUser", new { Area = "Administration" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "LocationUser", new { Area = "Administration" });
            }
        }

        public ActionResult Edit(int id)
        {
            var model = _locationUserService.GetById(id).ToLocationUserForGridView();
            model.lstLocation = _locationService.GetAll();
            ViewBag.Name = string.Format("  {0} {1}", model.ApplicationUser.UserName, model.Location.Name);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationUserForGridView model)
        {
            try
            {
                var rh = _locationUserService.
                     InsertUpdate(model.ToLocationUser());
                return RedirectToAction("Index", "LocationUser", new { Area = "Administration" });
            }
            catch (Exception ex)
            {

                logger.Error(ex);
                return RedirectToAction("Index", "LocationUser", new { Area = "Administration" });
            }
        }

        [HttpPost]
        public ActionResult Delete(String id)
        {
            try
            {
                int IdFinal = 0;
                if (!int.TryParse(id, out IdFinal))
                {
                    ModelState.AddModelError(Resources.Resources.Delete,
                        String.Format(Resources.Resources.Process_ErrorMessage,
                        Resources.Resources.Delete));

                    return Json(new ResponseHelper { Response = false });
                }

                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    var rh = _locationUserService.Delete(IdFinal);
                    return Json(rh);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json(new ResponseHelper { Response = false });
            }
        }

    }
}