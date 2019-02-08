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
    public class Audience : AuditEntity, ISoftDeleted
    {
        [Key]
        public string ClientId { get; set; }

        public string Base64Secret { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }
    }
}
