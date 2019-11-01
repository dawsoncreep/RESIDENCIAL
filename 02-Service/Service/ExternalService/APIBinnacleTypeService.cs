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
    public interface IAPIBinnacleTypeService : IExternalService
    {

    }

    public class APIBinnacleTypeService : IAPIBinnacleTypeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<BinnacleType> _BinnacleTypeRepo;
        private readonly IRepository<ApplicationUser> _userRepo;

        public APIBinnacleTypeService(IDbContextScopeFactory dbContextScopeFactory,
            IRepository<BinnacleType> BinnacleTypeRepo,
            IRepository<ApplicationUser> userRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _BinnacleTypeRepo = BinnacleTypeRepo;
            _userRepo = userRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _BinnacleTypeRepo.SingleOrDefault(x => x.Id == id);
                    _BinnacleTypeRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Delete_OkMessage,
                        Resources.Resources.BinnacleType));
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
            var result = new List<BinnacleType>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<BinnacleType>(_BinnacleTypeRepo.GetAll());
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.BinnacleType));
                return rh;
            }
        }

        public ResponseHelper GetById(int id)
        {
            var rh = new ResponseHelper();
            var result = new BinnacleType();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _BinnacleTypeRepo.SingleOrDefault(s => s.Id == id);
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.BinnacleType));
                return rh;
            }
        }

        public ResponseHelper InsertUpdate(object pModel)
        {
            BinnacleType model = (BinnacleType)pModel;

            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var modelById = _BinnacleTypeRepo.Find(x =>
                        x.Id == model.Id).SingleOrDefault();



                    if (modelById == null)
                    {
                        _BinnacleTypeRepo.Insert(model);
                    }
                    else
                    {
                        modelById.Id = model.Id;
                        modelById.Description = model.Description;

                        _BinnacleTypeRepo.Update(modelById);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Insert_OkMessage,
                        Resources.Resources.BinnacleType));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.BinnacleType));
            }

            return rh;
        }
    }
}
