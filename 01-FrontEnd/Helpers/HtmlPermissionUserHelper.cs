using Common;
using Service.InternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using static Common.Enums;

namespace FrontEnd.Helpers
{
    public static class HtmlPermissionUserHelper
    {
        private static readonly IPermissionService _permissionService = DependecyFactory.GetInstance<IPermissionService>();
        private static readonly IPermissionRoleService _permissionRoleService = DependecyFactory.GetInstance<IPermissionRoleService>();

        public static MvcHtmlString getMenu(this HtmlHelper html, PermissionMenuId permissionId, object htmlvalues)
        {
            //var permissionUser = _permissionUserService.GetByUserId(new Guid(CurrentUserHelper.Get.UserId));
            //var permission = permissionUser.Where(w => w.Permission.Id == (int)permissionId).FirstOrDefault();



            if (CurrentUserHelper.Get.UserPermissions.Where(w => w == permissionId.ToString()).Any())
            {
                var permission = (from pr in CurrentUserHelper.Get.UserPermissions
                                 join p in _permissionService.GetAll()
                                 on pr equals p.ResourceCode
                                 where p.ResourceCode == permissionId.ToString()
                                 select p).FirstOrDefault();

                if(permission == null)
                    return new MvcHtmlString("");

                return html.ActionLink(
                    Resources.Resources.ResourceManager.GetString(permission.ResourceCode),
                    permission.Action,
                    permission.Controller,
                    new { Area = permission.Area },
                    htmlvalues
                    );
            }
            else
            {
                return new MvcHtmlString("");
            }

        }
    }
}