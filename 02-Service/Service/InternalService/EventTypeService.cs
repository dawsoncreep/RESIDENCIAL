using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InternalService
{
    public interface IEvenType
    {
        IEnumerable<EventType> GeteAll();
        EventType Get(int id);
    }

    public class EventTypeService : IEvenType
    {
        public EventType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventType> GeteAll()
        {
            throw new NotImplementedException();
        }
    }
}
