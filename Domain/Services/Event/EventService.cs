using Domain.Services.Event.crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Event
{
    public class EventService : EventCrud
    {
        private static EventService instance = null;
        private EventService() { }
        public static EventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }
        }
    }
}
