using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public static class PermissionRoleForGridViewExtension
    {
        public static PermissionRole ToPermissionRole(this PermissionRoleForGridView model)
        {
            return new PermissionRole
            {
                Id = model.Id,
                ApplicationRole = model.Role,
                Permission = model.Permission
            };
        }

        public static PermissionRoleForGridView ToPermissionRoleForGridView (this PermissionRole model)
        {
            return new PermissionRoleForGridView
            {
                Id = model.Id,
                Role = model.ApplicationRole,
                Permission = model.Permission
            };
        }
    }
}
