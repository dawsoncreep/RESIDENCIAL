﻿using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class BinnaclePhoto : AuditEntity, ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Binnacle> BinnacleId { get; set; }
        public ICollection<BinnacleType> BinnacleTypeId { get; set; }

        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}