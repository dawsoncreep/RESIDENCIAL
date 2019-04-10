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
    public interface IAPIRoleService
    {
        IEnumerable<ApplicationRole> GetAll();
        ApplicationRole Get(string roleName);
        ApplicationRole Get(Guid id);
    }

    public class APIRoleService : IAPIRoleService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationRole> _applicationRoleRepo;


        public APIRoleService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ApplicationRole> applicationRoleRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationRoleRepo = applicationRoleRepo;
        }

        public ApplicationRole Get(string roleName)
        {
            var result = new ApplicationRole();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _applicationRoleRepo.SingleOrDefault(s => s.Name == roleName,
                        s => s.Users);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ApplicationRole Get(Guid id)
        {
            var result = new ApplicationRole();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _applicationRoleRepo.SingleOrDefault(s => s.Id == id.ToString(),
                        s => s.Users);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    return new List<ApplicationRole>(_applicationRoleRepo.
                        GetAll(a => a.Users));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return null;
            }
        }
    }
}
