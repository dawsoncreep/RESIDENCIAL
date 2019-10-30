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

    public interface IAPIBulletinsService
    {
        IEnumerable<Bulletin> GetAll();
        ResponseHelper<Bulletin> GetById(int id);
        ResponseHelper InsertUpdate(Bulletin model);
        ResponseHelper Delete(int id);
    }

    public class APIBulletinsService : IAPIBulletinsService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Bulletin> _bulletinRepo;

        public APIBulletinsService(IDbContextScopeFactory dbContextScopeFactory)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _bulletinRepo.SingleOrDefault(x => x.Id == id);
                    _bulletinRepo.Delete(model);

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

        public IEnumerable<Bulletin> GetAll()
        {
            var result = new List<Bulletin>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<Bulletin>(_bulletinRepo.GetAll(bu => bu.Id));
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return result;
            }
        }

        public ResponseHelper<Bulletin> GetById(int id)
        {
            var rh = new ResponseHelper<Bulletin>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _bulletinRepo.SingleOrDefault(bu => bu.Id == id);
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

        public ResponseHelper InsertUpdate(Bulletin model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var bulletin = _bulletinRepo.Find(x => x.Id == model.Id).SingleOrDefault();

                    if (bulletin == null)
                    {
                        _bulletinRepo.Insert(model);
                    }
                    else
                    {
                        _bulletinRepo.Update(bulletin);
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
