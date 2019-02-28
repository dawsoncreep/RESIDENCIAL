using Common.CustomFilters;
using Model.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Model.Domain
{
    public class Binnacle : AuditEntity, ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public ICollection <Event> EventId { get; set; }
        public ICollection<BinnacleType> BinnacleTypeId { get; set; }

        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
