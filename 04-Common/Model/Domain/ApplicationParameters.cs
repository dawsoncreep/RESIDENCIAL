using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ApplicationParameters
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Key { get; set; }


        [Required]
        [MaxLength(255)]
        public String Value { get; set; }

        [MaxLength(100)]
        public String Description { get; set; }

    }
}
