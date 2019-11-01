using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ExternalBinnaclePhoto
    {
        [Key]
        public int Id { get; set; }

        //public ExternalBinnacle ExternalBinnacle { get; set; }

        public BinnaclePhotoType BinnaclePhotoType { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Resources.Resources))]
        [MaxLength(200)]
        public String Image { get; set; }
    }
}
