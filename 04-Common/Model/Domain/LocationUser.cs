using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.Auth;
namespace Model.Domain
{
    public class LocationUser: AuditEntity ,ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        public ICollection<ApplicationUser> UserId { get; set; }
        public ICollection<Location> LocationId { get; set; }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
