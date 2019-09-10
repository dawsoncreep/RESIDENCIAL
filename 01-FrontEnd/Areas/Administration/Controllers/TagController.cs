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
    public class TagController : Controller
    {
        private readonly ITagService _tagService = DependecyFactory.GetInstance<ITagService>();
        private readonly IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        // GET: Administration/tag

        public TagController()
        {
            ViewBag.Controller = "Tag";
            ViewBag.Area = "Administration";
            ViewBag.ItemToDelete = Resources.Resources.Tag;
        }


        // GET: Administration/tag
        public ActionResult Index()
        {

            return View();
        }


        // GET: Administration/tag/Create
        public ActionResult Create()
        {
            TagForGridView model = new TagForGridView();
            var lstUs = _userService.GetAll().ToList();
            lstUs.Insert(0, new UserForGridView {Id=string.Empty,Name = Resources.Resources.NoAssignation });
            model.lstUsers= lstUs;
            
            return View(model);
        }

        // POST: Administration/tag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag model)
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
                    var rh = _tagService.InsertUpdate(model);
                    return RedirectToAction("Index", "Tag", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "Tag", new { Area = "Administration" });
            }
        }

        // GET: Administration/tag/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _tagService.GetById(id).ToTagForGridView();
            var lstUs = _userService.GetAll().ToList();
            lstUs.Insert(0, new UserForGridView { Id = string.Empty, Name = Resources.Resources.NoAssignation });
            model.lstUsers = lstUs;
            return View(model);
        }

        // POST: Administration/tag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TagForGridView model)
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
                    var rh = _tagService.InsertUpdate(model.ToTag());
                    return RedirectToAction("Index", "Tag", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "Tag", new { Area = "Administration" });
            }
        }

        // DELETE: Administration/tag/Delete/5
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
                    var rh = _tagService.Delete(IdFinal);
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