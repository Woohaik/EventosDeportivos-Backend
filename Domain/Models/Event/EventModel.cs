using Domain.Models.IEventContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Event
{
    public class EventModel : IEvent
    {
        public int id { get; set; }
        public string name { get; set; }
        public int limit { get; set; }
        public DateTime start { get; set; }
        public DateTime finish { get; set; }
        public EventTypes eventType { get; set; }
    }
}
