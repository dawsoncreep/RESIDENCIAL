using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public static class EventForGridViewExternsion
    {
        public static Event ToEvent(this EventForGridView model)
        {
            return new Event
            {
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Description = model.Description,
                EventType = model.EventType,
                External = model.External,
                Id = model.Id,
                Location = model.Location,
                Name = model.Name
            };
        }

        public static EventForGridView ToEventForGridView(this Event model)
        {
            return new EventForGridView
            {
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Description = model.Description,
                EventType = model.EventType,
                External = model.External,
                ExternalId = model.External.Id.ToString(),
                EventTypeId = model.EventType.Id.ToString(),
                LocationId = model.Location.Id.ToString(),
                Id = model.Id,
                Location = model.Location,
                Name = model.Name
            };
        }
    }
}
