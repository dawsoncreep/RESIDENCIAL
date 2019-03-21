using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBinnaclePhotoType
    {
        IEnumerable<BinnaclePhotoType> GeteAll();
        BinnaclePhotoType Get(int id);
    }

    public class BinnaclePhotoTypeService : IBinnaclePhotoType
    {
        public BinnaclePhotoType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BinnaclePhotoType> GeteAll()
        {
            throw new NotImplementedException();
        }
    }
}
