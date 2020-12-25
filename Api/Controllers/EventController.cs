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
            return await Task.Run(() =>
             {
                 try
                 {
                     IEnumerable<IEvent> allEvents = null;
                     allEvents = this.eventCrudServices.GetAll();
                     return Request.CreateResponse(HttpStatusCode.OK, allEvents);
                 }
                 catch (Exception ex)
                 {
                     return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                 }
             });
        }

        public async Task<HttpResponseMessage> GetEvent(int id)
        {

            try
            {
                IEvent theEvent = await this.eventCrudServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, theEvent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPost]
        public async Task<HttpResponseMessage> RegisterEvent([FromBody] EventModel theEvent)
        {
            try
            {
                await this.eventCrudServices.Add(theEvent);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCustomer(int id, [FromBody] EventModel theEvent)
        {
            try
            {
                await this.eventCrudServices.UpdateById(id, theEvent);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletCustomer(int id)
        {
            try
            {
                await this.eventCrudServices.DeleteById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
