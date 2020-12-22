using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{

    public class Event
    {

        public int EventId { get; set; }
        public string name { get; set; }
        public int limit { get; set; }
        public DateTime start { get; set; }
        public DateTime finish { get; set; }
        public int type { get; set; }
      //  public ICollection<CustomerEvent> CustomerEvents { get; set; }
    }
}
