using Domain.Models.ICustomerContracts;
using Domain.Models.IEventContracts;
using Domain.Models.IReservationContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Cantidad a reservar debe ser mayor que 0")]
        public int quantity { get; set; }
        public DateTime boughtTime { get; set; }




    }
}
