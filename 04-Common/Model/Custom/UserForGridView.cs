using Model.Auth;
using System.Collections.Generic;

namespace Model.Custom
{
    public class UserForGridView
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string MotherSurname { get; set; }
        public string LastName { get; set; }
        public List<ApplicationRole> Roles { get; set; }
    }
}
