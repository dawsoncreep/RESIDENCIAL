using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class BinnaclePhoto : AuditEntity
    {
        [Key]
        public int Id { get; set; }
        public Binnacle Binnacle { get; set; }
        public ExternalBinnacle ExternalBinnacle { get; set; }
        public BinnaclePhotoType BinnaclePhotoType { get; set; }
        public String Image { get; set; }
    }
}
