using Model.Auth;
using System.Collections.Generic;

namespace Model.Custom
{
    public class UserForGridView
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<ApplicationRole> Roles { get; set; }
    }
}
