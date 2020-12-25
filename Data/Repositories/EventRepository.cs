using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EventRepository : IEventRepository
    {

        private static EventRepository instance = null;
        private EventRepository() { }
        public static EventRepository Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new EventRepository();
                }
                return instance;
            }
        }




        public async Task Add(events entity)
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                ctx.events.Add(entity);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                events theEvent = await ctx.events.FindAsync(id);
                ctx.events.Remove(theEvent);
                await ctx.SaveChangesAsync();
            }
        }

        public IEnumerable<events> GetAll()
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                IEnumerable<events> events = ctx.events.ToList();

                return events;
            }
        }

        public async Task<events> GetById(int id)
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                events theEvent = await ctx.events.FindAsync(id);
                return theEvent;
            }
        }

        public async Task UpdateById(int id, events entity)
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                events events = await ctx.events.FindAsync(id);
                events.eventname = entity.eventname;
                events.eventstart = entity.eventstart;
                events.eventfinish = entity.eventfinish;
                events.eventlimit = entity.eventlimit;
                events.eventtypecode = entity.eventtypecode;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
