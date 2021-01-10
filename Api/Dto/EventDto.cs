using Domain.Models.IEventContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{
    public class EventDto
    {
        public int id { get; set; }
        public int freeSpaces { get; set; }
        public string name { get; set; }
        public int limit { get; set; }
        public DateTime start { get; set; }
        public DateTime finish { get; set; }
        public int eventType { get; set; }

        public EventDto(IEvent theEvent)
        {
            this.id = theEvent.id;
            this.name = theEvent.name;
            this.limit = theEvent.limit;
            this.start = theEvent.start;
            this.finish = theEvent.finish;
            this.eventType = (int)theEvent.eventType;
            this.freeSpaces = theEvent.freeSpaces;
        }
    }
}