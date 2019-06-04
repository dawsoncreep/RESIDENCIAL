using Auth.Service;
using Common;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using Persistence.DatabaseContext;
using Persistence.Repository;
using Service;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace AuthorizationServer.Api.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthorizationServerService _authorizationServerRepository =
            DependecyFactory.GetInstance<IAuthorizationServerService>();

        private readonly IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private static readonly IPermissionRoleService _permissionRoleService = 
            DependecyFactory.GetInstance<IPermissionRoleService>();


        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return Task.FromResult<object>(null);
            }

            var audience = _authorizationServerRepository.Get(context.ClientId);

            if (audience == null)
            {
                context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                using (AuthRepository _repo = new AuthRepository())
                {
                    IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                context.SetError("invalid_grant", "Internal Server Error.");
                return;
            }

            UserForGridView userFromRepo = _userService.Get(context.UserName);

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.SerialNumber , userFromRepo.Id));

            List<Permission> permission = new List<Permission>();
            userFromRepo.Roles.ForEach(s =>
            {
                identity.AddClaim(new Claim(ClaimTypes.Role,s.Name));
            });

            permission = (from r in userFromRepo.Roles
                          join pr in new List<PermissionRole>(_permissionRoleService.GetAll())
                          on r.Id equals pr.ApplicationRole.Id
                          select pr.Permission
                         ).ToList();

            permission.ForEach(s =>
            {
               identity.AddClaim(new Claim("Permissions", s.ResourceCode));
            });


            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", (context.ClientId == null) ? string.Empty : context.ClientId
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }
    }
}