using Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Domain;
using Newtonsoft.Json;
using Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Model.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string MotherSurname { get; set; }
        public string LastName { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            userIdentity = await CreateUserClaims(userIdentity, manager, userIdentity.GetUserId());

            // Add custom user claims here
            return userIdentity;
        }




        // Create additional parameters to persist on the cookie
        public async static Task<ClaimsIdentity> CreateUserClaims(
            ClaimsIdentity identity,
            UserManager<ApplicationUser> manager,
            string userId
        )
        { 
            // Current User
            var currentUser = await manager.FindByIdAsync(userId);

            // Your User Data
            var jUser = JsonConvert.SerializeObject(new CurrentUser
            {
                UserId = currentUser.Id,
                Name = currentUser.Email,
                UserName = currentUser.Email,
            });

            identity.AddClaim(new Claim(ClaimTypes.UserData, jUser));

            return await Task.FromResult(identity);
        }

        public async Task<ApplicationUser> FindUser(string userName, string password, UserManager<ApplicationUser> manager)
        {
            ApplicationUser user = await manager.FindAsync(userName, password);

            return user;
        }




    }
}
