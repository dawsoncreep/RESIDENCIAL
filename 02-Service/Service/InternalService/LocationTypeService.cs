using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InternalService
{
    public interface ILocationType
    {
        IEnumerable<LocationType> GeteAll();
        ILocationType Get(int id);
    }

    public class LocationTypeService : ILocationType
    {
        public ILocationType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationType> GeteAll()
        {
            throw new NotImplementedException();
        }
    }
}
