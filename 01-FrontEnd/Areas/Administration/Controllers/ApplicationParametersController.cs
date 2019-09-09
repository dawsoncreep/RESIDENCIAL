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
    public class ApplicationParametersController : Controller
    {
        private readonly IApplicationParametersService _ApplicationParametersService = DependecyFactory.GetInstance<IApplicationParametersService>();
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        // GET: Administration/ApplicationParameters

        public ApplicationParametersController()
        {
            ViewBag.Controller = "ApplicationParameters";
            ViewBag.Area = "Administration";
            ViewBag.ItemToDelete = Resources.Resources.ApplicationParameters;
        }


        // GET: Administration/ApplicationParameters
        public ActionResult Index()
        {

            return View();
        }


        // GET: Administration/ApplicationParameters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/ApplicationParameters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationParameters model)
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
                    var rh = _ApplicationParametersService.InsertUpdate(model);
                    return RedirectToAction("Index", "ApplicationParameters", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "ApplicationParameters", new { Area = "Administration" });
            }
        }

        // GET: Administration/ApplicationParameters/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ApplicationParametersService.GetById(id));
        }

        // POST: Administration/ApplicationParameters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationParameters model)
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
                    var rh = _ApplicationParametersService.InsertUpdate(model);
                    return RedirectToAction("Index", "ApplicationParameters", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "ApplicationParameters", new { Area = "Administration" });
            }
        }

        // DELETE: Administration/ApplicationParameters/Delete/5
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
                    var rh = _ApplicationParametersService.Delete(IdFinal);
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