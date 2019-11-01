using Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class ExternalBinnacleForGridView
    {
        
        public List<ExternalType> ExternalTypes { get; set; }

        public String ExternalId { get; set; }

        public List<ExternalType> lstExternalType { get; set; }

    }
}
