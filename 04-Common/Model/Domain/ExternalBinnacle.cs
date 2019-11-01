using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class ExternalBinnacle : AuditEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "EntryDate", ResourceType = typeof(Resources.Resources))]
        public DateTime EntryDate { get; set; }


        [Display(Name = "ExitDate", ResourceType = typeof(Resources.Resources))]
        public DateTime? ExitDate { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        public String ExternalName { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Colonial", ResourceType = typeof(Resources.Resources))]
        public String ColonialName { get; set; }

        [Display(Name = "LicensePlate", ResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public String LicensePlateText { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Location", ResourceType = typeof(Resources.Resources))]
        public String LocationText { get; set; }


        [Required]
        [MaxLength(150)]
        [Display(Name = "ExternalType", ResourceType = typeof(Resources.Resources))]
        public String ExternalTypeText { get; set; }

        public Guid? SessionId { get; set; }

        public External External { get; set; }
        
        public BinnacleType BinnacleType { get; set; }
        
        public List<ExternalBinnaclePhoto> ExternalBinnaclePhoto { get; set; }





    }
}
