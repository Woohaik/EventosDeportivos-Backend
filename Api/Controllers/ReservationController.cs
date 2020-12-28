using Domain.Models.Customer;
using Domain.Models.Event;
using Domain.Models.Reservation;
using Domain.Services.IServicesContracts;
using Domain.Services.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class ReservationController : ApiController
    {
        private IReservationService reservationCrudServices = ReservationService.Instance;

        public async Task<HttpResponseMessage> GetReservations()
        {

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> GetReservation(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> GetCustomerReservations(int Customerid)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> CreateReservation([FromBody] ReservationModel reservation)
        {
            try
            {


                reservation.reservationCustomer = new CustomerModel() { id = reservation.customerId };
                reservation.reservationEvent = new EventModel() { id = reservation.eventId };
                await this.reservationCrudServices.Add(reservation);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpDelete]
        public async Task<HttpResponseMessage> CancelReservation()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
