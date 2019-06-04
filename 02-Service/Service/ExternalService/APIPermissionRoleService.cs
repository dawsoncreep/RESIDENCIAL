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
    }

    class APIPermissionRoleService : IAPIPermissionRoleService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<PermissionRole> _permissionRoleRepo;

        public APIPermissionRoleService(
               IDbContextScopeFactory dbContextScopeFactory,
            IRepository<PermissionRole> permissionRoleRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _permissionRoleRepo = permissionRoleRepo;
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
    }
}
