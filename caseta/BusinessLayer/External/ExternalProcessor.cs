using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class ExternalProcessor
    {
        public ExternalProcessor()
        {
        }

        public IEnumerable<ExternalTypes> GetExternalTypes()
        {
            var externalTypes = new List<ExternalTypes>();
            using (var context = new SecureGateEntities())
            {
                externalTypes = context.ExternalTypes.ToList();
            }
            return externalTypes;
        }

        public ExternalTypes GetExternalTypeByID(int id)
        {
            ExternalTypes type;
            using (var context = new SecureGateEntities())
            {
                type = context.ExternalTypes.Single(x => x.Id == id);
            }
            return type;
        }
    }
}
