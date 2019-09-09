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
    public class ExternalTypeController : Controller
    {
        private readonly IExternalTypeService _externalTypeService = DependecyFactory.GetInstance<IExternalTypeService>();
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        // GET: Administration/ExternalType

        public ExternalTypeController()
        {
            ViewBag.Controller = "ExternalType";
            ViewBag.Area = "Administration";
            ViewBag.ItemToDelete = Resources.Resources.ExternalType;
        }


        // GET: Administration/ExternalType
        public ActionResult Index()
        {

            return View();
        }


        // GET: Administration/ExternalType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/ExternalType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExternalType model)
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
                    var rh = _externalTypeService.InsertUpdate(model);
                    return RedirectToAction("Index", "ExternalType", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "ExternalType", new { Area = "Administration" });
            }
        }

        // GET: Administration/ExternalType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_externalTypeService.GetById(id));
        }

        // POST: Administration/ExternalType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExternalType model)
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
                    var rh = _externalTypeService.InsertUpdate(model);
                    return RedirectToAction("Index", "ExternalType", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "ExternalType", new { Area = "Administration" });
            }
        }

        // DELETE: Administration/ExternalType/Delete/5
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
                    var rh = _externalTypeService.Delete(IdFinal);
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