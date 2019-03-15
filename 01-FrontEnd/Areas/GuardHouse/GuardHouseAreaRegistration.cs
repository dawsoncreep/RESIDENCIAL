using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Areas.GuardHouse
{
    public class GuardHouseAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GuardHouse";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GuardHouse_default",
                "GuardHouse/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}