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
    public interface IAPIEventService
    {
        IEnumerable<Event> GetAll();
        ResponseHelper<Event> GetById(int id);
        ResponseHelper InsertUpdate(Event model);
        ResponseHelper Delete(int id);
    }

    public class APIEventService : IAPIEventService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Event> _eventRepo;
        private readonly IRepository<EventType> _eventTypeRepo;
        private readonly IRepository<Location> _locationRepo;

        public APIEventService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Event> eventRepo,
            IRepository<EventType> eventTypeRepo,
            IRepository<Location> locationRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _eventRepo = eventRepo;
            _eventTypeRepo = eventTypeRepo;
            _locationRepo = locationRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _eventRepo.SingleOrDefault(x => x.Id == id);
                    _eventRepo.Delete(model);

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

        public IEnumerable<Event> GetAll()
        {
            var result = new List<Event>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<Event>(_eventRepo.GetAll(et => et.EventType, l => l.Location));
                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }
        }

        public ResponseHelper<Event> GetById(int id)
        {
            var rh = new ResponseHelper<Event>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _eventRepo.SingleOrDefault(s => s.Id == id, l => l.Location, et => et.EventType);
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

        public ResponseHelper InsertUpdate(Event model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var modelById = _eventRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (modelById == null)
                    {
                        model.Location = _locationRepo.
                            Find(f => f.Id == model.Location.Id).SingleOrDefault();
                        model.EventType = _eventTypeRepo.
                            Find(f => f.Id == model.EventType.Id).SingleOrDefault();
                        _eventRepo.Insert(model);
                    }
                    else
                    {
                        modelById.DateStart = model.DateStart;
                        modelById.DateEnd = model.DateEnd;
                        modelById.EventType = _eventTypeRepo.Find(f => f.Id == model.EventType.Id).SingleOrDefault();
                        modelById.Description = model.Description;
                        modelById.Location = _locationRepo.Find(f => f.Id == model.Location.Id).SingleOrDefault();
                        modelById.Name = model.Name;
                        modelById.Id = model.Id;

                        _eventRepo.Update(modelById);
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
