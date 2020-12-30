using Domain.Models.ICustomerContracts;
using Domain.Models.IEventContracts;
using Domain.Models.IReservationContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{
    public class ReservationDto
    {
        public int id { get; set; }

        public CustomerDto reservationCustomer { get; set; }
        public EventDto reservationEvent { get; set; }

        public int quantity { get; set; }
        public DateTime boughtTime { get; set; }

        public ReservationDto(IReservation reservation)
        {
            this.reservationCustomer = new CustomerDto(reservation.reservationCustomer);
            this.reservationEvent = new EventDto(reservation.reservationEvent);
            this.quantity = reservation.quantity;
            this.boughtTime = reservation.boughtTime;
            this.id = reservation.id;
        }
    }
}