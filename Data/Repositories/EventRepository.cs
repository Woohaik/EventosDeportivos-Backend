using Data.DB;
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
            using (dbEntities ctx = new dbEntities())
            {
                ctx.events.Add(entity);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            using (dbEntities ctx = new dbEntities())
            {
                events theEvent = await ctx.events.FindAsync(id);
                if (theEvent == null) throw new Exception("Evento No Encontrado");
                ctx.events.Remove(theEvent);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<events>> GetAll()
        {
            return await Task.Run(() =>
            {
                using (dbEntities ctx = new dbEntities())
                {
                    IEnumerable<events> events = ctx.events.ToList();

                    return events;
                }
            });

        }

        public async Task<events> GetById(int id)
        {
            using (dbEntities ctx = new dbEntities())
            {
                events theEvent = await ctx.events.FindAsync(id);
                if (theEvent == null) throw new Exception("Evento No Encontrado");
                return theEvent;
            }
        }

        public async Task UpdateById(int id, events entity)
        {
            using (dbEntities ctx = new dbEntities())
            {
                events theEvent = await ctx.events.FindAsync(id);
                if (theEvent == null) throw new Exception("Evento No Encontrado");
                theEvent.eventname = entity.eventname;
                theEvent.eventstart = entity.eventstart;
                theEvent.eventfinish = entity.eventfinish;
                theEvent.eventlimit = entity.eventlimit;
                theEvent.eventtypecode = entity.eventtypecode;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
