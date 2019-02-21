﻿using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ApplicationParameters : AuditEntity, ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        public String Key { get; set; }
        public String Value { get; set; }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}