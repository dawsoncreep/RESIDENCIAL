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
    public class EventTypeController : Controller
    {
        private readonly IEventTypeService _eventTypeService = DependecyFactory.GetInstance<IEventTypeService>();
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public EventTypeController()
        {
            ViewBag.Controller = "EventType";
            ViewBag.Area = "Administration";
            ViewBag.ItemToDelete = Resources.Resources.EventType;
        }

        // GET: Administration/EventType
        public ActionResult Index()
        {
            
            return View();
        }


        // GET: Administration/EventType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/EventType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventType model)
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
                    var rh = _eventTypeService.InsertUpdate(model);
                    return RedirectToAction("Index", "EventType", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "EventType", new { Area = "Administration" });
            }
        }

        // GET: Administration/EventType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_eventTypeService.GetById(id));
        }

        // POST: Administration/EventType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventType model)
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
                    var rh = _eventTypeService.InsertUpdate(model);
                    return RedirectToAction("Index", "EventType", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "EventType", new { Area = "Administration" });
            }
        }

        // DELETE: Administration/EventType/Delete/5
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
                    var rh = _eventTypeService.Delete(IdFinal);
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