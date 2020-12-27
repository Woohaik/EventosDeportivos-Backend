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
        public async Task<HttpResponseMessage> CreateReservation()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> CancelReservation()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
