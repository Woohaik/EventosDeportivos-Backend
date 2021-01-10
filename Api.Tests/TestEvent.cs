using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Controllers;
using System.Net.Http;
using Domain.Models.Event;
using Domain.Services.Event;
using Domain.Models.IEventContracts;

namespace Api.Tests
{
    [TestClass]
    public class TestEvent
    {
        static int theid = 0;


        static EventModel theEventToCreate = new EventModel()
        {
            limit = 0,
            name = "EventName",
            eventType = EventTypes.ATLETISMO,
            start = DateTime.Now,
            finish = DateTime.Now.AddDays(2)
        };


        [TestMethod]
        public async Task CrudEvent()
        {
            await Assert.ThrowsExceptionAsync<Exception>(async () => await EventService.Instance.Add(theEventToCreate)); // El limite debe ser mayor a 0
            theEventToCreate.limit = 5;
            await Assert.ThrowsExceptionAsync<Exception>(async () => await EventService.Instance.Add(theEventToCreate)); // Debe empezar admenos una hora a futuro
            theEventToCreate.start = theEventToCreate.start.AddDays(1);
            await EventService.Instance.Add(theEventToCreate);

            List<IEvent> events = (List<IEvent>)await EventService.Instance.GetAll();
            IEvent theEventCreated = events.Find(theEvent => theEvent.name.Equals(theEventToCreate.name) && theEvent.limit == theEventToCreate.limit);

            theid = theEventCreated.id;

            // Se creo Evento
            Assert.IsNotNull(theEventCreated);
            Assert.AreEqual(theEventToCreate.limit, theEventCreated.limit);
            Assert.AreEqual(theEventToCreate.eventType, theEventCreated.eventType);

            IEvent theSingleEvent = await EventService.Instance.GetById(theEventCreated.id);
            // Obtiene el mismo al buscar solo 1 por id
            Assert.AreEqual(theEventCreated.name, theSingleEvent.name);
            Assert.AreEqual(theEventCreated.id, theSingleEvent.id);

            ///////////// ACTUALIZACION

            // Nuevo Nombre
            theEventToCreate.name = "NewName";

            await EventService.Instance.UpdateById(theid, theEventToCreate);

            IEvent theEventBeforeUpdate = await EventService.Instance.GetById(theid);

            Assert.AreEqual("NewName", theEventBeforeUpdate.name);

            ///////////// BORRAR

            await EventService.Instance.DeleteById(theid);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await EventService.Instance.GetById(theid)); // Ya no debe de existir en bbdd

        }





    }
}
