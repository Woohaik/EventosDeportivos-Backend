using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{

    public class Customer
    {

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerLastname { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerDni { get; set; }

        public string Customerpassword { get; set; }
        // public ICollection<CustomerEvent> CustomerEvents { get; set; }
    }
}
