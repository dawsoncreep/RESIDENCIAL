using Common.CustomFilters;
using Model.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class External : AuditEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public String Name { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public String LastName { get; set; }

        [Display(Name = "LicensePlate", ResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public String LicensePlate { get; set; }


        [Display(Name = "Image", ResourceType = typeof(Resources.Resources))]
        [MaxLength(200)]
        public String UrlImage { get; set; }


        [Display(Name = "ExternalType", ResourceType = typeof(Resources.Resources))]
        public ExternalType ExternalType { get; set; }






    }
}
