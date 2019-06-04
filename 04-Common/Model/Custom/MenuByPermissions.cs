using Common;
using System;
using System.Linq;
using static Common.Enums;

namespace Model.Custom
{
    public class MenuByPermissions
    {
        public static bool isUserAuthorized(PermissionMenuId permissionId)
        {
            return CurrentUserHelper.Get.UserPermissions.Where(w => w == permissionId.ToString()).Any();
        }
    }

    

}
