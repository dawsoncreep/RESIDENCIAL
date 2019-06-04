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

        // GET: Administration/PermissionRole
        public ActionResult Index()
        {
            var permissionRoles = _permissionRole.GetAll();

            return View(permissionRoles);
        }
    }
}