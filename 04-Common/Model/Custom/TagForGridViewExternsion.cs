using Model.Auth;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public static class TagForGridViewExternsion
    {
        public static Tag ToTag(this TagForGridView model)
        {
            return new Tag
            {
                ApplicationUser = new ApplicationUser() {Id = model.ApplicationUser_Id },
                Id =  model.Id,
                Observations = model.Observations,
                TagCode = model.TagCode,
                VehicleBrand = model.VehicleBrand,
                VehicleModel = model.VehicleModel,
                VehicleYear = model.VehicleYear
            };
        }

        public static TagForGridView ToTagForGridView(this Tag model)
        {
            return new TagForGridView
            {
                ApplicationUser = model.ApplicationUser,
                Id = model.Id,
                Observations = model.Observations,
                TagCode = model.TagCode,
                VehicleBrand = model.VehicleBrand,
                VehicleModel = model.VehicleModel,
                VehicleYear = model.VehicleYear,
                ApplicationUser_Id = model.ApplicationUser != null ? model.ApplicationUser.Id : String.Empty

            };
        }
    }
}
