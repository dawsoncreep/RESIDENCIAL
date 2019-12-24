using Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Auth;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Service.ExternalService
{
    public interface IAPIUserService
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser Get(string userName);
        ApplicationUser Get(Guid id);
        ResponseHelper InsertUpdate(ApplicationUser model);
    }

    public class APIUserService : IAPIUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUser> _applicationUserRepo;
        private Persistence.DatabaseContext.ApplicationDbContext _context = new Persistence.DatabaseContext.ApplicationDbContext();

        public APIUserService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ApplicationUser> applicationUserRepo
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationUserRepo = applicationUserRepo;
        }

        public ApplicationUser Get(string userName)
        {
            var result = new ApplicationUser();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _applicationUserRepo.SingleOrDefault(s => s.UserName == userName,
                        s=>s.Claims,s=>s.Roles,s=>s.Logins);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ApplicationUser Get(Guid id)
        {
            var result = new ApplicationUser();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _applicationUserRepo.SingleOrDefault(s => s.Id == id.ToString(),
                        s => s.Claims, s => s.Roles, s => s.Logins);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }


        public IEnumerable<ApplicationUser> GetAll()
        {
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    return new List<ApplicationUser> (_applicationUserRepo.
                        GetAll(a => a.Roles, a => a.Logins, a=> a.Claims));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return null;
            }

        }

        public ResponseHelper InsertUpdate(ApplicationUser model)
        {
            var rh = new ResponseHelper();
            var store = new UserStore<ApplicationUser>(_context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            try
            {
                manager.Create(user, model.PasswordHash);
                rh.SetResponse(true);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }
    }
}
