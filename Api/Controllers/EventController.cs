﻿using Api.Dto;
using Api.Validators;
using Domain.Models.Event;
using Domain.Models.IEventContracts;
using Domain.Services;
using Domain.Services.Event;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{

    [EnableCors("*", "*", "*")]
    public class EventController : ApiController
    {

        private IEventService eventCrudServices = EventService.Instance;
        private AnotationValidator<EventModel> validator = AnotationValidator<EventModel>.Instance;


        public async Task<HttpResponseMessage> GetCustomers()
        {

            try
            {
                IEnumerable<IEvent> allEvents = null;
                allEvents = await this.eventCrudServices.GetAll();
                List<EventDto> allEventsDto = new List<EventDto>();

                foreach (IEvent theEvent in allEvents)
                {
                    allEventsDto.Add(new EventDto(theEvent));
                }

                return Request.CreateResponse(HttpStatusCode.OK, allEventsDto);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }
        }

        public async Task<HttpResponseMessage> GetEvent(int id)
        {
            try
            {
                IEvent theEvent = await this.eventCrudServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, new EventDto(theEvent));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }
        }


        [HttpPost]
        public async Task<HttpResponseMessage> RegisterEvent([FromBody] EventModel theEvent)
        {
            try
            {
                validator.validate(theEvent);
                await this.eventCrudServices.Add(theEvent);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCustomer(int id)
        {
            try
            {
                await this.eventCrudServices.DeleteById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorDto(ex));
            }
        }
    }
}
