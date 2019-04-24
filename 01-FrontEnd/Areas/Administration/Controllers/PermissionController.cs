using Common;
using Model.Custom;
using Model.Domain;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin,SuperUser")]
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService = DependecyFactory.GetInstance<IPermissionService>();
        // GET: Administration/Permission
        public ActionResult Index()
        {
            return View(_permissionService.GetAll());
        }


        // GET: Administration/Permission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Permission/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Permission model)
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
                    var rh = _permissionService.InsertUpdate(model);
                    return RedirectToAction("Index", "Permission", new { Area = "Administration" });
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Permission", new { Area = "Administration" });
            }
        }

        // GET: Administration/Permission/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_permissionService.GetById(id));
        }

        // POST: Administration/Permission/Edit/5
        [HttpPost]
        public ActionResult Edit(Permission model)
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
                    var rh = _permissionService.InsertUpdate(model);
                    return RedirectToAction("Index", "Permission", new { Area = "Administration" });
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Permission", new { Area = "Administration" });
            }
        }

        // DELETE: Administration/Permission/Delete/5
        [HttpPost]
        public ActionResult Delete(String id)
        {
            try
            {
                int IdFinal = 0;
                if(!int.TryParse(id, out IdFinal))
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
                    var rh = _permissionService.Delete(IdFinal);
                    return Json(rh);
                }
            }
            catch (Exception ex)
            {
                return Json(new ResponseHelper {Response = false });
            }
        }
    }
}
