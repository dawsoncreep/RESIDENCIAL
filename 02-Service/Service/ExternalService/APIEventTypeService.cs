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
    public interface IAPIEventTypeService
    {
        ResponseHelper GetAll();
        ResponseHelper<EventType> GetById(int id);
        ResponseHelper InsertUpdate(EventType model);
        ResponseHelper Delete(int id);
    }

    public class APIEventTypeService : IAPIEventTypeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<EventType> _eventTypeRepo;

        public APIEventTypeService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<EventType> eventTypeRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _eventTypeRepo = eventTypeRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _eventTypeRepo.SingleOrDefault(x => x.Id == id);
                    _eventTypeRepo.Delete(model);

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

        public ResponseHelper GetAll()
        {
            var rh = new ResponseHelper();
            var result = new List<EventType>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<EventType>(_eventTypeRepo.GetAll());
                }
                rh.Result = result;
                rh.SetResponse(true);

                return rh;
            }
            catch (Exception e)
            {
                rh.Result = result;
                rh.SetResponse(false);
                logger.Error(e.Message);
                return rh;
            }
        }

        public ResponseHelper<EventType> GetById(int id)
        {
            var rh = new ResponseHelper<EventType>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _eventTypeRepo.SingleOrDefault(s => s.Id == id);
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

        public ResponseHelper InsertUpdate(EventType model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var permissionById = _eventTypeRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (permissionById == null)
                    {
                        _eventTypeRepo.Insert(model);
                    }
                    else
                    {
                        permissionById.Description = model.Description;
                        permissionById.IsTiedToExternalUser = model.IsTiedToExternalUser;
                        _eventTypeRepo.Update(permissionById);
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
