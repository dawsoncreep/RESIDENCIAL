using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;

namespace Common
{
    public class CurrentUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string[] UserPermissions { get; set; }
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
                List<string> userPermission = new List<string>() ;

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

                if (((ClaimsIdentity)user.Identity).FindFirst("PermissionUser") != null)
                {
                    new List<Claim>(((ClaimsIdentity)user.Identity).FindAll("PermissionUser")).ForEach(s =>
                    {
                        userPermission.Add(s.Value);
                    });
                }

                //return JsonConvert.DeserializeObject<CurrentUser>(jUser);
                return new CurrentUser
                {
                    Name = name,
                    UserId = userId,
                    UserName = name,
                    UserPermissions = userPermission.ToArray()
                };
            }
        }
    }
}
