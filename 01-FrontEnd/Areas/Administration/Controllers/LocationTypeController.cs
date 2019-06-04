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
    public class LocationTypeController : Controller
    {
        private readonly ILocationTypeService _locationTypeService = DependecyFactory.GetInstance<ILocationTypeService>();
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LocationTypeController()
        {
            ViewBag.ItemToDelete = Resources.Resources.LocationType;
            ViewBag.Controller = "LocationType";
            ViewBag.Area = "Administration";
        }


        // GET: Administration/LocationType
        public ActionResult Index()
        {
            return View();
        }


        // GET: Administration/LocationType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/LocationType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationType model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    throw new InvalidOperationException();
                }
                else
                {
                    var rh = _locationTypeService.InsertUpdate(model);
                    return RedirectToAction("Index", "LocationType", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "EventType", new { Area = "Administration" });
            }
        }

        // GET: Administration/LocationType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_locationTypeService.GetById(id));
        }

        // POST: Administration/LocationType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationType model)
        {
            try
            {
                // TODO: Add update logic here

                if (!ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    throw new InvalidOperationException();
                }
                else
                {
                    var rh = _locationTypeService.InsertUpdate(model);
                    return RedirectToAction("Index", "LocationType", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "LocationType", new { Area = "Administration" });
            }
        }

        // DELETE: Administration/LocationType/Delete/5
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
                    var rh = _locationTypeService.Delete(IdFinal);
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