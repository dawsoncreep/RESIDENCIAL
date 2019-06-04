using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class Location : AuditEntity 
    {

        [Key]
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Street", ResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public String Street { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "OutNumber", ResourceType = typeof(Resources.Resources))]
        public String OutNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "InNumber", ResourceType = typeof(Resources.Resources))]
        public String InNumber { get; set; }

        public LocationType LocationType { get; set; }


    }
}
