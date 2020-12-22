using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CustomerEvent
    {
        [Key]
        public int PurchaseId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }


        public Customer Customer { get; set; }
        public Event Event { get; set; }


        public int quantity { get; set; }
    }
}
