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

namespace Service.ExternalService
{

    public interface IAPIExternalTypeService : IExternalService
    {

    }

    public class APIExternalTypeService : IAPIExternalTypeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ExternalType> _externalTypeRepo;

        public APIExternalTypeService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ExternalType> externalTypeRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _externalTypeRepo = externalTypeRepo;
        }


        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _externalTypeRepo.SingleOrDefault(x => x.Id == id);
                    _externalTypeRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Delete_OkMessage,
                        Resources.Resources.ExternalType));
                }
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.ExternalType));
                return rh;
            }
        }

        public ResponseHelper GetAll()
        {
            var rh = new ResponseHelper();
            var result = new List<ExternalType>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<ExternalType>(_externalTypeRepo.GetAll());
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.ExternalType));
                return rh;
            }
        }

        public ResponseHelper GetById(int id)
        {
            var rh = new ResponseHelper();
            var result = new ExternalType();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _externalTypeRepo.SingleOrDefault(s => s.Id == id);
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.ExternalType));
                return rh;
            }
        }

        public ResponseHelper InsertUpdate(object pModel)
        {
            ExternalType model = (ExternalType)pModel;

            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var modelById = _externalTypeRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (modelById == null)
                    {
                        _externalTypeRepo.Insert(model);
                    }
                    else
                    {
                        modelById.Description = model.Description;
                        modelById.Id = model.Id;

                        _externalTypeRepo.Update(modelById);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Insert_OkMessage,
                        Resources.Resources.ExternalType));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.ExternalType));
            }

            return rh;
        }
    }
}
