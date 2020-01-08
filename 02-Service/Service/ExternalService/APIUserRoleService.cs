using Common;
using Model.Auth;
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
    public interface IAPIUserRoleService
    {
        ResponseHelper DeleteUserRole(ApplicationUserRole model);
    }

    public class APIUserRoleService : IAPIUserRoleService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUserRole> _applicationUserRoleRepo;
        

        public APIUserRoleService(IDbContextScopeFactory dbContextScopeFactory, IRepository<ApplicationUserRole> applicationUserRoleRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationUserRoleRepo = applicationUserRoleRepo;
        }

        public ResponseHelper DeleteUserRole(ApplicationUserRole model)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var userRole = _applicationUserRoleRepo.SingleOrDefault(x => x.RoleId == model.RoleId && x.UserId == model.UserId);
                    _applicationUserRoleRepo.Delete(userRole);

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Delete_OkMessage,
                        Resources.Resources.Permission));
                }
                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                        Resources.Resources.Permission));
                return rh;
            }
        }
    }
}
