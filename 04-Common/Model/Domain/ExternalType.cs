using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ExternalType
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public String Description { get; set; }

    }
}
