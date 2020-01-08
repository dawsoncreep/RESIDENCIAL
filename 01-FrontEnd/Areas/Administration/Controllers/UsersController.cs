using Auth.Service;
using Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Model.Auth;
using Model.Custom;
using NLog;
using Persistence.DatabaseContext;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Areas.Administration.Controllers
{
    [Authorize(Roles ="Admin,SuperUser,ClusterAdministrator")]
    public class UsersController : Controller
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        private ApplicationRoleManager _roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        private ApplicationUserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private readonly IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private readonly IRoleService _roleService = DependecyFactory.GetInstance<IRoleService>();

        // GET: User
        public ActionResult Index()
        {
            var model = _userService.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            UserForGridView model = new UserForGridView();
            model.lstRoles = _roleService.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(UserForGridView newUser)
        {
            try
            {

                var role = _roleManager.FindById(newUser.role.Id);
                var User = newUser.ToUser();
                var result = _userService.InsertUpdate(User);
                var UserR = _userManager.FindByName(User.UserName);
                var roleUser = new ApplicationUserRole
                {
                    RoleId = newUser.role.Id,
                    UserId = UserR.Id
                };

                var roleresult = AddRole(roleUser);

                return RedirectToAction("Index", "Users", new { Area = "Administration" });
            }
            catch (Exception e)
            {
                logger.Error(e);
                return RedirectToAction("Index", "Users", new { Area = "Administration" });
            }
            
        }

        public async Task<ActionResult> Get(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            ViewBag.Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList();

            return View(model);
        }

        public async Task<ActionResult> AddRole(ApplicationUserRole role)
        {
            if (!_userManager.IsInRoleAsync(role.UserId, role.RoleId).Result)
            {
                var result = await _userManager.AddToRoleAsync(role.UserId, role.RoleId);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First());
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(string id)
        {
            var model = await  _userManager.FindByIdAsync(id);
            var user = model.ToUserForGridView();
            user.lstRoles = _roleManager.Roles.ToList();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserForGridView model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                var userRole = new ApplicationUserRole();

                user.Name = model.Name ?? user.Name;
                user.LastName = model.LastName ?? user.LastName;
                user.PasswordHash = model.PassWord ?? user.PasswordHash;
                user.MotherSurname = model.MotherSurname ?? user.MotherSurname;
                user.Email = model.Email ?? user.Email;

                if(user.Roles.Count != 0)
                {
                    userRole.UserId = user.Id;
                    userRole.RoleId = user.Roles.ToList().FirstOrDefault().RoleId;
                }
                

                var result = await _userManager.UpdateAsync(user);
                var resultRU = _userService.DeleteUserRole(userRole);
                var resultRole = await _userManager.AddToRoleAsync(user.Id, model.role.Id);
                if (!result.Succeeded || !result.Succeeded)
                {
                    throw new Exception(result.Errors.First());
                }

                return RedirectToAction("Index", "Users", new { Area = "Administration" });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "Users", new { Area = "Administration" });
            }
        }
    }
}