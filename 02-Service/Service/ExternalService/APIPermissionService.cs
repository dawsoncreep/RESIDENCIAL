using Common;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.ExternalService
{
    public interface IAPIPermissionService
    {
        IEnumerable<Permission> GetAll();
        ResponseHelper<Permission> GetById(int id);
        ResponseHelper InsertUpdate(Permission model);
        ResponseHelper Delete(int id);
    }

    public class APIPermissionService : IAPIPermissionService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Permission> _permissionRepo;

        public APIPermissionService(
               IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Permission> permissionRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _permissionRepo = permissionRepo;
        }


        public ResponseHelper InsertUpdate(Permission model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var permissionById = _permissionRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (permissionById == null)
                    {
                        _permissionRepo.Insert(model);
                    }
                    else
                    {
                        permissionById.Name = model.Name;
                        permissionById.Description = model.Description;
                        permissionById.ResourceCode = model.ResourceCode;
                        permissionById.Area = model.Area;
                        permissionById.Action = model.Action;
                        permissionById.Controller = model.Controller;

                        _permissionRepo.Update(permissionById);
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

        public IEnumerable<Permission> GetAll()
        {
            var result = new List<Permission>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<Permission>(_permissionRepo.GetAll());
                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }
        }

        public ResponseHelper<Permission> GetById(int id)
        {
            var rh = new ResponseHelper<Permission>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _permissionRepo.SingleOrDefault(s => s.Id == id);
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

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _permissionRepo.SingleOrDefault(x => x.Id == id);
                    _permissionRepo.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
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
    }
}
