using Common;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalService
{
    public interface IAPILocationTypeService
    {
        IEnumerable<LocationType> GetAll();
        ResponseHelper<LocationType> GetById(int id);
        ResponseHelper InsertUpdate(LocationType model);
        ResponseHelper Delete(int id);
    }

    public class APILocationTypeService : IAPILocationTypeService
    {

        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<LocationType> _locationTypeRepo;


        public APILocationTypeService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<LocationType> locationTypeRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _locationTypeRepo = locationTypeRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _locationTypeRepo.SingleOrDefault(x => x.Id == id);
                    _locationTypeRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
                return rh;
            }
        }

        public IEnumerable<LocationType> GetAll()
        {
            var result = new List<LocationType>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<LocationType>(_locationTypeRepo.GetAll());
                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }
        }

        public ResponseHelper<LocationType> GetById(int id)
        {
            var rh = new ResponseHelper<LocationType>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _locationTypeRepo.SingleOrDefault(s => s.Id == id);
                }
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

        public ResponseHelper InsertUpdate(LocationType model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var permissionById = _locationTypeRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (permissionById == null)
                    {
                        _locationTypeRepo.Insert(model);
                    }
                    else
                    {
                        permissionById.Description = model.Description;
                        _locationTypeRepo.Update(permissionById);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }
    }
}
