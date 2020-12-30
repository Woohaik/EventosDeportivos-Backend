using Domain.Models.IEventContracts;
using Domain.Models.IReservationContracts;
using Domain.Services.Event;
using Domain.Services.IServicesContracts;
using Domain.Services.Reservation.crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services.Reservation
{
    public class ReservationService : ReservationCrud, IReservationService
    {
        private static SemaphoreSlim mySemaphore = new SemaphoreSlim(1);
        private static ReservationService instance = null;
        private IEventService eventService = EventService.Instance;
        private ReservationService() { }
        public static ReservationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReservationService();
                }
                return instance;
            }
        }

        public async new Task Add(IReservation model)
        {
            IEvent eventToReserve = await eventService.GetById(model.reservationEvent.id);
            DateTime now = DateTime.Now;
            if (now > eventToReserve.finish) throw new Exception("El evento ya ha finalizado");

            try
            {
                await mySemaphore.WaitAsync();
                ////////////////////////////////
                int totalReservations = await this.reservationRepository.GetTotalReservationsByEventId(eventToReserve.id);
                int totalSpacesRequired = model.quantity + totalReservations;
                if (eventToReserve.limit < totalSpacesRequired) throw new Exception($"No hay suficientes entradas libres para realizar esta reserva solo quedan {eventToReserve.limit - totalReservations}");
                await base.Add(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // Por si hay expcion que cierre el semaforo
                mySemaphore.Release();
            }



        }

    }
}
