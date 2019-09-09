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

    public interface IAPIApplicationParametersService : IExternalService
    {
        ResponseHelper GetByKey(String key);
    }

    public class APIApplicationParametersService : IAPIApplicationParametersService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationParameters> _ApplicationParametersRepo;

        public APIApplicationParametersService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ApplicationParameters> ApplicationParametersRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _ApplicationParametersRepo = ApplicationParametersRepo;
        }


        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _ApplicationParametersRepo.SingleOrDefault(x => x.Id == id);
                    _ApplicationParametersRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Delete_OkMessage,
                        Resources.Resources.ApplicationParameters));
                }
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.ApplicationParameters));
                return rh;
            }
        }

        public ResponseHelper GetAll()
        {
            var rh = new ResponseHelper();
            var result = new List<ApplicationParameters>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<ApplicationParameters>(_ApplicationParametersRepo.GetAll());
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.ApplicationParameters));
                return rh;
            }
        }

        public ResponseHelper GetById(int id)
        {
            var rh = new ResponseHelper();
            var result = new ApplicationParameters();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _ApplicationParametersRepo.SingleOrDefault(s => s.Id == id);
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.ApplicationParameters));
                return rh;
            }
        }

        public ResponseHelper GetByKey(string key)
        {
            var rh = new ResponseHelper();
            var result = new ApplicationParameters();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _ApplicationParametersRepo.SingleOrDefault(s => s.Key == key);
                }
                rh.Result = result;
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Process_ErrorMessage,
                    Resources.Resources.ApplicationParameters));
                return rh;
            }
        }

        public ResponseHelper InsertUpdate(object pModel)
        {
            ApplicationParameters model = (ApplicationParameters)pModel;

            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var modelById = _ApplicationParametersRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (modelById == null)
                    {
                        _ApplicationParametersRepo.Insert(model);
                    }
                    else
                    {
                        modelById.Key = model.Key;
                        modelById.Value = model.Value;
                        modelById.Description = model.Description;
                        modelById.Id = model.Id;

                        _ApplicationParametersRepo.Update(modelById);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Insert_OkMessage,
                        Resources.Resources.ApplicationParameters));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.ApplicationParameters));
            }

            return rh;
        }
    }
}
