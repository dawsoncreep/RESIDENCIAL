using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Web;

namespace Common
{
    public class CurrentUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }

    public class CurrentUserHelper
    {
        public static CurrentUser Get
        {
            get
            {
                var user = HttpContext.Current.User;

                if (user == null)
                {
                    return null;
                }
                else if (string.IsNullOrEmpty(user.Identity.GetUserId()))
                {
                    return null;
                }

                string username = string.Empty;
                string userId = string.Empty;
                string name = string.Empty;

                if (((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Name) != null)
                {
                    name = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Name).Value;
                }
                if (((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.NameIdentifier) != null)
                {
                    username = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                if (((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.SerialNumber) != null)
                {
                    userId = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.SerialNumber).Value;
                }

                //return JsonConvert.DeserializeObject<CurrentUser>(jUser);
                return new CurrentUser
                {
                    Name = name,
                    UserId = userId,
                    UserName = name
                };
            }
        }
    }
}
