using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InternalService
{
    public interface IBinnacleType
    {
        IEnumerable<BinnacleType> GeteAll();
        BinnacleType Get(int id);
    }

    public class BinnacleTypeService : IBinnacleType
    {
        public BinnacleType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BinnacleType> GeteAll()
        {
            throw new NotImplementedException();
        }
    }
}
