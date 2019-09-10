using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class TagForGridView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "TagCode", ResourceType = typeof(Resources.Resources))]
        public String TagCode { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "VehicleBrand", ResourceType = typeof(Resources.Resources))]
        public String VehicleBrand { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "VehicleModel", ResourceType = typeof(Resources.Resources))]
        public String VehicleModel { get; set; }

        [MaxLength(50)]
        [Display(Name = "VehicleYear", ResourceType = typeof(Resources.Resources))]
        public String VehicleYear { get; set; }

        [MaxLength(255)]
        [Display(Name = "Observations", ResourceType = typeof(Resources.Resources))]
        public String Observations { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public String ApplicationUser_Id { get; set; }

        public IEnumerable<UserForGridView> lstUsers { get; set; }


    }
}
