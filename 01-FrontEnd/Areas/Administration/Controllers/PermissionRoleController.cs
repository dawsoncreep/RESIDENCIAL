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
    public class PermissionRoleController : Controller
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IRoleService _role = DependecyFactory.GetInstance<IRoleService>();
        private readonly IPermissionRoleService _permissionRole = DependecyFactory.GetInstance<IPermissionRoleService>();
        private readonly IPermissionService _permission = DependecyFactory.GetInstance<IPermissionService>();

        // GET: Administration/PermissionRole
        public ActionResult Index()
        {
            var permissionRoles = _permissionRole.GetAll();

            return View(permissionRoles);
        }

        public ActionResult Create()
        {
            PermissionRoleForGridView model = new PermissionRoleForGridView();
            model.lstPermissions = _permission.GetAll();
            model.lstRoles = _role.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PermissionRoleForGridView model)
        {
            try
            {
                var rh = _permissionRole.
                     InsertUpdate(model.ToPermissionRole());
                return RedirectToAction("Index", "PermissionRole", new { Area = "Administration" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "PermissionRole", new { Area = "Administration" });
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
                    var rh = _permissionRole.Delete(IdFinal);
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