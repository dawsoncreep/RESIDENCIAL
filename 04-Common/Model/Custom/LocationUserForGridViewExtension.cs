using Model.Domain;
using System;


namespace Model.Custom
{
    public static class LocationUserForGridViewExtension
    {
        public static LocationUser ToLocationUser(this LocationUserForGridView model)
        {
            return new LocationUser
            {
                ApplicationUser = model.ApplicationUser,
                Location = model.Location,
                Id = model.Id
            };
        }

        public static LocationUserForGridView ToLocationUserForGridView(this LocationUser model)
        {
            return new LocationUserForGridView
            {
                ApplicationUser = model.ApplicationUser,
                Location = model.Location
            };
        }
    }
}
