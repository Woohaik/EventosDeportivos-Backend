using Domain.models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Event.crud
{
    public interface IEventCrud
    {
        bool AddEvent(EventModel eventModel);
        bool UpdateEvent(int id, EventModel eventModel);
        bool DeleteEvent(int id);
        IEnumerable<EventModel> GetEvents();
        EventModel GetEventById(int id);
        IEnumerable<EventModel> GetEventsByType(EventType type);
    }
}
