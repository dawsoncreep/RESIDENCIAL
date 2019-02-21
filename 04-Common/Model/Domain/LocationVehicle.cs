﻿using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class LocationVehicle :AuditEntity ,ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Location> LocationId { get; set; }
        public string Tag { get; set; }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
