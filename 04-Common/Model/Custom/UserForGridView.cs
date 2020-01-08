using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string PassWord { get; set; }
        public ApplicationRole role { get; set; }

        [Required]
        public String LocationTypeId { get; set; }

        public IEnumerable<ApplicationRole> lstRoles { set; get; }
    }
}
