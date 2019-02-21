using Common.CustomFilters;
using Model.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class LocationType:AuditEntity, ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
