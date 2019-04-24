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
        private static readonly IPermissionUserService _permissionUserService = DependecyFactory.GetInstance<IPermissionUserService>();

        public static MvcHtmlString getMenu(this HtmlHelper html, PermissionMenuId permissionId, object htmlvalues)
        {
            var permissionUser = _permissionUserService.GetByUserId(new Guid(CurrentUserHelper.Get.UserId));
            var permission = permissionUser.Where(w => w.Permission.Id == (int)permissionId).FirstOrDefault();
            if (permission == null)
            {
                return new MvcHtmlString("");
            }
            else
            {
                return html.ActionLink(
                    Resources.Resources.ResourceManager.GetString(permission.Permission.ResourceCode),
                    permission.Permission.Action,
                    permission.Permission.Controller,
                    new { Area = permission.Permission.Area },
                    htmlvalues
                    );
            }

        }
    }
}