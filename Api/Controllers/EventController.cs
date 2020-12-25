using Domain.Models.Event;
using Domain.Models.IEventContracts;
using Domain.Services;
using Domain.Services.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class EventController : ApiController
    {

        private ICrud<IEvent> eventCrudServices = EventService.Instance;


        public async Task<HttpResponseMessage> GetCustomers()
        {
            IEnumerable<IEvent> allEvents = null;
            Thread hilo = new Thread(() => allEvents = this.eventCrudServices.GetAll());

            await Task.Run(() =>
            {
                hilo.Start();
                hilo.Join();
            });
            return Request.CreateResponse(HttpStatusCode.OK, allEvents);
        }

        public async Task<HttpResponseMessage> GetEvent(int id)
        {
            IEvent theEvent = await this.eventCrudServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, theEvent);
        }


        [HttpPost]
        public async Task<HttpResponseMessage> RegisterEvent([FromBody] EventModel theEvent)
        {
            

            await this.eventCrudServices.Add(theEvent);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCustomer(int id, [FromBody] EventModel theEvent)
        {
            await this.eventCrudServices.UpdateById(id, theEvent);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletCustomer(int id)
        {
            await this.eventCrudServices.DeleteById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
