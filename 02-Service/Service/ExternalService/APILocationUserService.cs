using Common;
using Model.Auth;
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
    public interface IAPILocationUserService
    {
        IEnumerable<LocationUser> GetAll();
        ResponseHelper<LocationUser> GetById(int id);
        ResponseHelper InsertUpdate(LocationUser model);
        ResponseHelper Delete(int id);
        IEnumerable<Location> GetNonRepeatedLocations();
    }

    class APILocationUserService : IAPILocationUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<LocationUser> _locationUserRepo;
        private readonly IRepository<Location> _locationRepo;
        private readonly IRepository<ApplicationUser> _UserRepo;

        public APILocationUserService(IDbContextScopeFactory dbContextScopeFactory, IRepository<LocationUser> locationUserRepo, IRepository<Location> locationRepo, IRepository<ApplicationUser> userRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _locationUserRepo = locationUserRepo;
            _locationRepo = locationRepo;
            _UserRepo = userRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _locationUserRepo.SingleOrDefault(x => x.Id == id);
                    _locationUserRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception ex)
            {

                logger.Error(ex.Message);
                rh.SetResponse(false, ex.Message);
                return rh;
            }
        }

        public IEnumerable<LocationUser> GetAll()
        {
            var result = new List<LocationUser>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<LocationUser>(_locationUserRepo.GetAll(lu => lu.ApplicationUser, lu => lu.Location, lu => lu.ApplicationUser.Claims, lu => lu.ApplicationUser.Roles, lu => lu.ApplicationUser.Logins));
                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }

            
        }

        public ResponseHelper<LocationUser> GetById(int id)
        {
            var rh = new ResponseHelper<LocationUser>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _locationUserRepo.SingleOrDefault(l => l.Id == id, l => l.ApplicationUser, l => l.Location, l => l.ApplicationUser.Claims, l => l.ApplicationUser.Roles, l => l.ApplicationUser.Logins);
                    rh.SetResponse(true);
                    return rh;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                rh.SetResponse(false);
                return rh;
            }
            
        }

        public IEnumerable<Location> GetNonRepeatedLocations()
        {
            var listLocationUser = new List<LocationUser>();
            var listLocation = new List<Location>();
            var listaresult = new List<Location>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    listLocationUser = new List<LocationUser>(_locationUserRepo.GetAll(lu => lu.ApplicationUser, lu => lu.Location, lu => lu.ApplicationUser.Claims, lu => lu.ApplicationUser.Roles, lu => lu.ApplicationUser.Logins));
                    listLocation = new List<Location>(_locationRepo.GetAll(l => l.LocationType));
                }

                listaresult =
                   (from l in listLocation
                    join lu in listLocationUser on l.Id equals lu.Location.Id into LocationUser
                    from lul in LocationUser.DefaultIfEmpty()
                    where lul == null
                    select l).ToList<Location>();

                return listaresult;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return listaresult;
            }
        }

        public ResponseHelper InsertUpdate(LocationUser model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var locationUser = _locationUserRepo.Find(x => x.Id == model.Id).SingleOrDefault();

                    if (locationUser == null)
                    {
                        model.Location = _locationRepo.Find(y => y.Id == model.Location.Id).SingleOrDefault();
                        model.ApplicationUser = _UserRepo.Find(z => z.Id == model.ApplicationUser.Id).SingleOrDefault();
                        _locationUserRepo.Insert(model);
                    }
                    else
                    {
                        locationUser.ApplicationUser = _UserRepo.Find(z => z.Id == model.ApplicationUser.Id).SingleOrDefault();
                        locationUser.Location = _locationRepo.Find(y => y.Id == model.Location.Id).SingleOrDefault();

                        _locationUserRepo.Update(locationUser);
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
