using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.Auth;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service.ExternalService
{

    public interface IAPITagService : IExternalService
    {

    }

    public class APITagService : IAPITagService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Tag> _tagRepo;
        private readonly IRepository<ApplicationUser> _userRepo;

        public APITagService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Tag> tagRepo,
            IRepository<ApplicationUser> userRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _tagRepo = tagRepo;
            _userRepo = userRepo;
        }


        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _tagRepo.SingleOrDefault(x => x.Id == id);
                    _tagRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Delete_OkMessage,
                        Resources.Resources.Tag));
                }
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.Tag));
                return rh;
            }
        }

        public ResponseHelper GetAll()
        {
            var rh = new ResponseHelper();
            var result = new List<Tag>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<Tag>(_tagRepo.GetAll(u => u.ApplicationUser,
                        r => r.ApplicationUser.Roles,
                        c => c.ApplicationUser.Claims,
                        l => l.ApplicationUser.Logins));
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.Tag));
                return rh;
            }
        }

        public ResponseHelper GetById(int id)
        {
            var rh = new ResponseHelper();
            var result = new Tag();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _tagRepo.SingleOrDefault(s => s.Id == id, u => u.ApplicationUser,
                        r => r.ApplicationUser.Roles,
                        c => c.ApplicationUser.Claims,
                        l => l.ApplicationUser.Logins);
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.Tag));
                return rh;
            }
        }

        public ResponseHelper InsertUpdate(object pModel)
        {
            Tag model = (Tag)pModel;

            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var modelById = _tagRepo.Find(x =>
                        x.Id == model.Id,
                            u => u.ApplicationUser,
                            u => u.ApplicationUser.Roles,
                            u => u.ApplicationUser.Claims,
                            u => u.ApplicationUser.Logins
                        ).SingleOrDefault();



                    if (modelById == null)
                    {
                        model.CreatedAt = DateTime.Now;
                        model.CreatedBy = CurrentUserHelper.Get.UserName;

                        model.ApplicationUser = _userRepo.
                            Find(f => f.Id == model.ApplicationUser.Id).SingleOrDefault();

                        _tagRepo.Insert(model);
                    }
                    else
                    {
                        modelById.UpdatedAt = DateTime.Now;
                        modelById.UpdatedBy = CurrentUserHelper.Get.UserName;

                        modelById.TagCode = model.TagCode;
                        modelById.VehicleBrand = model.VehicleBrand;
                        modelById.VehicleModel = model.VehicleModel;
                        modelById.VehicleYear = model.VehicleYear;
                        modelById.Observations = model.Observations;
                        modelById.ApplicationUser = _userRepo.
                            Find(f => f.Id == model.ApplicationUser.Id,
                            r => r.Roles,
                            r => r.Claims,
                            r => r.Logins).SingleOrDefault();
                        modelById.Id = model.Id;

                        _tagRepo.Update(modelById);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Insert_OkMessage,
                        Resources.Resources.Tag));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.Tag));
            }

            return rh;
        }
    }
}
