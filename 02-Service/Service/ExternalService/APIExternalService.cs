using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using Resources;

namespace Service.ExternalService
{
    public interface IAPIExternalService : IExternalService
    {

    }

    public class APIExternalService : IAPIExternalService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<External> _externalRepo;
        private readonly IRepository<ExternalType> _externalTypeRepo;


        public APIExternalService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<External> externalRepo,
            IRepository<ExternalType> externalTypeRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _externalRepo = externalRepo;
            _externalTypeRepo = externalTypeRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _externalRepo.SingleOrDefault(x => x.Id == id);
                    _externalRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true,String.Format(Resources.Resources.Delete_OkMessage,
                        Resources.Resources.External));
                }
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.External));
                return rh;
            }
        }

        public ResponseHelper GetAll()
        {
            var rh = new ResponseHelper();
            var result = new List<External>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<External>(_externalRepo.GetAll(et => et.ExternalType));
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false);
                return rh;
            }
            
        }

        public ResponseHelper GetById(int id)
        {
            var rh = new ResponseHelper();
            var result = new External();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _externalRepo.SingleOrDefault(s => s.Id == id, s => s.ExternalType);
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false);
                return rh;
            }
        }

        public ResponseHelper InsertUpdate(object pModel)
        {
            External model = (External)pModel;

            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var modelById = _externalRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (modelById == null)
                    {
                        model.ExternalType = _externalTypeRepo.
                            Find(f => f.Id == model.ExternalType.Id).SingleOrDefault();

                        model.CreatedAt = DateTime.Now;
                        model.CreatedBy = CurrentUserHelper.Get.UserName;
                        _externalRepo.Insert(model);
                    }
                    else
                    {
                        modelById.UpdatedAt = DateTime.Now;
                        modelById.UpdatedBy = CurrentUserHelper.Get.UserName;

                        modelById.ExternalType = _externalTypeRepo.Find(f => f.Id == model.ExternalType.Id).SingleOrDefault();
                        modelById.FirstName = model.FirstName;
                        modelById.Name = model.Name;
                        modelById.LastName = model.LastName;
                        modelById.LicensePlate = model.LicensePlate;
                        modelById.UrlImage = model.UrlImage;
                        modelById.Id = model.Id;

                        _externalRepo.Update(modelById);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true,String.Format(Resources.Resources.Insert_OkMessage,
                        Resources.Resources.External));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.External));
            }

            return rh;
        }
    }
}
