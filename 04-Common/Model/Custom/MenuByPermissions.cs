using Common;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using static Common.Enums;

namespace Model.Custom
{
    public class MenuByPermissions
    {
        public static bool isUserAuthorized(PermissionMenuId permissionId)
        {
            int permisoInt = (int)permissionId;
            return CurrentUserHelper.Get.UserPermissions.Where(w => w == permisoInt.ToString()).Any();
        }
    }

    

}
