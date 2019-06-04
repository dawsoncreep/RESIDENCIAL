using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Model.Domain
{
    public class Event: AuditEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public string Description { get; set; }

        [Display(Name = "DateStart", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }


        [Display(Name = "DateEnd", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; }

        [Display(Name = "EventType", ResourceType = typeof(Resources.Resources))]
        public EventType EventType { get; set; }

        [Display(Name = "Location", ResourceType = typeof(Resources.Resources))]
        public Location Location { get; set; }

        [Display(Name = "External", ResourceType = typeof(Resources.Resources))]
        public External External { get; set; }


    }
}
