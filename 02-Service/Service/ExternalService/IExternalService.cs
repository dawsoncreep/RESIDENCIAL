using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalService
{
    public interface IExternalService
    {
        ResponseHelper GetAll();
        ResponseHelper GetById(int id);
        ResponseHelper InsertUpdate(Object model);
        ResponseHelper Delete(int id);
    }
}
