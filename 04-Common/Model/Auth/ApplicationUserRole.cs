using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Model.Auth
{
    public class ApplicationUserRole : IdentityUserRole
    {
        public void AddToRole(string userId, string role, UserManager<ApplicationUser> manager)
        {
             manager.AddToRole(userId, role);

        }
    }
}
