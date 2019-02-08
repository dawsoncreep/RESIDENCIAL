using Common;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Model.Auth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Auth.Service
{
    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override async Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            string uri = Parameters.Iss; 
            string clientId = Parameters.audId; 
            var jwtProvider = Providers.JwtProvider.Create(uri);
            string token = await jwtProvider.GetTokenAsync(userName, password, clientId, Environment.MachineName);
            if (token == null)
            {
                return SignInStatus.Failure;
            }
            else
            {
                //decode payload
                dynamic payload = jwtProvider.DecodePayload(token);
                //create an Identity Claim
                ClaimsIdentity claims = jwtProvider.CreateIdentity(true, userName, payload);

                //sign in
                var context = HttpContext.Current.Request.GetOwinContext();
                var authenticationManager = context.Authentication;
                authenticationManager.SignIn(claims);

                return SignInStatus.Success;
            }
        }

    }
}
