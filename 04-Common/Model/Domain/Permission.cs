using Common.CustomFilters;
using Model.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class Permission 
    {
        [Key]
        [Display(Name = "Permission_Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "Permission_Code", ResourceType = typeof(Resources.Resources))]
        public String ResourceCode { get; set; }
        [MaxLength(30)]

        [Required]
        [Display(Name = "Permission_Name", ResourceType = typeof(Resources.Resources))]
        public String Name { get; set; }
        [MaxLength(200)]
        [Required]
        [Display(Name = "Permission_Desc", ResourceType = typeof(Resources.Resources))]
        public String Description { get; set; }
        [MaxLength(100)]

        [Display(Name = "Permission_Action", ResourceType = typeof(Resources.Resources))]
        public String Action { get; set; } = String.Empty;
        [MaxLength(100)]
        
        [Display(Name = "Permission_Controller", ResourceType = typeof(Resources.Resources))]
        public String Controller { get; set; } = String.Empty;
        [MaxLength(100)]
        
        [Display(Name = "Permission_Area", ResourceType = typeof(Resources.Resources))]
        public String Area { get; set; } = String.Empty;
    }
}
