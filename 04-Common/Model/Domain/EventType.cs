﻿using Common.CustomFilters;
using Model.Helper;
using System;
using System.ComponentModel.DataAnnotations;
namespace Model.Domain
{
    public class EventType
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public string Description { get; set; }

        [Display(Name = "TiedToExternalUser", ResourceType = typeof(Resources.Resources))]
        public bool IsTiedToExternalUser { get; set; }


    }
}