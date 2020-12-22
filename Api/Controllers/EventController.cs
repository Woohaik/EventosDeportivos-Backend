using Domain.models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class EventController : ApiController
    {
        public HttpResponseMessage GetEvents()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "mango");
        }

        public HttpResponseMessage GetEventById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "mango");
        }

        [HttpPost]
        public HttpResponseMessage AddEvent(EventModel eventModel)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "mango");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEvent(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "mango");
        }


        [HttpPut]
        public HttpResponseMessage UpdateEvent(int id, EventModel eventModel)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "mango");
        }


        public HttpResponseMessage GetEventsByType(EventType type)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "mango");
        }



    }
}
