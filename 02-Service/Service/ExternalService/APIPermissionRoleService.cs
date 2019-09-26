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
    public interface IAPIPermissionRoleService
    {
        IEnumerable<PermissionRole> GetByRoleId(Guid roleId);
        IEnumerable<PermissionRole> GetAll();
        ResponseHelper InsertUpdate(PermissionRole model);
        ResponseHelper Delete(int Id);
        ResponseHelper<PermissionRole> GetById(int id);
    }

    class APIPermissionRoleService : IAPIPermissionRoleService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<PermissionRole> _permissionRoleRepo;
        private readonly IRepository<ApplicationRole> _applicationRoleRepo;
        private readonly IRepository<Permission> _permissionRepo;

        public APIPermissionRoleService(
               IDbContextScopeFactory dbContextScopeFactory,
            IRepository<PermissionRole> permissionRoleRepo, IRepository<ApplicationRole> applicationRoleRepo, IRepository<Permission> permissionRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _permissionRoleRepo = permissionRoleRepo;
            _applicationRoleRepo = applicationRoleRepo;
            _permissionRepo = permissionRepo;
        }

        public ResponseHelper Delete(int Id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _permissionRoleRepo.SingleOrDefault(x => x.Id == Id);
                    _permissionRoleRepo.Delete(model);

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

        public IEnumerable<PermissionRole> GetAll()
        {
            var result = new List<PermissionRole>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<PermissionRole>(_permissionRoleRepo.GetAll(
                        s => s.ApplicationRole.Users,
                        s => s.Permission));

                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }
        }

        public ResponseHelper<PermissionRole> GetById(int id)
        {
            var rh = new ResponseHelper<PermissionRole>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    rh.Result = _permissionRoleRepo.SingleOrDefault(l => l.Id == id, l => l.ApplicationRole, l => l.Permission, l => l.ApplicationRole.Users);
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

        public IEnumerable<PermissionRole> GetByRoleId(Guid roleId)
        {
            var result = new List<PermissionRole>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<PermissionRole>(_permissionRoleRepo.GetAll(
                        s => s.ApplicationRole.Users,
                        s => s.Permission).
                        Where(w => w.ApplicationRole.Id == roleId.ToString()));
                        
                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }
        }

        public ResponseHelper InsertUpdate(PermissionRole model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var permisionRole = _permissionRoleRepo.Find(x => x.Id == model.Id).SingleOrDefault();

                    if (permisionRole == null)
                    {
                        model.ApplicationRole = _applicationRoleRepo.Find(y => y.Id == model.ApplicationRole.Id).SingleOrDefault();
                        model.Permission = _permissionRepo.Find(z => z.Id == model.Permission.Id).SingleOrDefault();
                        _permissionRoleRepo.Insert(model);
                    }
                    else
                    {
                        permisionRole.ApplicationRole = _applicationRoleRepo.Find(z => z.Id == model.ApplicationRole.Id).SingleOrDefault();
                        permisionRole.Permission = _permissionRepo.Find(y => y.Id == model.Permission.Id).SingleOrDefault();

                        _permissionRoleRepo.Update(permisionRole);
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
