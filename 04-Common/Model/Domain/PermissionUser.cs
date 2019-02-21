using Common.CustomFilters;
using Model.Helper;
using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Model.Domain
{
    public class PermissionUser : AuditEntity, ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        public ICollection<ApplicationUser> UserId { get; set; }
        public ICollection<Permission> PermissionId { get; set; }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
