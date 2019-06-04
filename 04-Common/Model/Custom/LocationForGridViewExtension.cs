using Model.Domain;
using System;

namespace Model.Custom
{
    public static class LocationForGridViewExtension
    {
        public static Location ToLocation(this LocationForGridView model, LocationType locationType)
        {
            return new Location
            {
                InNumber = model.InNumber,
                Description = model.Description,
                LocationType = locationType,
                Name = model.Name,
                OutNumber = model.OutNumber,
                Id = model.Id,
                Street = model.Street,
                
            };
        }



        public static LocationForGridView ToLocationForGridView(this Location model)
        {
            return new LocationForGridView
            {
                Description = model.Description,
                Id = model.Id,
                InNumber = model.InNumber,
                Name = model.Name,
                OutNumber = model.OutNumber,
                Street = model.Street,
                LocationTypeId = model.LocationType.Id.ToString(),
                LocationType = model.LocationType
            };
        }
    }
}
