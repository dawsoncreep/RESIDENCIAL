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
    public interface IAPIPermissionUserService
    {
        IEnumerable<PermissionUser> GetByUserId(Guid userId);
    }

    class APIPermissionUserService : IAPIPermissionUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<PermissionUser> _permissionUserRepo;

        public APIPermissionUserService(
               IDbContextScopeFactory dbContextScopeFactory,
            IRepository<PermissionUser> permissionUserRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _permissionUserRepo = permissionUserRepo;
        }


        public IEnumerable<PermissionUser> GetByUserId(Guid userId)
        {
            var result = new List<PermissionUser>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<PermissionUser>(_permissionUserRepo.GetAll(
                        s => s.ApplicationUser.Claims,
                        s => s.ApplicationUser.Logins,
                        s => s.ApplicationUser.Roles,
                        s => s.Permission).
                        Where(w => w.ApplicationUser.Id == userId.ToString()));
                        
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
