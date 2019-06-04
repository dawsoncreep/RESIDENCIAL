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

namespace FrontEnd.Areas.Colonial.Controllers
{
    [Authorize(Roles = "Admin,SuperUser")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService = DependecyFactory.GetInstance<IEventService>();
        private readonly IEventTypeService _eventTypeService = DependecyFactory.GetInstance<IEventTypeService>();
        private readonly ILocationService _location = DependecyFactory.GetInstance<ILocationService>();
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public EventController()
        {
            ViewBag.ItemToDelete = Resources.Resources.Event;
            ViewBag.Controller = "Event";
            ViewBag.Area = "Colonial";
        }

        // GET: Colonial/Event
        public ActionResult Index()
        {
            return View();
        }

        // GET: Colonial/EventT/Create
        public ActionResult Create()
        {
            EventForGridView model = new EventForGridView();
            model.lstEventType = _eventTypeService.GetAll().ToList();
            model.lstLocation = _location.GetByUserName(CurrentUserHelper.Get.UserName).ToList();
            model.lstExternal = new List<External>() { };
            return View(model);
        }

        // POST: Colonial/Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventForGridView model)
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
                    model.Location = _location.GetById(Convert.ToInt32(model.LocationId));
                    model.EventType = _eventTypeService.GetById(Convert.ToInt32(model.EventTypeId));
                    //dummy external.
                    model.External = new External
                    {
                        FirstName = "VELEZ",
                        LastName = "GUZMAN",
                        Name = "MANUEL"
                    };

                    var rh = _eventService.InsertUpdate(model.ToEvent());
                    return RedirectToAction("Index", "Event", new { Area = "Colonial" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "Event", new { Area = "Colonial" });
            }
        }

        // GET: Administration/Location/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _eventService.GetById(id).ToEventForGridView();
            model.lstEventType = _eventTypeService.GetAll().ToList();
            model.lstLocation = _location.GetByUserName(CurrentUserHelper.Get.UserName).ToList();
            model.lstExternal = new List<External>() { };

            return View(model);
        }

        // POST: Colonial/Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventForGridView model)
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

                    model.Location = _location.GetById(Convert.ToInt32(model.LocationId));
                    model.EventType = _eventTypeService.GetById(Convert.ToInt32(model.EventTypeId));

                    var rh = _eventService.InsertUpdate(model.ToEvent());
                    return RedirectToAction("Index", "Event", new { Area = "Colonial" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "Event", new { Area = "Colonial" });
            }
        }

        // DELETE: Colonial/Event/Delete/5
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
                    var rh = _eventService.Delete(IdFinal);
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
