using Domain.Models.ICustomerContracts;
using Domain.Models.IEventContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.IReservationContracts
{
    public interface IReservation
    {
        int id { get; set; }
        int quantity { get; set; }
        ICustomer reservationCustomer { get; set; }
        IEvent reservationEvent { get; set; }
        DateTime boughtTime { get; set; }
    }
}
