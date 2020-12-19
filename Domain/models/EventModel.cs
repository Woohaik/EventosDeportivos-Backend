using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.models
{
    public class EventModel
    {
        int id { get; set; }
        string name { get; set; }
        int limit { get; set; }
        DateTime start { get; set; }
        DateTime finish { get; set; }

    }
}
