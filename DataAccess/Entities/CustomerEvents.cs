using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CustomerEvents
    {
        public int EventID { get; set; }
        Event Event { get; set; }
        public int CustomerID { get; set; }
        Customer Customer { get; set; }
        public int quantity { get; set; }
    }
}
