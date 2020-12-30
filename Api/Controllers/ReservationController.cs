using Api.Dto;
using Api.Validators;
using Domain.Models.Customer;
using Domain.Models.Event;
using Domain.Models.IReservationContracts;
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
        private AnotationValidator<ReservationModel> validator = AnotationValidator<ReservationModel>.Instance;
        public async Task<HttpResponseMessage> GetReservations()
        {
            try
            {
                IEnumerable<IReservation> allReservations = null;
                allReservations = await this.reservationCrudServices.GetAll();
                List<ReservationDto> allReservationsDto = new List<ReservationDto>();
                foreach (IReservation reservation in allReservations)
                {
                    allReservationsDto.Add(new ReservationDto(reservation));
                }
                return Request.CreateResponse(HttpStatusCode.OK, allReservationsDto);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<HttpResponseMessage> GetReservation(int id)
        {
            try
            {
                IReservation reservation = await this.reservationCrudServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, new ReservationDto(reservation));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //[Route("/api/reservation/customer")]
        //public async Task<HttpResponseMessage> GetCustomerReservations(int Customerid)
        //{

        //    return Request.CreateResponse(HttpStatusCode.OK, "wario " + Customerid);
        //}

        [HttpPost]
        public async Task<HttpResponseMessage> CreateReservation([FromBody] ReservationModel reservation)
        {
            try
            {
                validator.validate(reservation);
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
        public async Task<HttpResponseMessage> CancelReservation(int id)
        {
            try
            {
                await this.reservationCrudServices.DeleteById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
