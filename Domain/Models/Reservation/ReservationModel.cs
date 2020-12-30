using Domain.Models.ICustomerContracts;
using Domain.Models.IEventContracts;
using Domain.Models.IReservationContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Reservation
{
    public class ReservationModel : IReservation
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public int eventId { get; set; }

        public ICustomer reservationCustomer { get; set; }
        public IEvent reservationEvent { get; set; }

        public int quantity { get; set; }
        public DateTime boughtTime { get; set; }
    }
}
