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
    public interface IAPILocationService
    {
        IEnumerable<Location> GetAll();
        ResponseHelper<IEnumerable<Location>> GetByUserName(String userName);
        ResponseHelper<Location> GetById(int id);
        ResponseHelper InsertUpdate(Location model);
        ResponseHelper Delete(int id);
    }

    public class APILocationService : IAPILocationService
    {

        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Location> _locationRepo;
        private readonly IRepository<LocationUser> _locationUserRepo;
        private readonly IRepository<LocationType> _locationTypeRepo;


        public APILocationService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Location> locationRepo,
            IRepository<LocationType> locationTypeRepo,
            IRepository<LocationUser> locationUserRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _locationRepo = locationRepo;
            _locationTypeRepo = locationTypeRepo;
            _locationUserRepo = locationUserRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _locationRepo.SingleOrDefault(x => x.Id == id);
                    _locationRepo.Delete(model);

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

        public IEnumerable<Location> GetAll()
        {
            var result = new List<Location>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<Location>(_locationRepo.GetAll(s => s.LocationType));
                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }
        }

        public ResponseHelper<Location> GetById(int id)
        {
            var rh = new ResponseHelper<Location>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _locationRepo.SingleOrDefault(s => s.Id == id, s => s.LocationType);
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

        public ResponseHelper<IEnumerable<Location>> GetByUserName(string userName)
        {
            var rh = new ResponseHelper<IEnumerable<Location>>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    //rh.Result = _locationRepo.SingleOrDefault(s => s.Id == id, s => s.LocationType);
                    rh.Result = (from l in _locationRepo.GetAll()
                                 join lu in _locationUserRepo.GetAll(s => s.Location , r => r.ApplicationUser)
                                 on l.Id equals lu.Location.Id
                                 where lu.ApplicationUser.UserName == userName
                                 select l).ToList();
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

        public ResponseHelper InsertUpdate(Location model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var locationById = _locationRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (locationById == null)
                    {
                        model.LocationType = _locationTypeRepo.
                            Find(y => y.Id == model.LocationType.Id).SingleOrDefault();

                        _locationRepo.Insert(model);
                    }
                    else
                    {
                        locationById.Description = model.Description;
                        locationById.InNumber = model.InNumber;
                        locationById.OutNumber = model.OutNumber;
                        locationById.Street = model.Street;
                        locationById.Name = model.Name;
                        locationById.LocationType = _locationTypeRepo.
                            Find(y => y.Id == model.LocationType.Id).SingleOrDefault();

                        _locationRepo.Update(locationById);
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
