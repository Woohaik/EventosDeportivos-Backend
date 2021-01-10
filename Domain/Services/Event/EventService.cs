using Domain.Models.Event;
using Domain.Models.IEventContracts;
using Domain.Services.Event.crud;
using Domain.Services.IServicesContracts;
using Domain.Services.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Event
{
    public class EventService : EventCrud, IEventService
    {
        private static EventService instance = null;
        private EventService() { }
        public static EventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }
        }

        public new async Task<IEvent> GetById(int id)
        {
            IEvent theEvent = await base.GetById(id);
            int freeSpaces = await ReservationService.Instance.freeReservationOfEvent(id, theEvent.limit);
            theEvent.freeSpaces = freeSpaces;
            return theEvent;
        }

        public new async Task Add(IEvent model)
        {
            DateTime now = DateTime.Now;
            var horasAlFuturo = (model.start - now).TotalHours;
            if (horasAlFuturo < 1) throw new Exception("Solo se puede crear un evento que comienze admenos una hora hacia al futuro");
            // La hora de fin evento debe de ser mas al futuro de la de inicio
            if (model.start >= model.finish) throw new Exception("La Hora de Finalizacion de evento debe de ser mas al futuro que la de inicio");
            int minMinutosDeEvento = 0;
            switch (model.eventType)
            {
                case EventTypes.FUTBOL:
                    minMinutosDeEvento = 100;
                    break;
                case EventTypes.ATLETISMO:
                    minMinutosDeEvento = 150;
                    break;
                case EventTypes.BALONCESTO:
                    minMinutosDeEvento = 60;
                    break;
                case EventTypes.VOLEIBOL:
                    minMinutosDeEvento = 60;
                    break;
                default: throw new Exception("No es un evento valido");
            }

            if (model.start.AddMinutes(minMinutosDeEvento) >= model.finish) throw new Exception($"El Evento de {Enum.GetName(typeof(EventTypes), model.eventType).ToLower()} debe de durar admenos {minMinutosDeEvento} Minutos");
            if (model.limit <= 0) throw new Exception("El Evento debe de permitir admenos un espectador");

            await base.Add(model);
        }
    }
}
