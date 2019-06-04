using Common;
using Model.Custom;
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
    public class LocationController : Controller
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly ILocationTypeService _locationTypeService = DependecyFactory.GetInstance<ILocationTypeService>();
        private readonly ILocationService _locationService = DependecyFactory.GetInstance<ILocationService>();

        public LocationController()
        {
            ViewBag.ItemToDelete = Resources.Resources.Location;
            ViewBag.Controller = "Location";
            ViewBag.Area = "Administration";
        }

        // GET: Administration/Location
        public ActionResult Index()
        {
            return View();
        }


        // GET: Administration/Location/Create
        public ActionResult Create()
        {
            LocationForGridView model = new LocationForGridView();
            model.lstLocationType = _locationTypeService.GetAll();
            return View(model);
        }

        // POST: Administration/LocationType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationForGridView model)
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
                       var rh = _locationService.
                        InsertUpdate(model.
                        ToLocation(_locationTypeService.
                            GetById(Convert.ToInt32(model.LocationTypeId))));
                    return RedirectToAction("Index", "Location", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "Location", new { Area = "Administration" });
            }
        }

        // GET: Administration/Location/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _locationService.GetById(id).ToLocationForGridView();
            model.lstLocationType = _locationTypeService.GetAll();
            return View(model);
        }

        // POST: Administration/Location/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationForGridView model)
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
                    var rh = _locationService.
                     InsertUpdate(model.
                     ToLocation(_locationTypeService.
                         GetById(Convert.ToInt32(model.LocationTypeId))));
                    return RedirectToAction("Index", "Location", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "Location", new { Area = "Administration" });
            }
        }

        // DELETE: Administration/Location/Delete/5
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
                    var rh = _locationService.Delete(IdFinal);
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