using Domain.models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Event.crud
{
    public class EventCrud : IEventCrud
    {
        public bool AddEvent(EventModel eventModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public EventModel GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventModel> GetEvents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventModel> GetEventsByType(EventType type)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(int id, EventModel eventModel)
        {
            throw new NotImplementedException();
        }
    }
}
