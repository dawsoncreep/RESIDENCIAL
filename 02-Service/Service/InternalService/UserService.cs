using Common;
using Model.Auth;
using Model.Custom;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Service.InternalService
{
    public interface IUserService
    {
        IEnumerable<UserForGridView> GetAll();
        UserForGridView Get(string userName);
    }

    public class UserService : IUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IRoleService _roleService = DependecyFactory.GetInstance<IRoleService>();

        public UserForGridView Get(string userName)
        {
            var result = new UserForGridView();
            List<string> _roles = new List<string>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);
                
                var request = new RestRequest(String.Format("/user/Get/{0}", userName), Method.GET);

                // easily add HTTP Headers
                //En caso de requerir autenticación hay que extraer el token de la cookie.
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = client.Execute(request);
                var responseDes = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationUser>(response.Content);

                foreach (var item in responseDes.Roles)
                {
                    _roles.Add(_roleService.Get(new Guid(item.RoleId)).Name);
                }

                result = new UserForGridView
                {
                    Email = responseDes.Email,
                    Id = responseDes.Id,
                    Roles = _roles,
                    UserName = responseDes.UserName
                };

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<UserForGridView> GetAll()
        {
            var result = new List<UserForGridView>();

            try
            {
                //using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                //{
                //    var abc = _applicationUserRepo.GetAll().ToList();

                //    var users = ctx.GetEntity<ApplicationUser>();
                //    var roles = ctx.GetEntity<ApplicationRole>();
                //    var usersPerRoles = ctx.GetEntity<ApplicationUserRole>();

                //    var queryUsersPerRoles = (
                //        from upr in usersPerRoles
                //        from r in roles.Where(x => x.Id == upr.RoleId)
                //        select new
                //        {
                //            upr.UserId,
                //            r.Name
                //        }
                //    ).AsQueryable();

                //    result = (
                //        from u in users
                //        select new UserForGridView {
                //            Id = u.Id,
                //            Email = u.Email,
                //            Roles = queryUsersPerRoles.Where(x =>
                //                x.UserId == u.Id
                //            ).Select(x => x.Name).ToList()
                //        }
                //    ).ToList();
                //}
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }
    }
}
