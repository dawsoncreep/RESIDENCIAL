using Common.CustomFilters;
using Model.Helper;
using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class PermissionUser 
    {
        [Key]
        public int Id { get; set; }
        public int Permission_Id { get; set; }
        public Permission Permission { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
