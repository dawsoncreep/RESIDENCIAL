using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public static class ExternalUserForGridViewExtension
    {
        public static External ToExternal(this ExternalUserForGridView model,
            ExternalType ExternalType,
            Location Location)
        {
            return new External
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                CreatedUser = model.CreatedUser,
                ExternalType = ExternalType,
                Location = Location,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Name = model.Name,
                LicensePlate = model.LicensePlate,
                UpdatedAt = model.UpdatedAt,
                UpdatedBy = model.UpdatedBy,
                UpdatedUser = model.UpdatedUser,
                Image = model.Image
            };
        }

        public static ExternalUserForGridView ToExternalForGridView(this External model)
        {
            return new ExternalUserForGridView
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                CreatedUser = model.CreatedUser,
                ExternalType = model.ExternalType,
                ExternalTypeId = model.ExternalType.Id.ToString(),
                Location = model.Location,
                LocationId = model.Location.Id.ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Name = model.Name,
                LicensePlate = model.LicensePlate,
                UpdatedAt = model.UpdatedAt,
                UpdatedBy = model.UpdatedBy,
                UpdatedUser = model.UpdatedUser,
                Image = model.Image
            };
        }
    }
}
