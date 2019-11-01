using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class PhotoType
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public string Description { get; set; }


    }
}
