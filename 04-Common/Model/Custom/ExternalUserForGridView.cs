using Model.Domain;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.Custom
{
    public class ExternalUserForGridView : AuditEntity
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
        public String Image { get; set; }


        [Display(Name = "ExternalType", ResourceType = typeof(Resources.Resources))]
        public ExternalType ExternalType { get; set; }

        [Display(Name = "Location", ResourceType = typeof(Resources.Resources))]
        public Location Location { get; set; }

        public HttpPostedFileBase file { get; set; }

        [Required]
        public String ExternalTypeId { get; set; }

        public IEnumerable<ExternalType> lstExternalType { get; set; }

        [Required]
        public String LocationId { get; set; }

        public IEnumerable<Location> lstLocations { get; set; }

    }
}
