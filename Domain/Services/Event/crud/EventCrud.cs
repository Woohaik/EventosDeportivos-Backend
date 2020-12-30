using Domain.Models.IEventContracts;
using System;

using Data.DB;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Domain.Models.Event;

namespace Domain.Services.Event.crud
{
    public class EventCrud : ICrud<IEvent>
    {
        protected IEventRepository eventRepository = EventRepository.Instance;

        public async Task Add(IEvent model)
        {
            int theEventCode = (int)model.eventType;
            events events = new events()
            {
                eventname = model.name,
                eventstart = model.start,
                eventfinish = model.finish,
                eventlimit = model.limit,
                eventtypecode = (int)model.eventType
            };
            await this.eventRepository.Add(events);
        }

        public async Task DeleteById(int id)
        {
            await this.eventRepository.DeleteById(id);
        }

        public async Task<IEnumerable<IEvent>> GetAll()
        {
            IEnumerable<events> dbEvents = await this.eventRepository.GetAll();
            List<IEvent> domainEvents = new List<IEvent>();


            foreach (events dbEvent in dbEvents)
            {
                domainEvents.Add(new EventModel()
                {
                    id = dbEvent.eventid,
                    name = dbEvent.eventname,
                    start = dbEvent.eventstart,
                    finish = dbEvent.eventfinish,
                    limit = dbEvent.eventlimit,
                    eventType = (EventTypes)dbEvent.eventtypecode,
                    

                });

            }
            return domainEvents;

        }

        public async Task<IEvent> GetById(int id)
        {
            events dbEvent = await this.eventRepository.GetById(id);
            IEvent domainEvent = new EventModel()
            {
                id = dbEvent.eventid,
                name = dbEvent.eventname,
                start = dbEvent.eventstart,
                finish = dbEvent.eventfinish,
                limit = dbEvent.eventlimit,
                eventType = (EventTypes)dbEvent.eventtypecode
            };



            return domainEvent;
        }

        public async Task UpdateById(int id, IEvent model)
        {
            events dbEvent = new events()
            {
                eventname = model.name,
                eventstart = model.start,
                eventfinish = model.finish,
                eventlimit = model.limit,
                eventtypecode = (int)model.eventType
            };

            await this.eventRepository.UpdateById(id, dbEvent);
        }
    }
}
