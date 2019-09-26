using Model.Auth;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class PermissionRoleForGridView
    {
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }

        public Permission Permission { get; set; }
        public ApplicationRole Role { get; set; }

        public IEnumerable<Permission> lstPermissions { get; set; }
        public IEnumerable<ApplicationRole> lstRoles { get; set; }
    }

}
