using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Tag : AuditEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public String TagCode { get; set; }

        [Required]
        [MaxLength(50)]
        public String VehicleBrand { get; set; }

        [Required]
        [MaxLength(50)]
        public String VehicleModel { get; set; }

        [MaxLength(50)]
        public String VehicleYear { get; set; }

        [MaxLength(255)]
        public String Observations { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
