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
    public class Bulletin : AuditEntity, ISoftDeleted
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

        [Required]
        [Display(Name = "Date", ResourceType = typeof(Resources.Resources))]
        public DateTime DateCreated { get; set; }

        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
