using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class LocationProcessor
    {
        public LocationProcessor()
        {
        }

        public IEnumerable<Locations> GetLocations()
        {
            IEnumerable<DataLayer.Locations> locations;
            using (var context = new SecureGateEntities())
            {
                locations = context.Locations;
            }
            return locations;
        }

        public string[] GetLocationsString()
        {
            string[] locations;
            using (var context = new SecureGateEntities())
            {
                locations = context.Locations.Select(s => s.Street + " #" + s.OutNumber + (s.InNumber != null ? s.InNumber:"") ).ToArray();
            }
            return locations;
        }
    }
}
