using Common;
using Model.Custom;
using NLog;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin,SuperUser")]
    public class ExternalUserController : Controller
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IExternalUserService _externalUserService = DependecyFactory.GetInstance<IExternalUserService>();
        private readonly IExternalTypeService _externalTypeService = DependecyFactory.GetInstance<IExternalTypeService>();
        private readonly IApplicationParametersService _applicationParametersService = DependecyFactory.GetInstance<IApplicationParametersService>();
        private readonly ILocationService _LocationService = DependecyFactory.GetInstance<ILocationService>();

        public ExternalUserController()
        {
            ViewBag.ItemToDelete = Resources.Resources.External;
            ViewBag.Controller = "ExternalUser";
            ViewBag.Area = "Administration";
        }

        // GET: Administration/External
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Location/Create
        public ActionResult Create()
        {
            ExternalUserForGridView model = new ExternalUserForGridView();
            model.lstExternalType = _externalTypeService.GetAll();
            model.lstLocations = _LocationService.GetByUserName(CurrentUserHelper.Get.UserName).ToList();
            return View(model);
        }

        // POST: Administration/External/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExternalUserForGridView model)
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
                    var urlToSaveImages = _applicationParametersService.GetByKey(Parameters.URL_IMAGES_PATH_KEY);
                    String urlImage = "";

                    if (String.IsNullOrEmpty(urlToSaveImages.Value)){
                        ModelState.AddModelError("ValidationError",Resources.Resources.ErrorMessage_InsufficientInformation);
                        return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
                    }

                    if(!SaveFileIntoDefinedPath(model.file, urlToSaveImages.Value, out urlImage))
                    {
                        ModelState.AddModelError("ProcessError",
                            String.Format(Resources.Resources.Process_ErrorMessage,
                            Resources.Resources.Save + " " +
                            Resources.Resources.Image));

                        return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
                    }

                    model.Image = urlImage;
                    var rh = _externalUserService.
                     InsertUpdate(model.
                     ToExternal(
                         _externalTypeService.GetById(Convert.ToInt32(model.ExternalTypeId)),
                         _LocationService.GetById(Convert.ToInt32(model.LocationId)) ));
                    return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
            }
        }


        // GET: Administration/External/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _externalUserService.GetById(id).ToExternalForGridView();
            model.lstExternalType = _externalTypeService.GetAll();
            model.lstLocations = _LocationService.GetByUserName(CurrentUserHelper.Get.UserName).ToList();
            
            return View(model);
        }

        // GET: Administration/External/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExternalUserForGridView model)
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
                    var urlToSaveImages = _applicationParametersService.GetByKey(Parameters.URL_IMAGES_PATH_KEY);
                    String urlImage = "";

                    if (String.IsNullOrEmpty(urlToSaveImages.Value))
                    {
                        ModelState.AddModelError("ValidationError", Resources.Resources.ErrorMessage_InsufficientInformation);
                        return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
                    }

                    if (model.file == null && String.IsNullOrEmpty(model.Image))
                    {
                        ModelState.AddModelError("ProcessError",
                        String.Format(Resources.Resources.Process_ErrorMessage,
                        Resources.Resources.Save + " " +
                        Resources.Resources.Image));

                        return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
                    }

                    if (model.file != null)
                    {
                        if (!SaveFileIntoDefinedPath(model.file, urlToSaveImages.Value, out urlImage))
                        {
                            ModelState.AddModelError("ProcessError",
                                String.Format(Resources.Resources.Process_ErrorMessage,
                                Resources.Resources.Save + " " +
                                Resources.Resources.Image));

                            return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
                        }
                        model.Image = urlImage;
                    }
                    

                    
                    var rh = _externalUserService.
                     InsertUpdate(model.
                     ToExternal(
                         _externalTypeService.GetById(Convert.ToInt32(model.ExternalTypeId)),
                         _LocationService.GetById(Convert.ToInt32(model.LocationId))));
                    return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return RedirectToAction("Index", "ExternalUser", new { Area = "Administration" });
            }
        }


        // DELETE: Administration/External/Delete/5
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
                    var rh = _externalUserService.Delete(IdFinal);
                    return Json(rh);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json(new ResponseHelper { Response = false });
            }
        }

        private bool SaveFileIntoDefinedPath(HttpPostedFileBase file, string urlServerImage, out String Image)
        {
            Image = String.Empty;
            try
            {
                
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string dir = Server.MapPath(urlServerImage);
                    string _path = Path.Combine(dir, _FileName);
                    
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    if (System.IO.File.Exists(_path))
                    {
                        System.IO.File.Delete(_path);
                    }

                    file.SaveAs(_path);
                    Image = String.Format("{0}/{1}", urlServerImage,_FileName);
                }
                return true;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
    }
}